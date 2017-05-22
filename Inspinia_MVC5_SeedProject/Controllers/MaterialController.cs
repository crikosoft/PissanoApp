using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PissanoApp.Models;
using Microsoft.AspNet.Identity;

namespace PissanoApp.Controllers
{
    public class MaterialController : Controller
    {
        private PissanoContext db = new PissanoContext();

        // GET: /Material/
        public ActionResult Index()
        {
            var materiales = db.Materiales.Include(m => m.MaterialPadre).Include(m => m.TipoMaterial).Include(m => m.UnidadMedida);
            return View(materiales.ToList());
        }

        // GET: /Material/
        public ActionResult Filter(string searchText)
        {
            if (String.IsNullOrEmpty(searchText))
                searchText = "";
            else
                searchText = searchText.ToLower();

            var materiales = db.Materiales.Include(m => m.TipoMaterial).Include(m => m.UnidadMedida).Where(p => p.nombre.ToLower().Contains(searchText));

            return View(materiales.ToList());

        }

        // GET: /Material/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Material material = db.Materiales.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            return View(material);
        }

        // GET: /Material/Create
        public ActionResult Create()
        {
            ViewBag.materialPadreId = new SelectList(db.Materiales, "materialId", "nombre");
            ViewBag.tipoMaterialId = new SelectList(db.TipoMateriales, "tipoMaterialId", "nombre");
            ViewBag.unidadMedidaId = new SelectList(db.UnidadMedidas, "unidadMedidaId", "nombre");
            return View();
        }

        // POST: /Material/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="materialId,nombre,codigo,unidadMedidaId,tipoMaterialId,materialPadreId")] Material material)
        {
            if (ModelState.IsValid)
            {

                DateTime timeUtc = DateTime.UtcNow;
                TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
                DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);

                material.fechaCreacion = cstTime;
                material.usuarioCreacion = User.Identity.Name;
                material.fechaModificacion = cstTime;


                db.Materiales.Add(material);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.materialPadreId = new SelectList(db.Materiales, "materialId", "nombre", material.materialPadreId);
            ViewBag.tipoMaterialId = new SelectList(db.TipoMateriales, "tipoMaterialId", "nombre", material.tipoMaterialId);
            ViewBag.unidadMedidaId = new SelectList(db.UnidadMedidas, "unidadMedidaId", "nombre", material.unidadMedidaId);
            return View(material);
        }

        // GET: /Material/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Material material = db.Materiales.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            ViewBag.materialPadreId = new SelectList(db.Materiales, "materialId", "nombre", material.materialPadreId);
            ViewBag.tipoMaterialId = new SelectList(db.TipoMateriales, "tipoMaterialId", "nombre", material.tipoMaterialId);
            ViewBag.unidadMedidaId = new SelectList(db.UnidadMedidas, "unidadMedidaId", "nombre", material.unidadMedidaId);
            return View(material);
        }

        // POST: /Material/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="materialId,nombre,codigo,unidadMedidaId,tipoMaterialId,materialPadreId")] Material material)
        {
            if (ModelState.IsValid)
            {

                DateTime timeUtc = DateTime.UtcNow;
                TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
                DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);

                material.fechaCreacion = cstTime;
                material.usuarioCreacion = User.Identity.Name;
                material.fechaModificacion = cstTime;
                material.usuarioModificacion = User.Identity.Name;

                db.Entry(material).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.materialPadreId = new SelectList(db.Materiales, "materialId", "nombre", material.materialPadreId);
            ViewBag.tipoMaterialId = new SelectList(db.TipoMateriales, "tipoMaterialId", "nombre", material.tipoMaterialId);
            ViewBag.unidadMedidaId = new SelectList(db.UnidadMedidas, "unidadMedidaId", "nombre", material.unidadMedidaId);
            return View(material);
        }

        // GET: /Material/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Material material = db.Materiales.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            return View(material);
        }

        // POST: /Material/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Material material = db.Materiales.Find(id);
            db.Materiales.Remove(material);
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
