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
    public class paquetes_ensambleController : Controller
    {
        private Entities db = new Entities();

        // GET: paquetes_ensamble
        public ActionResult Index()
        {
            var paquete_ensamble = db.paquete_ensamble.Include(p => p.almacenamiento).Include(p => p.fuente_poder).Include(p => p.gabinete).Include(p => p.memoria_ram).Include(p => p.procesador).Include(p => p.tarjeta_madre).Include(p => p.tarjeta_video);
            return View(paquete_ensamble.ToList());
        }

        // GET: paquetes_ensamble/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paquete_ensamble paquete_ensamble = db.paquete_ensamble.Find(id);
            if (paquete_ensamble == null)
            {
                return HttpNotFound();
            }
            return View(paquete_ensamble);
        }

        // GET: paquetes_ensamble/Create
        public ActionResult Create()
        {
            ViewBag.almacenamiento_ensamble = new SelectList(db.almacenamiento, "id_almacenamiento", "nombre_almacenamiento");
            ViewBag.fuentepoder_ensamble = new SelectList(db.fuente_poder, "id_fuentepoder", "nombre_fuentepoder");
            ViewBag.gabinete_ensamble = new SelectList(db.gabinete, "id_gabinete", "nombre_gabinete");
            ViewBag.ram_ensamble = new SelectList(db.memoria_ram, "id_memoriaram", "nombre_memoriaram");
            ViewBag.procesador_ensamble = new SelectList(db.procesador, "id_procesador", "nombre_procesador");
            ViewBag.tarjetamadre_ensamble = new SelectList(db.tarjeta_madre, "id_tarjetamadre", "nombre_tarjetamadre");
            ViewBag.tarjetavideo_ensamble = new SelectList(db.tarjeta_video, "id_tarjetavideo", "nombre_tarjetavideo");
            return View();
        }

        // POST: paquetes_ensamble/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_ensamble,tarjetamadre_ensamble,procesador_ensamble,ram_ensamble,almacenamiento_ensamble,fuentepoder_ensamble,tarjetavideo_ensamble,gabinete_ensamble,estatus_ensamble")] paquete_ensamble paquete_ensamble)
        {
            if (ModelState.IsValid)
            {
                db.paquete_ensamble.Add(paquete_ensamble);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.almacenamiento_ensamble = new SelectList(db.almacenamiento, "id_almacenamiento", "nombre_almacenamiento", paquete_ensamble.almacenamiento_ensamble);
            ViewBag.fuentepoder_ensamble = new SelectList(db.fuente_poder, "id_fuentepoder", "nombre_fuentepoder", paquete_ensamble.fuentepoder_ensamble);
            ViewBag.gabinete_ensamble = new SelectList(db.gabinete, "id_gabinete", "nombre_gabinete", paquete_ensamble.gabinete_ensamble);
            ViewBag.ram_ensamble = new SelectList(db.memoria_ram, "id_memoriaram", "nombre_memoriaram", paquete_ensamble.ram_ensamble);
            ViewBag.procesador_ensamble = new SelectList(db.procesador, "id_procesador", "nombre_procesador", paquete_ensamble.procesador_ensamble);
            ViewBag.tarjetamadre_ensamble = new SelectList(db.tarjeta_madre, "id_tarjetamadre", "nombre_tarjetamadre", paquete_ensamble.tarjetamadre_ensamble);
            ViewBag.tarjetavideo_ensamble = new SelectList(db.tarjeta_video, "id_tarjetavideo", "nombre_tarjetavideo", paquete_ensamble.tarjetavideo_ensamble);
            return View(paquete_ensamble);
        }

        // GET: paquetes_ensamble/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paquete_ensamble paquete_ensamble = db.paquete_ensamble.Find(id);
            if (paquete_ensamble == null)
            {
                return HttpNotFound();
            }
            ViewBag.almacenamiento_ensamble = new SelectList(db.almacenamiento, "id_almacenamiento", "nombre_almacenamiento", paquete_ensamble.almacenamiento_ensamble);
            ViewBag.fuentepoder_ensamble = new SelectList(db.fuente_poder, "id_fuentepoder", "nombre_fuentepoder", paquete_ensamble.fuentepoder_ensamble);
            ViewBag.gabinete_ensamble = new SelectList(db.gabinete, "id_gabinete", "nombre_gabinete", paquete_ensamble.gabinete_ensamble);
            ViewBag.ram_ensamble = new SelectList(db.memoria_ram, "id_memoriaram", "nombre_memoriaram", paquete_ensamble.ram_ensamble);
            ViewBag.procesador_ensamble = new SelectList(db.procesador, "id_procesador", "nombre_procesador", paquete_ensamble.procesador_ensamble);
            ViewBag.tarjetamadre_ensamble = new SelectList(db.tarjeta_madre, "id_tarjetamadre", "nombre_tarjetamadre", paquete_ensamble.tarjetamadre_ensamble);
            ViewBag.tarjetavideo_ensamble = new SelectList(db.tarjeta_video, "id_tarjetavideo", "nombre_tarjetavideo", paquete_ensamble.tarjetavideo_ensamble);
            return View(paquete_ensamble);
        }

        // POST: paquetes_ensamble/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_ensamble,tarjetamadre_ensamble,procesador_ensamble,ram_ensamble,almacenamiento_ensamble,fuentepoder_ensamble,tarjetavideo_ensamble,gabinete_ensamble,estatus_ensamble")] paquete_ensamble paquete_ensamble)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paquete_ensamble).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.almacenamiento_ensamble = new SelectList(db.almacenamiento, "id_almacenamiento", "nombre_almacenamiento", paquete_ensamble.almacenamiento_ensamble);
            ViewBag.fuentepoder_ensamble = new SelectList(db.fuente_poder, "id_fuentepoder", "nombre_fuentepoder", paquete_ensamble.fuentepoder_ensamble);
            ViewBag.gabinete_ensamble = new SelectList(db.gabinete, "id_gabinete", "nombre_gabinete", paquete_ensamble.gabinete_ensamble);
            ViewBag.ram_ensamble = new SelectList(db.memoria_ram, "id_memoriaram", "nombre_memoriaram", paquete_ensamble.ram_ensamble);
            ViewBag.procesador_ensamble = new SelectList(db.procesador, "id_procesador", "nombre_procesador", paquete_ensamble.procesador_ensamble);
            ViewBag.tarjetamadre_ensamble = new SelectList(db.tarjeta_madre, "id_tarjetamadre", "nombre_tarjetamadre", paquete_ensamble.tarjetamadre_ensamble);
            ViewBag.tarjetavideo_ensamble = new SelectList(db.tarjeta_video, "id_tarjetavideo", "nombre_tarjetavideo", paquete_ensamble.tarjetavideo_ensamble);
            return View(paquete_ensamble);
        }

        // GET: paquetes_ensamble/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paquete_ensamble paquete_ensamble = db.paquete_ensamble.Find(id);
            if (paquete_ensamble == null)
            {
                return HttpNotFound();
            }
            return View(paquete_ensamble);
        }

        // POST: paquetes_ensamble/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            paquete_ensamble paquete_ensamble = db.paquete_ensamble.Find(id);
            db.paquete_ensamble.Remove(paquete_ensamble);
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
