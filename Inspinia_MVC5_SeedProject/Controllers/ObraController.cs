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
    public class ObraController : Controller
    {
        private PissanoContext db = new PissanoContext();

        // GET: /Obra/
        public ActionResult Index()
        {
            var obras = db.Obras.Include(o => o.empresa);
            return View(obras.ToList());
        }

        // GET: /Obra/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Obra obra = db.Obras.Find(id);
            if (obra == null)
            {
                return HttpNotFound();
            }
            return View(obra);
        }

        // GET: /Obra/Create
        public ActionResult Create()
        {
            ViewBag.empresaId = new SelectList(db.Empresas, "empresaId", "nombre");
            return View();
        }

        // POST: /Obra/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,direccion,fechaInicio,fechaFin,empresaId")] Obra obra)
        {
            if (ModelState.IsValid)
            {
                db.Obras.Add(obra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.empresaId = new SelectList(db.Empresas, "empresaId", "nombre", obra.empresaId);
            return View(obra);
        }

        // GET: /Obra/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Obra obra = db.Obras.Find(id);
            if (obra == null)
            {
                return HttpNotFound();
            }
            ViewBag.empresaId = new SelectList(db.Empresas, "empresaId", "nombre", obra.empresaId);
            return View(obra);
        }

        // POST: /Obra/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,direccion,fechaInicio,fechaFin,empresaId")] Obra obra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(obra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.empresaId = new SelectList(db.Empresas, "empresaId", "nombre", obra.empresaId);
            return View(obra);
        }

        // GET: /Obra/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Obra obra = db.Obras.Find(id);
            if (obra == null)
            {
                return HttpNotFound();
            }
            return View(obra);
        }

        // POST: /Obra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Obra obra = db.Obras.Find(id);
            db.Obras.Remove(obra);
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
