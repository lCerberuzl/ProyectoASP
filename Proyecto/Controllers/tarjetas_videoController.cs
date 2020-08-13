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
    public class tarjetas_videoController : Controller
    {
        private Entities db = new Entities();

        // GET: tarjetas_video
        public ActionResult Index()
        {
            var tarjeta_video = db.tarjeta_video.Include(t => t.inventario);
            return View(tarjeta_video.ToList());
        }

        // GET: tarjetas_video/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tarjeta_video tarjeta_video = db.tarjeta_video.Find(id);
            if (tarjeta_video == null)
            {
                return HttpNotFound();
            }
            return View(tarjeta_video);
        }

        // GET: tarjetas_video/Create
        public ActionResult Create()
        {
            ViewBag.id_inventario = new SelectList(db.inventario, "id_inventario", "sku_producto");
            return View();
        }

        // POST: tarjetas_video/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tarjetavideo,nombre_tarjetavideo,familia_tarjetavideo,modelo_tarjetavideo,puerto_hdmi,estatus_tarjetavideo,id_inventario")] tarjeta_video tarjeta_video)
        {
            if (ModelState.IsValid)
            {
                db.tarjeta_video.Add(tarjeta_video);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_inventario = new SelectList(db.inventario, "id_inventario", "sku_producto", tarjeta_video.id_inventario);
            return View(tarjeta_video);
        }

        // GET: tarjetas_video/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tarjeta_video tarjeta_video = db.tarjeta_video.Find(id);
            if (tarjeta_video == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_inventario = new SelectList(db.inventario, "id_inventario", "sku_producto", tarjeta_video.id_inventario);
            return View(tarjeta_video);
        }

        // POST: tarjetas_video/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tarjetavideo,nombre_tarjetavideo,familia_tarjetavideo,modelo_tarjetavideo,puerto_hdmi,estatus_tarjetavideo,id_inventario")] tarjeta_video tarjeta_video)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarjeta_video).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_inventario = new SelectList(db.inventario, "id_inventario", "sku_producto", tarjeta_video.id_inventario);
            return View(tarjeta_video);
        }

        // GET: tarjetas_video/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tarjeta_video tarjeta_video = db.tarjeta_video.Find(id);
            if (tarjeta_video == null)
            {
                return HttpNotFound();
            }
            return View(tarjeta_video);
        }

        // POST: tarjetas_video/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tarjeta_video tarjeta_video = db.tarjeta_video.Find(id);
            db.tarjeta_video.Remove(tarjeta_video);
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
