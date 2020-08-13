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
    public class tipos_socketController : Controller
    {
        private Entities db = new Entities();

        // GET: tipos_socket
        public ActionResult Index()
        {
            return View(db.tipo_socket.ToList());
        }

        // GET: tipos_socket/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_socket tipo_socket = db.tipo_socket.Find(id);
            if (tipo_socket == null)
            {
                return HttpNotFound();
            }
            return View(tipo_socket);
        }

        // GET: tipos_socket/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipos_socket/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tiposocket,descripcion_socket,estatus_socket")] tipo_socket tipo_socket)
        {
            if (ModelState.IsValid)
            {
                db.tipo_socket.Add(tipo_socket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_socket);
        }

        // GET: tipos_socket/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_socket tipo_socket = db.tipo_socket.Find(id);
            if (tipo_socket == null)
            {
                return HttpNotFound();
            }
            return View(tipo_socket);
        }

        // POST: tipos_socket/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tiposocket,descripcion_socket,estatus_socket")] tipo_socket tipo_socket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_socket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_socket);
        }

        // GET: tipos_socket/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_socket tipo_socket = db.tipo_socket.Find(id);
            if (tipo_socket == null)
            {
                return HttpNotFound();
            }
            return View(tipo_socket);
        }

        // POST: tipos_socket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipo_socket tipo_socket = db.tipo_socket.Find(id);
            db.tipo_socket.Remove(tipo_socket);
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
