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
    public class tipos_almacenamientoController : Controller
    {
        private Entities db = new Entities();

        // GET: tipos_almacenamiento
        public ActionResult Index()
        {
            return View(db.tipo_almacenamiento.ToList());
        }

        // GET: tipos_almacenamiento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_almacenamiento tipo_almacenamiento = db.tipo_almacenamiento.Find(id);
            if (tipo_almacenamiento == null)
            {
                return HttpNotFound();
            }
            return View(tipo_almacenamiento);
        }

        // GET: tipos_almacenamiento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipos_almacenamiento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tipoalmacenamiento,descripcion_almacenamiento,estatus_almacenamiento")] tipo_almacenamiento tipo_almacenamiento)
        {
            if (ModelState.IsValid)
            {
                db.tipo_almacenamiento.Add(tipo_almacenamiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_almacenamiento);
        }

        // GET: tipos_almacenamiento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_almacenamiento tipo_almacenamiento = db.tipo_almacenamiento.Find(id);
            if (tipo_almacenamiento == null)
            {
                return HttpNotFound();
            }
            return View(tipo_almacenamiento);
        }

        // POST: tipos_almacenamiento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tipoalmacenamiento,descripcion_almacenamiento,estatus_almacenamiento")] tipo_almacenamiento tipo_almacenamiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_almacenamiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_almacenamiento);
        }

        // GET: tipos_almacenamiento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_almacenamiento tipo_almacenamiento = db.tipo_almacenamiento.Find(id);
            if (tipo_almacenamiento == null)
            {
                return HttpNotFound();
            }
            return View(tipo_almacenamiento);
        }

        // POST: tipos_almacenamiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipo_almacenamiento tipo_almacenamiento = db.tipo_almacenamiento.Find(id);
            db.tipo_almacenamiento.Remove(tipo_almacenamiento);
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
