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
    public class gabinetesController : Controller
    {
        private Entities db = new Entities();

        // GET: gabinetes
        public ActionResult Index()
        {
            var gabinete = db.gabinete.Include(g => g.inventario);
            return View(gabinete.ToList());
        }

        // GET: gabinetes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gabinete gabinete = db.gabinete.Find(id);
            if (gabinete == null)
            {
                return HttpNotFound();
            }
            return View(gabinete);
        }

        // GET: gabinetes/Create
        public ActionResult Create()
        {
            ViewBag.id_inventario = new SelectList(db.inventario, "id_inventario", "sku_producto");
            return View();
        }

        // POST: gabinetes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_gabinete,nombre_gabinete,descripcion_gabinete,factorforma_gabinete,estatus_gabinete,id_inventario")] gabinete gabinete)
        {
            if (ModelState.IsValid)
            {
                db.gabinete.Add(gabinete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_inventario = new SelectList(db.inventario, "id_inventario", "sku_producto", gabinete.id_inventario);
            return View(gabinete);
        }

        // GET: gabinetes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gabinete gabinete = db.gabinete.Find(id);
            if (gabinete == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_inventario = new SelectList(db.inventario, "id_inventario", "sku_producto", gabinete.id_inventario);
            return View(gabinete);
        }

        // POST: gabinetes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_gabinete,nombre_gabinete,descripcion_gabinete,factorforma_gabinete,estatus_gabinete,id_inventario")] gabinete gabinete)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gabinete).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_inventario = new SelectList(db.inventario, "id_inventario", "sku_producto", gabinete.id_inventario);
            return View(gabinete);
        }

        // GET: gabinetes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gabinete gabinete = db.gabinete.Find(id);
            if (gabinete == null)
            {
                return HttpNotFound();
            }
            return View(gabinete);
        }

        // POST: gabinetes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            gabinete gabinete = db.gabinete.Find(id);
            db.gabinete.Remove(gabinete);
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
