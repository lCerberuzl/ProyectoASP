using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class procesadoresController : Controller
    {
        private Entities db = new Entities();

        // GET: procesadores
        public ActionResult Index()
        {
            var procesador = db.procesador.Include(p => p.inventario).Include(p => p.tipo_memoria).Include(p => p.tipo_socket);
            return View(procesador.ToList());
        }

        // GET: procesadores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            procesador procesador = db.procesador.Find(id);
            if (procesador == null)
            {
                return HttpNotFound();
            }
            return View(procesador);
        }

        // GET: procesadores/Create
        public ActionResult Create()
        {
            ViewBag.id_inventario = new SelectList(db.inventario, "id_inventario", "sku_producto");
            ViewBag.tipomemoria_procesador = new SelectList(db.tipo_memoria, "id_tipomemoria", "descripcion_tipomemoria");
            ViewBag.tiposocket_procesador = new SelectList(db.tipo_socket, "id_tiposocket", "descripcion_socket");
            return View();
        }

        // POST: procesadores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_procesador,nombre_procesador,descripcion_procesador,modelo_procesador,nucleos_procesador,frecuencia_procesador,tipomemoria_procesador,tiposocket_procesador,graficos,generacion_procesador,familia_procesador,estatus_procesador,id_inventario")] procesador procesador)
        {
            if (ModelState.IsValid)
            {
                db.procesador.Add(procesador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_inventario = new SelectList(db.inventario, "id_inventario", "sku_producto", procesador.id_inventario);
            ViewBag.tipomemoria_procesador = new SelectList(db.tipo_memoria, "id_tipomemoria", "descripcion_tipomemoria", procesador.tipomemoria_procesador);
            ViewBag.tiposocket_procesador = new SelectList(db.tipo_socket, "id_tiposocket", "descripcion_socket", procesador.tiposocket_procesador);
            return View(procesador);
        }

        // GET: procesadores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            procesador procesador = db.procesador.Find(id);
            if (procesador == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_inventario = new SelectList(db.inventario, "id_inventario", "sku_producto", procesador.id_inventario);
            ViewBag.tipomemoria_procesador = new SelectList(db.tipo_memoria, "id_tipomemoria", "descripcion_tipomemoria", procesador.tipomemoria_procesador);
            ViewBag.tiposocket_procesador = new SelectList(db.tipo_socket, "id_tiposocket", "descripcion_socket", procesador.tiposocket_procesador);
            return View(procesador);
        }

        // POST: procesadores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_procesador,nombre_procesador,descripcion_procesador,modelo_procesador,nucleos_procesador,frecuencia_procesador,tipomemoria_procesador,tiposocket_procesador,graficos,generacion_procesador,familia_procesador,estatus_procesador,id_inventario")] procesador procesador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(procesador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_inventario = new SelectList(db.inventario, "id_inventario", "sku_producto", procesador.id_inventario);
            ViewBag.tipomemoria_procesador = new SelectList(db.tipo_memoria, "id_tipomemoria", "descripcion_tipomemoria", procesador.tipomemoria_procesador);
            ViewBag.tiposocket_procesador = new SelectList(db.tipo_socket, "id_tiposocket", "descripcion_socket", procesador.tiposocket_procesador);
            return View(procesador);
        }

        // GET: procesadores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            procesador procesador = db.procesador.Find(id);
            if (procesador == null)
            {
                return HttpNotFound();
            }
            return View(procesador);
        }

        // POST: procesadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            procesador procesador = db.procesador.Find(id);
            db.procesador.Remove(procesador);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
