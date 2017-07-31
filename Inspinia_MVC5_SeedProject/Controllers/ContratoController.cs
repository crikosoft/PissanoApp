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
            Contrato contrato = new Contrato();
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
        public ActionResult Create([Bind(Include = "contratoId,ordenCompraId,materialId,metrado,adelanto,adelantoPorc,fondoGarantia,fondoGarantiaPorc,tipoValorizacionId,fechaInicio,duracion,avance,avancePorc,saldo,saldoPorc,numeroPagos,usuarioCreacion,usuarioModificacion,fechaCreacion,fechaModificacion,comentario,detalleAmortizacion")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {

                DateTime timeUtc = DateTime.UtcNow;
                TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
                DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);

                contrato.fechaCreacion = cstTime;
                contrato.usuarioCreacion = User.Identity.Name;
                contrato.fechaModificacion = cstTime;
                OrdenCompra orden = db.Ordenes.Find(contrato.ordenCompraId);
                contrato.OrdenCompra = orden;
                contrato.adelanto = (contrato.adelantoPorc * orden.total)/100;
                contrato.fondoGarantia = (contrato.fondoGarantiaPorc * orden.total)/100;
                contrato.avanceMonto = 0;
                contrato.saldoMonto = 0;
                contrato.avanceMetrado = 0;
                contrato.saldoMetrado = 0;
                contrato.avancePorc = 0;
                contrato.saldoPorc = 0; 


                db.Contrato.Add(contrato);

                if (contrato.adelanto != 0)
                {
                    var estado = db.EstadoAdelanto.Where(p => p.nombre == "Pendiente de Aprobación").SingleOrDefault();

                    Adelanto adelanto = new Adelanto();
                    adelanto.Contrato = contrato;
                    adelanto.descripcion = "1er Adelanto";
                    adelanto.adelantoMonto = contrato.adelanto;

                    adelanto.fechaCreacion = cstTime;
                    adelanto.usuarioCreacion = User.Identity.Name;
                    adelanto.fechaModificacion = cstTime;

                    adelanto.estadoAdelantoId = estado.estadoAdelantoId;
                    db.Adelanto.Add(adelanto);

                    //contrato.adelanto = contrato.adelantoPorc * contrato.OrdenCompra.total / 100;

                    //Valorizacion valorizacion = new Valorizacion();
                    //valorizacion.Contrato = contrato;
                    //valorizacion.concepto = "Adelanto";
                    //valorizacion.avanceMonto = (double)(contrato.adelantoPorc*contrato.OrdenCompra.total/100);
                    //valorizacion.fechacierre = contrato.fechaInicio;
                    //valorizacion.estadoValorizacionId = 2;
                    //valorizacion.fechaCreacion = cstTime;
                    //valorizacion.usuarioCreacion = User.Identity.Name;
                    //valorizacion.fechaModificacion = cstTime;
                   
                }
                
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
            OrdenCompra orden = db.Ordenes.Find(contrato.ordenCompraId);
            contrato.ordenCompraId = orden.ordenCompraId;
            contrato.OrdenCompra = orden;
            //ViewBag.ordenCompraId = orden.ordenCompraId;
            ViewBag.tipoValorizacionId = new SelectList(db.TipoValorizacion, "tipoValorizacionId", "nombre", contrato.tipoValorizacionId);
            return View(contrato);
        }

        // POST: /Contrato/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit([Bind(Include = "contratoId,ordenCompraId,materialId,metrado,adelantoPorc,fondoGarantiaPorc,tipoValorizacionId,fechaInicio,duracion,numeroPagos,comentario,detalleAmortizacion")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                DateTime timeUtc = DateTime.UtcNow;
                TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
                DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);

                OrdenCompra orden = db.Ordenes.Find(contrato.ordenCompraId);
                contrato.adelanto = (contrato.adelantoPorc * orden.total) / 100;
                contrato.fondoGarantia = (contrato.fondoGarantiaPorc * orden.total) / 100;

                contrato.avanceMonto = 0;
                contrato.saldoMonto = 0;
                contrato.avanceMetrado = 0;
                contrato.saldoMetrado = 0;
                contrato.avancePorc = 0;
                contrato.saldoPorc = 0;

                contrato.usuarioModificacion = User.Identity.Name;
                contrato.fechaModificacion = cstTime;

                //Eliminar Adelanto en caso tenga alguno
                Adelanto adelantoRemove = db.Adelanto.Where(a => a.contratoId == contrato.contratoId).FirstOrDefault();
                if (adelantoRemove != null)
                {
                    db.Adelanto.Remove(adelantoRemove);
                    db.SaveChanges();
                }

                if (contrato.adelanto != 0)
                {

                    var estado = db.EstadoAdelanto.Where(p => p.nombre == "Pendiente de Aprobación").SingleOrDefault();

                    Adelanto adelanto = new Adelanto();
                    adelanto.Contrato = contrato;
                    adelanto.descripcion = "1er Adelanto";
                    adelanto.adelantoMonto = contrato.adelanto;

                    adelanto.fechaCreacion = cstTime;
                    adelanto.usuarioCreacion = User.Identity.Name;
                    adelanto.fechaModificacion = cstTime;

                    adelanto.estadoAdelantoId = estado.estadoAdelantoId;
                    db.Adelanto.Add(adelanto);

                }


                db.Entry(contrato).State = EntityState.Modified;
                db.Entry(contrato).Property(x => x.fechaCreacion).IsModified = false;
                db.Entry(contrato).Property(x => x.usuarioCreacion).IsModified = false;
                db.Entry(contrato).Property(x => x.ordenCompraId).IsModified = false;

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


        public ActionResult Valorizar(int? id)
        {
            Contrato contrato = db.Contrato.Find(id);
            return View(contrato);
        }
    }
}
