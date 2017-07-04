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
    public class PagoController : Controller
    {
        private PissanoContext db = new PissanoContext();

        // GET: /Pago/
        public ActionResult Index()
        {
            var pagos = db.Pagos.Include(p => p.EstadoOrden).Include(p => p.OrdenCompra).Include(p => p.TipoDetraccion).Include(p => p.TipoDocumento);
            return View(pagos.ToList());
        }

        // GET: /Pago/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pago pago = db.Pagos.Find(id);
            if (pago == null)
            {
                return HttpNotFound();
            }
            return View(pago);
        }

        // GET: /Pago/Create
        public ActionResult CreateDefault()
        {
            ViewBag.estadoOrdenId = new SelectList(db.EstadoOrdenes, "estadoOrdenId", "nombre");
            ViewBag.ordenCompraId = new SelectList(db.Ordenes, "ordenCompraId", "numero");
            ViewBag.tipoDetraccionId = new SelectList(db.TipoDetracciones, "tipoDetraccionId", "tipoBienServicio");
            ViewBag.tipoDocumentoId = new SelectList(db.TipoDocumentos, "tipoDocumentoId", "nombre");

            //var estado = db.EstadoOrdenes.Where(p => p.nombre == "Pendiente de Pago").SingleOrDefault();

            return View();
        }

        public ActionResult Create(int? id)
        {

            var estadoList = new string[] { "Pendiente de Pago", "Pago Realizado"};

            Pago Pago = new Pago();
            OrdenCompra OrdenCompra = db.Ordenes.Where(a => a.ordenCompraId == id).FirstOrDefault();
            Pago.ordenCompraId = OrdenCompra.ordenCompraId;
            Pago.OrdenCompra = OrdenCompra;

            ViewBag.estadoOrdenId = new SelectList(db.EstadoOrdenes.Where(p => estadoList.Contains(p.nombre)), "estadoOrdenId", "nombre");
            ViewBag.ordenCompraId = new SelectList(db.Ordenes, "ordenCompraId", "numero");
            ViewBag.tipoDetraccionId = new SelectList(db.TipoDetracciones, "tipoDetraccionId", "tipoBienServicio");
            ViewBag.tipoDocumentoId = new SelectList(db.TipoDocumentos, "tipoDocumentoId", "nombre");

            return View(Pago);
        }

        // POST: /Pago/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pagoId,ordenCompraId,tipoDocumentoId,numero,fechaPagoProg,fechaPagoReal,tipoDetraccionId,estadoOrdenId")] Pago pago)
        {
            if (ModelState.IsValid)
            {

                DateTime timeUtc = DateTime.UtcNow;
                TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
                DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);
                OrdenCompra ordenCompra = db.Ordenes.Find(pago.ordenCompraId);


                pago.fechaCreacion = cstTime;
                pago.usuarioCreacion = User.Identity.Name;

                //Actualiza datos en Orden de Compra
                pago.OrdenCompra = ordenCompra;
                pago.OrdenCompra.estadoOrdenId = pago.estadoOrdenId;
                pago.OrdenCompra.usuarioModificacion = User.Identity.Name;
                pago.OrdenCompra.fechaModificacion = cstTime;

                // Guarda en Tabla Estados
                var ordenCompraEstado = new OrdenCompraEstadoOrden();
                ordenCompraEstado.ordenCompraId = ordenCompra.ordenCompraId;
                ordenCompraEstado.estadoOrdenId = pago.estadoOrdenId;
                ordenCompraEstado.usuarioCreacion = User.Identity.Name;
                ordenCompraEstado.fechaCreacion = cstTime;
                pago.OrdenCompra.OrdenCompraEstados.Add(ordenCompraEstado);

                // Calculo de Detracción
                 if (pago.tipoDetraccionId != null)
                 { 
                    TipoDetraccion tipoDetraccion = db.TipoDetracciones.Find(pago.tipoDetraccionId);
                    pago.pagoDetraccion = tipoDetraccion.porcentaje * ordenCompra.total /100;
                 }

                db.Pagos.Add(pago);
                db.SaveChanges();
                return RedirectToAction("IndexAccounting", "OrdenCompra");
            }

            ViewBag.estadoOrdenId = new SelectList(db.EstadoOrdenes, "estadoOrdenId", "nombre", pago.estadoOrdenId);
            ViewBag.ordenCompraId = new SelectList(db.Ordenes, "ordenCompraId", "numero", pago.ordenCompraId);
            ViewBag.tipoDetraccionId = new SelectList(db.TipoDetracciones, "tipoDetraccionId", "tipoBienServicio", pago.tipoDetraccionId);
            ViewBag.tipoDocumentoId = new SelectList(db.TipoDocumentos, "tipoDocumentoId", "nombre", pago.tipoDocumentoId);
            return View(pago);
        }

        // GET: /Pago/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pago pago = db.Pagos.Find(id);
            if (pago == null)
            {
                return HttpNotFound();
            }


            var estadoList = new string[] { "Pendiente de Pago", "Pago Realizado" };

            OrdenCompra OrdenCompra = db.Ordenes.Where(a => a.ordenCompraId == pago.pagoId).FirstOrDefault();
            //Pago.ordenCompraId = OrdenCompra.ordenCompraId;
            //Pago.OrdenCompra = OrdenCompra;

            ViewBag.estadoOrdenId = new SelectList(db.EstadoOrdenes.Where(p => estadoList.Contains(p.nombre)), "estadoOrdenId", "nombre", pago.estadoOrdenId);
            ViewBag.ordenCompraId = new SelectList(db.Ordenes, "ordenCompraId", "numero", pago.ordenCompraId);
            ViewBag.tipoDetraccionId = new SelectList(db.TipoDetracciones, "tipoDetraccionId", "tipoBienServicio", pago.tipoDetraccionId);
            ViewBag.tipoDocumentoId = new SelectList(db.TipoDocumentos, "tipoDocumentoId", "nombre", pago.tipoDocumentoId);


            return View(pago);

        }

        // POST: /Pago/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include="pagoId,ordenCompraId,tipoDocumentoId,numero,fechaPagoProg,fechaPagoReal,estadoOrdenId,pagoMonto,tipoDetraccionId,pagoDetraccion,asientoContable,fechaContable,usuarioCreacion,usuarioModificacion,fechaCreacion,fechaModificacion")] Pago pago)
        public ActionResult Edit([Bind(Include = "pagoId,ordenCompraId,tipoDocumentoId,numero,fechaPagoProg,fechaPagoReal,tipoDetraccionId,estadoOrdenId")] Pago pago)
        {
            if (ModelState.IsValid)
            {

                DateTime timeUtc = DateTime.UtcNow;
                TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
                DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);
                OrdenCompra ordenCompra = db.Ordenes.Find(pago.ordenCompraId);


                pago.fechaModificacion= cstTime;
                pago.usuarioModificacion = User.Identity.Name;


                //Actualiza datos en Orden de Compra
                pago.OrdenCompra = ordenCompra;
                pago.OrdenCompra.estadoOrdenId = pago.estadoOrdenId;
                pago.OrdenCompra.usuarioModificacion = User.Identity.Name;
                pago.OrdenCompra.fechaModificacion = cstTime;

                // Guarda en Tabla Estados
                var ordenCompraEstado = new OrdenCompraEstadoOrden();
                ordenCompraEstado.ordenCompraId = ordenCompra.ordenCompraId;
                ordenCompraEstado.estadoOrdenId = pago.estadoOrdenId;
                ordenCompraEstado.usuarioCreacion = User.Identity.Name;
                ordenCompraEstado.fechaCreacion = cstTime;
                pago.OrdenCompra.OrdenCompraEstados.Add(ordenCompraEstado);

                // Calculo de Detracción
                if (pago.tipoDetraccionId != null)
                {
                    TipoDetraccion tipoDetraccion = db.TipoDetracciones.Find(pago.tipoDetraccionId);
                    pago.pagoDetraccion = tipoDetraccion.porcentaje * ordenCompra.total / 100;
                }

                db.Entry(pago).State = EntityState.Modified;
                db.Entry(pago).Property(x => x.fechaCreacion).IsModified = false;
                db.Entry(pago).Property(x => x.usuarioCreacion).IsModified = false;

                db.SaveChanges();
                return RedirectToAction("IndexAccounting", "OrdenCompra");
            }
            ViewBag.estadoOrdenId = new SelectList(db.EstadoOrdenes, "estadoOrdenId", "nombre", pago.estadoOrdenId);
            ViewBag.ordenCompraId = new SelectList(db.Ordenes, "ordenCompraId", "numero", pago.ordenCompraId);
            ViewBag.tipoDetraccionId = new SelectList(db.TipoDetracciones, "tipoDetraccionId", "tipoBienServicio", pago.tipoDetraccionId);
            ViewBag.tipoDocumentoId = new SelectList(db.TipoDocumentos, "tipoDocumentoId", "nombre", pago.tipoDocumentoId);
            return View(pago);
        }

        // GET: /Pago/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pago pago = db.Pagos.Find(id);
            if (pago == null)
            {
                return HttpNotFound();
            }
            return View(pago);
        }

        // POST: /Pago/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pago pago = db.Pagos.Find(id);
            db.Pagos.Remove(pago);
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
