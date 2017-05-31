﻿using System;
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
    public class OrdenServicioController : Controller
    {
        private PissanoContext db = new PissanoContext();

        // GET: /OrdenServicio/
        public ActionResult Index()
        {
            var ordenservicio = db.OrdenServicio.Include(o => o.FormaPago).Include(o => o.Material).Include(o => o.Moneda).Include(o => o.Partida).Include(o => o.Proveedor).Include(o => o.TipoValorizacion);
            return View(ordenservicio.ToList());
        }

        // GET: /OrdenServicio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenServicio ordenservicio = db.OrdenServicio.Find(id);
            if (ordenservicio == null)
            {
                return HttpNotFound();
            }
            return View(ordenservicio);
        }

        // GET: /OrdenServicio/Create
        public ActionResult Create()
        {
            ViewBag.formaPagoId = new SelectList(db.FormaPagos, "formaPagoId", "nombre");
            ViewBag.materialId = new SelectList(db.Materiales, "materialId", "nombre");
            ViewBag.monedaId = new SelectList(db.Monedas, "monedaId", "nombre");
            ViewBag.partidaId = new SelectList(db.Partida, "partidaId", "nombre");
            ViewBag.proveedorId = new SelectList(db.Proveedores, "proveedorId", "razonSocial");
            ViewBag.tipoValorizacionId = new SelectList(db.TipoValorizacion, "tipoValorizacionId", "nombre");
            return View();
        }

        // POST: /OrdenServicio/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ordenServicioId,codigo,materialId,proveedorId,metrado,precioUnitario,subtotal,igv,total,formaPagoId,monedaId,adelanto,adelantoPorc,fondoGarantia,fondoGarantiaPorc,tipoValorizacionId,fechaInicio,duracion,partidaId,avance,avancePorc,saldo,saldoPorc,numeroPagos,comentario,usuarioCreacion,usuarioModificacion,fechaCreacion,fechaModificacion")] OrdenServicio ordenservicio)
        {
            if (ModelState.IsValid)
            {
                db.OrdenServicio.Add(ordenservicio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.formaPagoId = new SelectList(db.FormaPagos, "formaPagoId", "nombre", ordenservicio.formaPagoId);
            ViewBag.materialId = new SelectList(db.Materiales, "materialId", "nombre", ordenservicio.materialId);
            ViewBag.monedaId = new SelectList(db.Monedas, "monedaId", "nombre", ordenservicio.monedaId);
            ViewBag.partidaId = new SelectList(db.Partida, "partidaId", "nombre", ordenservicio.partidaId);
            ViewBag.proveedorId = new SelectList(db.Proveedores, "proveedorId", "razonSocial", ordenservicio.proveedorId);
            ViewBag.tipoValorizacionId = new SelectList(db.TipoValorizacion, "tipoValorizacionId", "nombre", ordenservicio.tipoValorizacionId);
            return View(ordenservicio);
        }

        // GET: /OrdenServicio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenServicio ordenservicio = db.OrdenServicio.Find(id);
            if (ordenservicio == null)
            {
                return HttpNotFound();
            }
            ViewBag.formaPagoId = new SelectList(db.FormaPagos, "formaPagoId", "nombre", ordenservicio.formaPagoId);
            ViewBag.materialId = new SelectList(db.Materiales, "materialId", "nombre", ordenservicio.materialId);
            ViewBag.monedaId = new SelectList(db.Monedas, "monedaId", "nombre", ordenservicio.monedaId);
            ViewBag.partidaId = new SelectList(db.Partida, "partidaId", "nombre", ordenservicio.partidaId);
            ViewBag.proveedorId = new SelectList(db.Proveedores, "proveedorId", "razonSocial", ordenservicio.proveedorId);
            ViewBag.tipoValorizacionId = new SelectList(db.TipoValorizacion, "tipoValorizacionId", "nombre", ordenservicio.tipoValorizacionId);
            return View(ordenservicio);
        }

        // POST: /OrdenServicio/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ordenServicioId,codigo,materialId,proveedorId,metrado,precioUnitario,subtotal,igv,total,formaPagoId,monedaId,adelanto,adelantoPorc,fondoGarantia,fondoGarantiaPorc,tipoValorizacionId,fechaInicio,duracion,partidaId,avance,avancePorc,saldo,saldoPorc,numeroPagos,comentario,usuarioCreacion,usuarioModificacion,fechaCreacion,fechaModificacion")] OrdenServicio ordenservicio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordenservicio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.formaPagoId = new SelectList(db.FormaPagos, "formaPagoId", "nombre", ordenservicio.formaPagoId);
            ViewBag.materialId = new SelectList(db.Materiales, "materialId", "nombre", ordenservicio.materialId);
            ViewBag.monedaId = new SelectList(db.Monedas, "monedaId", "nombre", ordenservicio.monedaId);
            ViewBag.partidaId = new SelectList(db.Partida, "partidaId", "nombre", ordenservicio.partidaId);
            ViewBag.proveedorId = new SelectList(db.Proveedores, "proveedorId", "razonSocial", ordenservicio.proveedorId);
            ViewBag.tipoValorizacionId = new SelectList(db.TipoValorizacion, "tipoValorizacionId", "nombre", ordenservicio.tipoValorizacionId);
            return View(ordenservicio);
        }

        // GET: /OrdenServicio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenServicio ordenservicio = db.OrdenServicio.Find(id);
            if (ordenservicio == null)
            {
                return HttpNotFound();
            }
            return View(ordenservicio);
        }

        // POST: /OrdenServicio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrdenServicio ordenservicio = db.OrdenServicio.Find(id);
            db.OrdenServicio.Remove(ordenservicio);
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
