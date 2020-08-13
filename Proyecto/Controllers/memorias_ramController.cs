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
    public class memorias_ramController : Controller
    {
        private Entities db = new Entities();

        // GET: memorias_ram
        public ActionResult Index()
        {
            var memoria_ram = db.memoria_ram.Include(m => m.inventario).Include(m => m.tipo_memoria);
            return View(memoria_ram.ToList());
        }

        // GET: memorias_ram/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            memoria_ram memoria_ram = db.memoria_ram.Find(id);
            if (memoria_ram == null)
            {
                return HttpNotFound();
            }
            return View(memoria_ram);
        }

        // GET: memorias_ram/Create
        public ActionResult Create()
        {
            ViewBag.id_inventario = new SelectList(db.inventario, "id_inventario", "sku_producto");
            ViewBag.tipomemoria_ram = new SelectList(db.tipo_memoria, "id_tipomemoria", "descripcion_tipomemoria");
            return View();
        }

        // POST: memorias_ram/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_memoriaram,nombre_memoriaram,modelo_memoriaram,descripcion_memoriaram,estatus_memoriaram,tipomemoria_ram,id_inventario")] memoria_ram memoria_ram)
        {
            if (ModelState.IsValid)
            {
                db.memoria_ram.Add(memoria_ram);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_inventario = new SelectList(db.inventario, "id_inventario", "sku_producto", memoria_ram.id_inventario);
            ViewBag.tipomemoria_ram = new SelectList(db.tipo_memoria, "id_tipomemoria", "descripcion_tipomemoria", memoria_ram.tipomemoria_ram);
            return View(memoria_ram);
        }

        // GET: memorias_ram/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            memoria_ram memoria_ram = db.memoria_ram.Find(id);
            if (memoria_ram == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_inventario = new SelectList(db.inventario, "id_inventario", "sku_producto", memoria_ram.id_inventario);
            ViewBag.tipomemoria_ram = new SelectList(db.tipo_memoria, "id_tipomemoria", "descripcion_tipomemoria", memoria_ram.tipomemoria_ram);
            return View(memoria_ram);
        }

        // POST: memorias_ram/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_memoriaram,nombre_memoriaram,modelo_memoriaram,descripcion_memoriaram,estatus_memoriaram,tipomemoria_ram,id_inventario")] memoria_ram memoria_ram)
        {
            if (ModelState.IsValid)
            {
                db.Entry(memoria_ram).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_inventario = new SelectList(db.inventario, "id_inventario", "sku_producto", memoria_ram.id_inventario);
            ViewBag.tipomemoria_ram = new SelectList(db.tipo_memoria, "id_tipomemoria", "descripcion_tipomemoria", memoria_ram.tipomemoria_ram);
            return View(memoria_ram);
        }

        // GET: memorias_ram/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            memoria_ram memoria_ram = db.memoria_ram.Find(id);
            if (memoria_ram == null)
            {
                return HttpNotFound();
            }
            return View(memoria_ram);
        }

        // POST: memorias_ram/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            memoria_ram memoria_ram = db.memoria_ram.Find(id);
            db.memoria_ram.Remove(memoria_ram);
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
