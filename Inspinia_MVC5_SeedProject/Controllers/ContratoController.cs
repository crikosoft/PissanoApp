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
    public class ContratoController : Controller
    {
        private PissanoContext db = new PissanoContext();

        // GET: /Contrato/
        public ActionResult Index()
        {
            var contrato = db.Contrato.Include(c => c.OrdenCompra).Include(c => c.TipoValorizacion);
            return View(contrato.ToList());
        }

        // GET: /Contrato/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = db.Contrato.Find(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            return View(contrato);
        }

        // GET: /Contrato/Create
        public ActionResult Create(int? id)
        {
            Contrato contrato = db.Contrato.FirstOrDefault();
            OrdenCompra orden = db.Ordenes.Where(a => a.ordenCompraId == id).FirstOrDefault();
            contrato.ordenCompraId = orden.ordenCompraId; 
            contrato.OrdenCompra = orden;
            //ViewBag.ordenCompraId = orden.ordenCompraId;
            ViewBag.tipoValorizacionId = new SelectList(db.TipoValorizacion, "tipoValorizacionId", "nombre");
            return View(contrato);
        }



        // POST: /Contrato/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="contratoId,ordenCompraId,materialId,metrado,adelanto,adelantoPorc,fondoGarantia,fondoGarantiaPorc,tipoValorizacionId,fechaInicio,duracion,avance,avancePorc,saldo,saldoPorc,numeroPagos,usuarioCreacion,usuarioModificacion,fechaCreacion,fechaModificacion")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                db.Contrato.Add(contrato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ordenCompraId = new SelectList(db.Ordenes, "ordenCompraId", "numero", contrato.ordenCompraId);
            ViewBag.tipoValorizacionId = new SelectList(db.TipoValorizacion, "tipoValorizacionId", "nombre", contrato.tipoValorizacionId);
            return View(contrato);
        }

        // GET: /Contrato/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = db.Contrato.Find(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            ViewBag.ordenCompraId = new SelectList(db.Ordenes, "ordenCompraId", "numero", contrato.ordenCompraId);
            ViewBag.tipoValorizacionId = new SelectList(db.TipoValorizacion, "tipoValorizacionId", "nombre", contrato.tipoValorizacionId);
            return View(contrato);
        }

        // POST: /Contrato/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="contratoId,ordenCompraId,materialId,metrado,adelanto,adelantoPorc,fondoGarantia,fondoGarantiaPorc,tipoValorizacionId,fechaInicio,duracion,avance,avancePorc,saldo,saldoPorc,numeroPagos,usuarioCreacion,usuarioModificacion,fechaCreacion,fechaModificacion")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contrato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ordenCompraId = new SelectList(db.Ordenes, "ordenCompraId", "numero", contrato.ordenCompraId);
            ViewBag.tipoValorizacionId = new SelectList(db.TipoValorizacion, "tipoValorizacionId", "nombre", contrato.tipoValorizacionId);
            return View(contrato);
        }

        // GET: /Contrato/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = db.Contrato.Find(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            return View(contrato);
        }

        // POST: /Contrato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contrato contrato = db.Contrato.Find(id);
            db.Contrato.Remove(contrato);
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
