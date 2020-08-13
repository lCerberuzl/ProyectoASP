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
    public class fuentes_poderController : Controller
    {
        private Entities db = new Entities();

        // GET: fuentes_poder
        public ActionResult Index()
        {
            var fuente_poder = db.fuente_poder.Include(f => f.inventario);
            return View(fuente_poder.ToList());
        }

        // GET: fuentes_poder/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fuente_poder fuente_poder = db.fuente_poder.Find(id);
            if (fuente_poder == null)
            {
                return HttpNotFound();
            }
            return View(fuente_poder);
        }

        // GET: fuentes_poder/Create
        public ActionResult Create()
        {
            ViewBag.id_inventario = new SelectList(db.inventario, "id_inventario", "sku_producto");
            return View();
        }

        // POST: fuentes_poder/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_fuentepoder,nombre_fuentepoder,descripcion_fuentepoder,modelo_fuentepoder,potencia_fuentepoder,estatus_fuentepoder,id_inventario")] fuente_poder fuente_poder)
        {
            if (ModelState.IsValid)
            {
                db.fuente_poder.Add(fuente_poder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_inventario = new SelectList(db.inventario, "id_inventario", "sku_producto", fuente_poder.id_inventario);
            return View(fuente_poder);
        }

        // GET: fuentes_poder/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fuente_poder fuente_poder = db.fuente_poder.Find(id);
            if (fuente_poder == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_inventario = new SelectList(db.inventario, "id_inventario", "sku_producto", fuente_poder.id_inventario);
            return View(fuente_poder);
        }

        // POST: fuentes_poder/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_fuentepoder,nombre_fuentepoder,descripcion_fuentepoder,modelo_fuentepoder,potencia_fuentepoder,estatus_fuentepoder,id_inventario")] fuente_poder fuente_poder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fuente_poder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_inventario = new SelectList(db.inventario, "id_inventario", "sku_producto", fuente_poder.id_inventario);
            return View(fuente_poder);
        }

        // GET: fuentes_poder/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fuente_poder fuente_poder = db.fuente_poder.Find(id);
            if (fuente_poder == null)
            {
                return HttpNotFound();
            }
            return View(fuente_poder);
        }

        // POST: fuentes_poder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fuente_poder fuente_poder = db.fuente_poder.Find(id);
            db.fuente_poder.Remove(fuente_poder);
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
