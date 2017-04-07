using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PissanoApp.Models;

namespace PissanoApp.Controllers
{
    public class RequerimientoController : Controller
    {
        private PissanoContext db = new PissanoContext();

        // GET: /Requerimiento/
        public ActionResult Index()
        {
            var requerimientos = db.Requerimientos.Include(r => r.Obra).Include(r => r.Prioridad);
            return View(requerimientos.ToList());
        }

        // GET: /Requerimiento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requerimiento requerimiento = db.Requerimientos.Find(id);
            if (requerimiento == null)
            {
                return HttpNotFound();
            }
            return View(requerimiento);
        }

        // GET: /Requerimiento/Create
        public ActionResult Create()
        {
            ViewBag.obraId = new SelectList(db.Obras, "id", "nombre");
            ViewBag.prioridadId = new SelectList(db.Prioridad, "prioridadId", "nombre");
            return View();
        }

        // POST: /Requerimiento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="requerimientoId,fecha,numero,comentario,obraId,ordenGenerada,prioridadId")] Requerimiento requerimiento)
        {
            if (ModelState.IsValid)
            {
                db.Requerimientos.Add(requerimiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.obraId = new SelectList(db.Obras, "id", "nombre", requerimiento.obraId);
            ViewBag.prioridadId = new SelectList(db.Prioridad, "prioridadId", "nombre", requerimiento.prioridadId);
            return View(requerimiento);
        }

        // GET: /Requerimiento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requerimiento requerimiento = db.Requerimientos.Find(id);
            if (requerimiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.obraId = new SelectList(db.Obras, "id", "nombre", requerimiento.obraId);
            ViewBag.prioridadId = new SelectList(db.Prioridad, "prioridadId", "nombre", requerimiento.prioridadId);
            return View(requerimiento);
        }

        // POST: /Requerimiento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="requerimientoId,fecha,numero,comentario,obraId,ordenGenerada,prioridadId")] Requerimiento requerimiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requerimiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.obraId = new SelectList(db.Obras, "id", "nombre", requerimiento.obraId);
            ViewBag.prioridadId = new SelectList(db.Prioridad, "prioridadId", "nombre", requerimiento.prioridadId);
            return View(requerimiento);
        }

        // GET: /Requerimiento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requerimiento requerimiento = db.Requerimientos.Find(id);
            if (requerimiento == null)
            {
                return HttpNotFound();
            }
            return View(requerimiento);
        }

        // POST: /Requerimiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Requerimiento requerimiento = db.Requerimientos.Find(id);
            db.Requerimientos.Remove(requerimiento);
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
