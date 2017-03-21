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
    public class AlmacenController : Controller
    {
        private PissanoContext db = new PissanoContext();

        // GET: /Almacen/
        public ActionResult Index()
        {
            var almacens = db.Almacens.Include(a => a.Obra);
            return View(almacens.ToList());
        }

        // GET: /Almacen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Almacen almacen = db.Almacens.Find(id);
            if (almacen == null)
            {
                return HttpNotFound();
            }
            return View(almacen);
        }

        // GET: /Almacen/Create
        public ActionResult Create()
        {
            ViewBag.obraId = new SelectList(db.Obras, "id", "direccion");
            return View();
        }

        // POST: /Almacen/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="almacenId,obraId")] Almacen almacen)
        {
            if (ModelState.IsValid)
            {
                db.Almacens.Add(almacen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.obraId = new SelectList(db.Obras, "id", "direccion", almacen.obraId);
            return View(almacen);
        }

        // GET: /Almacen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Almacen almacen = db.Almacens.Find(id);
            if (almacen == null)
            {
                return HttpNotFound();
            }
            ViewBag.obraId = new SelectList(db.Obras, "id", "direccion", almacen.obraId);
            return View(almacen);
        }

        // POST: /Almacen/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="almacenId,obraId")] Almacen almacen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(almacen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.obraId = new SelectList(db.Obras, "id", "direccion", almacen.obraId);
            return View(almacen);
        }

        // GET: /Almacen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Almacen almacen = db.Almacens.Find(id);
            if (almacen == null)
            {
                return HttpNotFound();
            }
            return View(almacen);
        }

        // POST: /Almacen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Almacen almacen = db.Almacens.Find(id);
            db.Almacens.Remove(almacen);
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
