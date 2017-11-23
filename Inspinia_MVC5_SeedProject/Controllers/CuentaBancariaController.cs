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
    public class CuentaBancariaController : Controller
    {
        private PissanoContext db = new PissanoContext();

        // GET: /CuentaBancaria/
        public ActionResult Index()
        {
            var cuentabancaria = db.CuentaBancaria.Include(c => c.Banco).Include(c => c.Moneda).Include(c => c.Proveedor);
            return View(cuentabancaria.ToList());
        }

        // GET: /CuentaBancaria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuentaBancaria cuentabancaria = db.CuentaBancaria.Find(id);
            if (cuentabancaria == null)
            {
                return HttpNotFound();
            }
            return View(cuentabancaria);
        }

        // GET: /CuentaBancaria/Create
        public ActionResult Create()
        {
            ViewBag.bancoId = new SelectList(db.Banco, "bancoId", "nombre");
            ViewBag.monedaId = new SelectList(db.Monedas, "monedaId", "nombre");
            ViewBag.proveedorId = new SelectList(db.Proveedores.OrderBy(a => a.razonSocial), "proveedorId", "razonSocial");
            return View();
        }

        // POST: /CuentaBancaria/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="cuentaBancariaId,proveedorId,monedaId,bancoId,numeroCuenta,cuentaDefault")] CuentaBancaria cuentabancaria)
        {
            if (ModelState.IsValid)
            {
                db.CuentaBancaria.Add(cuentabancaria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.bancoId = new SelectList(db.Banco, "bancoId", "nombre", cuentabancaria.bancoId);
            ViewBag.monedaId = new SelectList(db.Monedas, "monedaId", "nombre", cuentabancaria.monedaId);
            ViewBag.proveedorId = new SelectList(db.Proveedores.OrderBy(a => a.razonSocial), "proveedorId", "razonSocial", cuentabancaria.proveedorId);
            return View(cuentabancaria);
        }

        // GET: /CuentaBancaria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuentaBancaria cuentabancaria = db.CuentaBancaria.Find(id);
            if (cuentabancaria == null)
            {
                return HttpNotFound();
            }
            ViewBag.bancoId = new SelectList(db.Banco, "bancoId", "nombre", cuentabancaria.bancoId);
            ViewBag.monedaId = new SelectList(db.Monedas, "monedaId", "nombre", cuentabancaria.monedaId);
            ViewBag.proveedorId = new SelectList(db.Proveedores, "proveedorId", "razonSocial", cuentabancaria.proveedorId);
            return View(cuentabancaria);
        }

        // POST: /CuentaBancaria/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="cuentaBancariaId,proveedorId,monedaId,bancoId,numeroCuenta,cuentaDefault")] CuentaBancaria cuentabancaria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cuentabancaria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.bancoId = new SelectList(db.Banco, "bancoId", "nombre", cuentabancaria.bancoId);
            ViewBag.monedaId = new SelectList(db.Monedas, "monedaId", "nombre", cuentabancaria.monedaId);
            ViewBag.proveedorId = new SelectList(db.Proveedores, "proveedorId", "razonSocial", cuentabancaria.proveedorId);
            return View(cuentabancaria);
        }

        // GET: /CuentaBancaria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuentaBancaria cuentabancaria = db.CuentaBancaria.Find(id);
            if (cuentabancaria == null)
            {
                return HttpNotFound();
            }
            return View(cuentabancaria);
        }

        // POST: /CuentaBancaria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CuentaBancaria cuentabancaria = db.CuentaBancaria.Find(id);
            db.CuentaBancaria.Remove(cuentabancaria);
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
