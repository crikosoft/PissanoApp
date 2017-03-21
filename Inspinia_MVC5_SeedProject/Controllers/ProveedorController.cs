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
    public class ProveedorController : Controller
    {
        private PissanoContext db = new PissanoContext();

        // GET: /Proveedor/
        public ActionResult Index()
        {
            var proveedores = db.Proveedores.Include(p => p.CategoriaProveedor).Include(p => p.FormaPago);
            return View(proveedores.ToList());
        }


        // GET: /Material/
        public ActionResult Filter(string searchText)
        {
            if (String.IsNullOrEmpty(searchText))
                searchText = "";
            else
                searchText = searchText.ToLower();

            var proveedores = db.Proveedores.Include(m => m.CategoriaProveedor).Include(m => m.FormaPago).Where(p => p.razonSocial.ToLower().Contains(searchText));

            return View(proveedores.ToList());

        }


        // GET: /Proveedor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedor proveedor = db.Proveedores.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        // GET: /Proveedor/Create
        public ActionResult Create()
        {
            ViewBag.tipoMaterialId = new SelectList(db.TipoMateriales, "tipoMaterialId", "nombre");
            ViewBag.formaPagoId = new SelectList(db.FormaPagos, "formaPagoId", "nombre");
            return View();
        }

        // POST: /Proveedor/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="proveedorId,razonSocial,direccion,representanteVentas,email,telefono,movil,numeroCuenta,formaPagoId,tipoMaterialId,estado,ruc")] Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                db.Proveedores.Add(proveedor);
                db.SaveChanges();
                return RedirectToAction("Filter");
            }

            ViewBag.tipoMaterialId = new SelectList(db.TipoMateriales, "tipoMaterialId", "nombre", proveedor.tipoMaterialId);
            ViewBag.formaPagoId = new SelectList(db.FormaPagos, "formaPagoId", "nombre", proveedor.formaPagoId);
            return View(proveedor);
        }

        // GET: /Proveedor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedor proveedor = db.Proveedores.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.tipoMaterialId = new SelectList(db.TipoMateriales, "tipoMaterialId", "nombre", proveedor.tipoMaterialId);
            ViewBag.formaPagoId = new SelectList(db.FormaPagos, "formaPagoId", "nombre", proveedor.formaPagoId);
            return View(proveedor);
        }

        // POST: /Proveedor/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="proveedorId,razonSocial,direccion,representanteVentas,email,telefono,movil,numeroCuenta,formaPagoId,tipoMaterialId,estado,ruc")] Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proveedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Filter");
            }
            ViewBag.tipoMaterialId = new SelectList(db.TipoMateriales, "tipoMaterialId", "nombre", proveedor.tipoMaterialId);
            ViewBag.formaPagoId = new SelectList(db.FormaPagos, "formaPagoId", "nombre", proveedor.formaPagoId);
            return View(proveedor);
        }

        // GET: /Proveedor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedor proveedor = db.Proveedores.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        // POST: /Proveedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proveedor proveedor = db.Proveedores.Find(id);
            db.Proveedores.Remove(proveedor);
            db.SaveChanges();
            return RedirectToAction("Filter");
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
