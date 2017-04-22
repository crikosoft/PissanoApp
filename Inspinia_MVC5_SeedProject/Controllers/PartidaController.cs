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
    public class PartidaController : Controller
    {
        private PissanoContext db = new PissanoContext();

        // GET: /Partida/
        public ActionResult Index()
        {
            var partida = db.Partida.Include(p => p.SubPresupuesto);
            return View(partida.ToList());
        }

        // GET: /Partida/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partida partida = db.Partida.Find(id);
            if (partida == null)
            {
                return HttpNotFound();
            }
            return View(partida);
        }

        // GET: /Partida/Create
        public ActionResult Create()
        {
            ViewBag.subPresupuestoId = new SelectList(db.SubPresupuesto, "subPresupuestoId", "nombre");
            return View();
        }

        // POST: /Partida/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="partidaId,nombre,descripcion,subPresupuestoId")] Partida partida)
        {
            if (ModelState.IsValid)
            {
                db.Partida.Add(partida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.subPresupuestoId = new SelectList(db.SubPresupuesto, "subPresupuestoId", "nombre", partida.subPresupuestoId);
            return View(partida);
        }

        // GET: /Partida/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partida partida = db.Partida.Find(id);
            if (partida == null)
            {
                return HttpNotFound();
            }
            ViewBag.subPresupuestoId = new SelectList(db.SubPresupuesto, "subPresupuestoId", "nombre", partida.subPresupuestoId);
            return View(partida);
        }

        // POST: /Partida/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="partidaId,nombre,descripcion,subPresupuestoId")] Partida partida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.subPresupuestoId = new SelectList(db.SubPresupuesto, "subPresupuestoId", "nombre", partida.subPresupuestoId);
            return View(partida);
        }

        // GET: /Partida/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partida partida = db.Partida.Find(id);
            if (partida == null)
            {
                return HttpNotFound();
            }
            return View(partida);
        }

        // POST: /Partida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Partida partida = db.Partida.Find(id);
            db.Partida.Remove(partida);
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
