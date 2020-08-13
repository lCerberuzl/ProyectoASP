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
    public class almacenamientosController : Controller
    {
        private Entities db = new Entities();

        // GET: almacenamientos
        public ActionResult Index()
        {
            var almacenamiento = db.almacenamiento.Include(a => a.inventario).Include(a => a.tipo_almacenamiento1);
            return View(almacenamiento.ToList());
        }

        // GET: almacenamientos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            almacenamiento almacenamiento = db.almacenamiento.Find(id);
            if (almacenamiento == null)
            {
                return HttpNotFound();
            }
            return View(almacenamiento);
        }

        // GET: almacenamientos/Create
        public ActionResult Create()
        {
            ViewBag.id_inventario = new SelectList(db.inventario, "id_inventario", "sku_producto");
            ViewBag.tipo_almacenamiento = new SelectList(db.tipo_almacenamiento, "id_tipoalmacenamiento", "descripcion_almacenamiento");
            return View();
        }

        // POST: almacenamientos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_almacenamiento,nombre_almacenamiento,tipo_almacenamiento,capacidad_almacenamiento,estatus_almacenamiento,id_inventario")] almacenamiento almacenamiento)
        {
            if (ModelState.IsValid)
            {
                db.almacenamiento.Add(almacenamiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_inventario = new SelectList(db.inventario, "id_inventario", "sku_producto", almacenamiento.id_inventario);
            ViewBag.tipo_almacenamiento = new SelectList(db.tipo_almacenamiento, "id_tipoalmacenamiento", "descripcion_almacenamiento", almacenamiento.tipo_almacenamiento);
            return View(almacenamiento);
        }

        // GET: almacenamientos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            almacenamiento almacenamiento = db.almacenamiento.Find(id);
            if (almacenamiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_inventario = new SelectList(db.inventario, "id_inventario", "sku_producto", almacenamiento.id_inventario);
            ViewBag.tipo_almacenamiento = new SelectList(db.tipo_almacenamiento, "id_tipoalmacenamiento", "descripcion_almacenamiento", almacenamiento.tipo_almacenamiento);
            return View(almacenamiento);
        }

        // POST: almacenamientos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_almacenamiento,nombre_almacenamiento,tipo_almacenamiento,capacidad_almacenamiento,estatus_almacenamiento,id_inventario")] almacenamiento almacenamiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(almacenamiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_inventario = new SelectList(db.inventario, "id_inventario", "sku_producto", almacenamiento.id_inventario);
            ViewBag.tipo_almacenamiento = new SelectList(db.tipo_almacenamiento, "id_tipoalmacenamiento", "descripcion_almacenamiento", almacenamiento.tipo_almacenamiento);
            return View(almacenamiento);
        }

        // GET: almacenamientos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            almacenamiento almacenamiento = db.almacenamiento.Find(id);
            if (almacenamiento == null)
            {
                return HttpNotFound();
            }
            return View(almacenamiento);
        }

        // POST: almacenamientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            almacenamiento almacenamiento = db.almacenamiento.Find(id);
            db.almacenamiento.Remove(almacenamiento);
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
