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
    public class TipoMaterialController : Controller
    {
        private PissanoContext db = new PissanoContext();

        // GET: /TipoMaterial/
        public ActionResult Index()
        {
            return View(db.TipoMateriales.ToList());
        }

        // GET: /TipoMaterial/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoMaterial tipomaterial = db.TipoMateriales.Find(id);
            if (tipomaterial == null)
            {
                return HttpNotFound();
            }
            return View(tipomaterial);
        }

        // GET: /TipoMaterial/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TipoMaterial/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="tipoMaterialId,nombre")] TipoMaterial tipomaterial)
        {
            if (ModelState.IsValid)
            {
                db.TipoMateriales.Add(tipomaterial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipomaterial);
        }

        // GET: /TipoMaterial/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoMaterial tipomaterial = db.TipoMateriales.Find(id);
            if (tipomaterial == null)
            {
                return HttpNotFound();
            }
            return View(tipomaterial);
        }

        // POST: /TipoMaterial/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="tipoMaterialId,nombre")] TipoMaterial tipomaterial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipomaterial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipomaterial);
        }

        // GET: /TipoMaterial/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoMaterial tipomaterial = db.TipoMateriales.Find(id);
            if (tipomaterial == null)
            {
                return HttpNotFound();
            }
            return View(tipomaterial);
        }

        // POST: /TipoMaterial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoMaterial tipomaterial = db.TipoMateriales.Find(id);
            db.TipoMateriales.Remove(tipomaterial);
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
