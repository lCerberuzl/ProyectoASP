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
    public class tarjetas_madreController : Controller
    {
        private Entities db = new Entities();

        // GET: tarjetas_madre
        public ActionResult Index()
        {
            var tarjeta_madre = db.tarjeta_madre.Include(t => t.inventario).Include(t => t.tipo_memoria).Include(t => t.tipo_socket);
            return View(tarjeta_madre.ToList());
        }

        // GET: tarjetas_madre/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tarjeta_madre tarjeta_madre = db.tarjeta_madre.Find(id);
            if (tarjeta_madre == null)
            {
                return HttpNotFound();
            }
            return View(tarjeta_madre);
        }

        // GET: tarjetas_madre/Create
        public ActionResult Create()
        {
            ViewBag.id_inventario = new SelectList(db.inventario, "id_inventario", "sku_producto");
            ViewBag.tipomemoria_tarjetamadre = new SelectList(db.tipo_memoria, "id_tipomemoria", "descripcion_tipomemoria");
            ViewBag.tiposocket_tarjetamadre = new SelectList(db.tipo_socket, "id_tiposocket", "descripcion_socket");
            return View();
        }

        // POST: tarjetas_madre/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tarjetamadre,nombre_tarjetamadre,tipomemoria_tarjetamadre,tiposocket_tarjetamadre,descripcion_tarjetamadre,estatus_tarjetamadre,id_inventario")] tarjeta_madre tarjeta_madre)
        {
            if (ModelState.IsValid)
            {
                db.tarjeta_madre.Add(tarjeta_madre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_inventario = new SelectList(db.inventario, "id_inventario", "sku_producto", tarjeta_madre.id_inventario);
            ViewBag.tipomemoria_tarjetamadre = new SelectList(db.tipo_memoria, "id_tipomemoria", "descripcion_tipomemoria", tarjeta_madre.tipomemoria_tarjetamadre);
            ViewBag.tiposocket_tarjetamadre = new SelectList(db.tipo_socket, "id_tiposocket", "descripcion_socket", tarjeta_madre.tiposocket_tarjetamadre);
            return View(tarjeta_madre);
        }

        // GET: tarjetas_madre/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tarjeta_madre tarjeta_madre = db.tarjeta_madre.Find(id);
            if (tarjeta_madre == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_inventario = new SelectList(db.inventario, "id_inventario", "sku_producto", tarjeta_madre.id_inventario);
            ViewBag.tipomemoria_tarjetamadre = new SelectList(db.tipo_memoria, "id_tipomemoria", "descripcion_tipomemoria", tarjeta_madre.tipomemoria_tarjetamadre);
            ViewBag.tiposocket_tarjetamadre = new SelectList(db.tipo_socket, "id_tiposocket", "descripcion_socket", tarjeta_madre.tiposocket_tarjetamadre);
            return View(tarjeta_madre);
        }

        // POST: tarjetas_madre/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tarjetamadre,nombre_tarjetamadre,tipomemoria_tarjetamadre,tiposocket_tarjetamadre,descripcion_tarjetamadre,estatus_tarjetamadre,id_inventario")] tarjeta_madre tarjeta_madre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarjeta_madre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_inventario = new SelectList(db.inventario, "id_inventario", "sku_producto", tarjeta_madre.id_inventario);
            ViewBag.tipomemoria_tarjetamadre = new SelectList(db.tipo_memoria, "id_tipomemoria", "descripcion_tipomemoria", tarjeta_madre.tipomemoria_tarjetamadre);
            ViewBag.tiposocket_tarjetamadre = new SelectList(db.tipo_socket, "id_tiposocket", "descripcion_socket", tarjeta_madre.tiposocket_tarjetamadre);
            return View(tarjeta_madre);
        }

        // GET: tarjetas_madre/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tarjeta_madre tarjeta_madre = db.tarjeta_madre.Find(id);
            if (tarjeta_madre == null)
            {
                return HttpNotFound();
            }
            return View(tarjeta_madre);
        }

        // POST: tarjetas_madre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tarjeta_madre tarjeta_madre = db.tarjeta_madre.Find(id);
            db.tarjeta_madre.Remove(tarjeta_madre);
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
