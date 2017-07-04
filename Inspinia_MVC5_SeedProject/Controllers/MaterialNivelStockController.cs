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
    public class MaterialNivelStockController : Controller
    {
        private PissanoContext db = new PissanoContext();

        // GET: /MaterialNivelStock/
        public ActionResult Index()
        {
            var materialnivelstock = db.MaterialNivelStock.Include(m => m.Almacen).Include(m => m.Material);
            ViewBag.obraId = new SelectList(db.Obras, "nombre", "nombre");
            return View(materialnivelstock.ToList());
        }

        // GET: /MaterialNivelStock/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaterialNivelStock materialnivelstock = db.MaterialNivelStock.Find(id);
            if (materialnivelstock == null)
            {
                return HttpNotFound();
            }
            return View(materialnivelstock);
        }

        // GET: /MaterialNivelStock/Create
        public ActionResult Create()
        {
            ViewBag.almacenId = new SelectList(db.Almacens, "almacenId", "almacenId");
            ViewBag.materialId = new SelectList(db.Materiales, "materialId", "nombre");
            return View();
        }

        // POST: /MaterialNivelStock/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="materialNivelStockId,almacenId,materialId,fechaStock,cantidad")] MaterialNivelStock materialnivelstock)
        {
            if (ModelState.IsValid)
            {
                db.MaterialNivelStock.Add(materialnivelstock);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.almacenId = new SelectList(db.Almacens, "almacenId", "almacenId", materialnivelstock.almacenId);
            ViewBag.materialId = new SelectList(db.Materiales, "materialId", "nombre", materialnivelstock.materialId);
            return View(materialnivelstock);
        }

        // GET: /MaterialNivelStock/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaterialNivelStock materialnivelstock = db.MaterialNivelStock.Find(id);
            if (materialnivelstock == null)
            {
                return HttpNotFound();
            }
            ViewBag.almacenId = new SelectList(db.Almacens, "almacenId", "almacenId", materialnivelstock.almacenId);
            ViewBag.materialId = new SelectList(db.Materiales, "materialId", "nombre", materialnivelstock.materialId);
            return View(materialnivelstock);
        }

        // POST: /MaterialNivelStock/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="materialNivelStockId,almacenId,materialId,fechaStock,cantidad")] MaterialNivelStock materialnivelstock)
        {
            if (ModelState.IsValid)
            {
                db.Entry(materialnivelstock).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.almacenId = new SelectList(db.Almacens, "almacenId", "almacenId", materialnivelstock.almacenId);
            ViewBag.materialId = new SelectList(db.Materiales, "materialId", "nombre", materialnivelstock.materialId);
            return View(materialnivelstock);
        }

        // GET: /MaterialNivelStock/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaterialNivelStock materialnivelstock = db.MaterialNivelStock.Find(id);
            if (materialnivelstock == null)
            {
                return HttpNotFound();
            }
            return View(materialnivelstock);
        }

        // POST: /MaterialNivelStock/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MaterialNivelStock materialnivelstock = db.MaterialNivelStock.Find(id);
            db.MaterialNivelStock.Remove(materialnivelstock);
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
