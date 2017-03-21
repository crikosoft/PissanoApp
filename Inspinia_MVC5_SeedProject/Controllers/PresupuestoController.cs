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
    public class PresupuestoController : Controller
    {
        private PissanoContext db = new PissanoContext();

        // GET: /Presupuesto/
        public ActionResult Index()
        {
            var presupuestos = db.Presupuestos.Include(p => p.Moneda).Include(p => p.Obra).Include(p => p.TipoPresupuesto);
            return View(presupuestos.ToList());
        }

        // GET: /Presupuesto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Presupuesto presupuesto = db.Presupuestos.Find(id);
            if (presupuesto == null)
            {
                return HttpNotFound();
            }
            return View(presupuesto);
        }

        // GET: /Presupuesto/Create
        public ActionResult Create()
        {
            ViewBag.monedaId = new SelectList(db.Monedas, "monedaId", "nombre");
            ViewBag.obraId = new SelectList(db.Obras, "id", "direccion");
            ViewBag.tipoPresupuestoId = new SelectList(db.TipoPresupuestoes, "tipoPresupuestoId", "descripcion");
            return View();
        }

        // POST: /Presupuesto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="presupuestoId,descripcion,obraId,fecha,monedaId,total,tipoPresupuestoId")] Presupuesto presupuesto)
        {
            if (ModelState.IsValid)
            {
                db.Presupuestos.Add(presupuesto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.monedaId = new SelectList(db.Monedas, "monedaId", "nombre", presupuesto.monedaId);
            ViewBag.obraId = new SelectList(db.Obras, "id", "direccion", presupuesto.obraId);
            ViewBag.tipoPresupuestoId = new SelectList(db.TipoPresupuestoes, "tipoPresupuestoId", "descripcion", presupuesto.tipoPresupuestoId);
            return View(presupuesto);
        }

        // GET: /Presupuesto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Presupuesto presupuesto = db.Presupuestos.Find(id);
            if (presupuesto == null)
            {
                return HttpNotFound();
            }
            ViewBag.monedaId = new SelectList(db.Monedas, "monedaId", "nombre", presupuesto.monedaId);
            ViewBag.obraId = new SelectList(db.Obras, "id", "direccion", presupuesto.obraId);
            ViewBag.tipoPresupuestoId = new SelectList(db.TipoPresupuestoes, "tipoPresupuestoId", "descripcion", presupuesto.tipoPresupuestoId);
            return View(presupuesto);
        }

        // POST: /Presupuesto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="presupuestoId,descripcion,obraId,fecha,monedaId,total,tipoPresupuestoId")] Presupuesto presupuesto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(presupuesto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.monedaId = new SelectList(db.Monedas, "monedaId", "nombre", presupuesto.monedaId);
            ViewBag.obraId = new SelectList(db.Obras, "id", "direccion", presupuesto.obraId);
            ViewBag.tipoPresupuestoId = new SelectList(db.TipoPresupuestoes, "tipoPresupuestoId", "descripcion", presupuesto.tipoPresupuestoId);
            return View(presupuesto);
        }

        // GET: /Presupuesto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Presupuesto presupuesto = db.Presupuestos.Find(id);
            if (presupuesto == null)
            {
                return HttpNotFound();
            }
            return View(presupuesto);
        }

        // POST: /Presupuesto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Presupuesto presupuesto = db.Presupuestos.Find(id);
            db.Presupuestos.Remove(presupuesto);
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
