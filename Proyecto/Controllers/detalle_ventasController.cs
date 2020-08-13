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
    public class detalle_ventasController : Controller
    {
        private Entities db = new Entities();

        // GET: detalle_ventas
        public ActionResult Index()
        {
            var detalle_venta = db.detalle_venta.Include(d => d.inventario).Include(d => d.venta);
            return View(detalle_venta.ToList());
        }

        // GET: detalle_ventas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalle_venta detalle_venta = db.detalle_venta.Find(id);
            if (detalle_venta == null)
            {
                return HttpNotFound();
            }
            return View(detalle_venta);
        }

        // GET: detalle_ventas/Create
        public ActionResult Create()
        {
            ViewBag.id_producto = new SelectList(db.inventario, "id_inventario", "sku_producto");
            ViewBag.id_venta = new SelectList(db.venta, "id_venta", "observaciones_venta");
            return View();
        }

        // POST: detalle_ventas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_detalleventa,id_venta,id_producto,cantidad,total")] detalle_venta detalle_venta)
        {
            if (ModelState.IsValid)
            {
                db.detalle_venta.Add(detalle_venta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_producto = new SelectList(db.inventario, "id_inventario", "sku_producto", detalle_venta.id_producto);
            ViewBag.id_venta = new SelectList(db.venta, "id_venta", "observaciones_venta", detalle_venta.id_venta);
            return View(detalle_venta);
        }

        // GET: detalle_ventas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalle_venta detalle_venta = db.detalle_venta.Find(id);
            if (detalle_venta == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_producto = new SelectList(db.inventario, "id_inventario", "sku_producto", detalle_venta.id_producto);
            ViewBag.id_venta = new SelectList(db.venta, "id_venta", "observaciones_venta", detalle_venta.id_venta);
            return View(detalle_venta);
        }

        // POST: detalle_ventas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_detalleventa,id_venta,id_producto,cantidad,total")] detalle_venta detalle_venta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalle_venta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_producto = new SelectList(db.inventario, "id_inventario", "sku_producto", detalle_venta.id_producto);
            ViewBag.id_venta = new SelectList(db.venta, "id_venta", "observaciones_venta", detalle_venta.id_venta);
            return View(detalle_venta);
        }

        // GET: detalle_ventas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalle_venta detalle_venta = db.detalle_venta.Find(id);
            if (detalle_venta == null)
            {
                return HttpNotFound();
            }
            return View(detalle_venta);
        }

        // POST: detalle_ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            detalle_venta detalle_venta = db.detalle_venta.Find(id);
            db.detalle_venta.Remove(detalle_venta);
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
