﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PissanoApp.Models;
using System.Data.Entity.Validation;
using System.Text;

namespace PissanoApp.Controllers
{
    //[Authorize(Roles = "Logistica")]
    public class OrdenCompraController : Controller
    {
        private PissanoContext db = new PissanoContext();

        // GET: /OrdenCompra/
        public ActionResult Index()
        {
            var ordenes = db.Ordenes.Include(o => o.EstadoOrden).Include(o => o.FormaPago).Include(o => o.Moneda).Include(o => o.Obra).Include(o => o.Proveedor).Include(o => o.Requerimiento);
            return View(ordenes.ToList());
        }

        // GET: /OrdenCompra/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenCompra ordencompra = db.Ordenes.Find(id);
            if (ordencompra == null)
            {
                return HttpNotFound();
            }
            return View(ordencompra);
        }

        // GET: /OrdenCompra/Create
        public ActionResult Create()
        {
            ViewBag.estadoOrdenId = new SelectList(db.EstadoOrdenes, "estadoOrdenId", "nombre");
            ViewBag.formaPagoId = new SelectList(db.FormaPagos, "formaPagoId", "nombre");
            ViewBag.monedaId = new SelectList(db.Monedas, "monedaId", "nombre");
            ViewBag.obraId = new SelectList(db.Obras, "id", "nombre");
            ViewBag.proveedorId = new SelectList(db.Proveedores, "proveedorId", "razonSocial");
            ViewBag.requerimientoId = new SelectList(db.Requerimientos, "requerimientoId", "numero");
            return View();
        }

        // POST: /OrdenCompra/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ordenCompraId,numero,fecha,proveedorId,incluyeIgv,igv,total,obraId,estadoOrdenId,requerimientoId,comentario,adelanto,formaPagoId,monedaId")] OrdenCompra ordencompra)
        {
            if (ModelState.IsValid)
            {
                db.Ordenes.Add(ordencompra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.estadoOrdenId = new SelectList(db.EstadoOrdenes, "estadoOrdenId", "nombre", ordencompra.estadoOrdenId);
            ViewBag.formaPagoId = new SelectList(db.FormaPagos, "formaPagoId", "nombre", ordencompra.formaPagoId);
            ViewBag.monedaId = new SelectList(db.Monedas, "monedaId", "nombre", ordencompra.monedaId);
            ViewBag.obraId = new SelectList(db.Obras, "id", "nombre", ordencompra.obraId);
            ViewBag.proveedorId = new SelectList(db.Proveedores, "proveedorId", "razonSocial", ordencompra.proveedorId);
            ViewBag.requerimientoId = new SelectList(db.Requerimientos, "requerimientoId", "numero", ordencompra.requerimientoId);
            return View(ordencompra);
        }

        // GET: /OrdenCompra/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenCompra ordencompra = db.Ordenes.Find(id);
            if (ordencompra == null)
            {
                return HttpNotFound();
            }
            ViewBag.estadoOrdenId = new SelectList(db.EstadoOrdenes, "estadoOrdenId", "nombre", ordencompra.estadoOrdenId);
            ViewBag.formaPagoId = new SelectList(db.FormaPagos, "formaPagoId", "nombre", ordencompra.formaPagoId);
            ViewBag.monedaId = new SelectList(db.Monedas, "monedaId", "nombre", ordencompra.monedaId);
            ViewBag.obraId = new SelectList(db.Obras, "id", "nombre", ordencompra.obraId);
            ViewBag.proveedorId = new SelectList(db.Proveedores, "proveedorId", "razonSocial", ordencompra.proveedorId);
            ViewBag.requerimientoId = new SelectList(db.Requerimientos, "requerimientoId", "numero", ordencompra.requerimientoId);
            return View(ordencompra);
        }

        // POST: /OrdenCompra/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ordenCompraId,numero,fecha,proveedorId,incluyeIgv,igv,total,obraId,estadoOrdenId,requerimientoId,comentario,adelanto,formaPagoId,monedaId")] OrdenCompra ordencompra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordencompra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.estadoOrdenId = new SelectList(db.EstadoOrdenes, "estadoOrdenId", "nombre", ordencompra.estadoOrdenId);
            ViewBag.formaPagoId = new SelectList(db.FormaPagos, "formaPagoId", "nombre", ordencompra.formaPagoId);
            ViewBag.monedaId = new SelectList(db.Monedas, "monedaId", "nombre", ordencompra.monedaId);
            ViewBag.obraId = new SelectList(db.Obras, "id", "nombre", ordencompra.obraId);
            ViewBag.proveedorId = new SelectList(db.Proveedores, "proveedorId", "razonSocial", ordencompra.proveedorId);
            ViewBag.requerimientoId = new SelectList(db.Requerimientos, "requerimientoId", "numero", ordencompra.requerimientoId);
            return View(ordencompra);
        }

        // GET: /OrdenCompra/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenCompra ordencompra = db.Ordenes.Find(id);
            if (ordencompra == null)
            {
                return HttpNotFound();
            }
            return View(ordencompra);
        }

        // POST: /OrdenCompra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrdenCompra ordencompra = db.Ordenes.Find(id);
            db.Ordenes.Remove(ordencompra);
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

        // GET: /OrdenCompra/Document/5
        public ActionResult Document(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenCompra ordencompra = db.Ordenes.Find(id);
            if (ordencompra == null)
            {
                return HttpNotFound();
            }
            return View(ordencompra);
        }

        // GET: /OrdenCompra/Document/5
        public ActionResult DocumentPrint(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenCompra ordencompra = db.Ordenes.Find(id);
            if (ordencompra == null)
            {
                return HttpNotFound();
            }
            return View(ordencompra);
        }


        // GET: /OrdenCompra/Approve/5
        public ActionResult Approve(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenCompra ordencompra = db.Ordenes.Find(id);
            if (ordencompra == null)
            {
                return HttpNotFound();
            }
            return View(ordencompra);
        }

        // GET: /OrdenCompra/Approve/5
        public ActionResult Approve2(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenCompra ordencompra = db.Ordenes.Find(id);
            if (ordencompra == null)
            {
                return HttpNotFound();
            }
            return View(ordencompra);
        }

        // GET: /OrdenCompra/Approve/5
        public ActionResult Approve3(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenCompra ordencompra = db.Ordenes.Find(id);
            if (ordencompra == null)
            {
                return HttpNotFound();
            }
            return View(ordencompra);
        }


        // GET: /OrdenCompra/Approve/5
        public ActionResult EnterWarehouse(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenCompra ordencompra = db.Ordenes.Find(id);
            if (ordencompra == null)
            {
                return HttpNotFound();
            }
            return View(ordencompra);
        }


        [HttpPost]
        public ActionResult EnterWarehouse(OrdenCompra ordenCompra)
        {

            var errors = ModelState.Values.SelectMany(v => v.Errors);

            OrdenCompra OrdenCompra = db.Ordenes.Find(ordenCompra.ordenCompraId);

            DateTime timeUtc = DateTime.UtcNow;
            TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
            DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);
            var estado = db.EstadoOrdenes.Where(p => p.nombre == "Ingreso Total").SingleOrDefault(); ;

            var ordenCompraEstado = new OrdenCompraEstadoOrden();


            ordenCompraEstado.ordenCompraId = ordenCompra.ordenCompraId;
            ordenCompraEstado.estadoOrdenId = estado.estadoOrdenId;
            ordenCompraEstado.usuarioCreacion = User.Identity.Name;
            ordenCompraEstado.fechaCreacion = cstTime;
            //ordenCompraEstado.comentario = ordenCompra.comentario;


            //Actualiza datos en Orden de Compra
            ordenCompraEstado.OrdenCompra = OrdenCompra;
            ordenCompraEstado.OrdenCompra.estadoOrdenId = estado.estadoOrdenId;
            //OrdenCompra.estadoOrdenId  = estado.estadoOrdenId;
            ordenCompraEstado.OrdenCompra.usuarioModificacion = User.Identity.Name;
            ordenCompraEstado.OrdenCompra.fechaModificacion = cstTime;

            db.OrdenCompraEstadoOrden.Add(ordenCompraEstado);


            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                );
            }
            return RedirectToAction("IndexApprove3");
        }

        [HttpPost]
        public ActionResult Disapprove3(OrdenCompra ordenCompra)
        {

            var errors = ModelState.Values.SelectMany(v => v.Errors);

            OrdenCompra OrdenCompra = db.Ordenes.Find(ordenCompra.ordenCompraId);

            DateTime timeUtc = DateTime.UtcNow;
            TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
            DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);
            var estado = db.EstadoOrdenes.Where(p => p.nombre == "Rechazado Aprobación 3").SingleOrDefault(); ;

            var ordenCompraEstado = new OrdenCompraEstadoOrden();


            ordenCompraEstado.ordenCompraId = ordenCompra.ordenCompraId;
            ordenCompraEstado.estadoOrdenId = estado.estadoOrdenId;
            ordenCompraEstado.usuarioCreacion = User.Identity.Name;
            ordenCompraEstado.fechaCreacion = cstTime;
            ordenCompraEstado.comentario = ordenCompra.comentario;


            //Actualiza datos en Orden de Compra
            ordenCompraEstado.OrdenCompra = OrdenCompra;
            ordenCompraEstado.OrdenCompra.estadoOrdenId = estado.estadoOrdenId;
            //OrdenCompra.estadoOrdenId  = estado.estadoOrdenId;
            ordenCompraEstado.OrdenCompra.usuarioModificacion = User.Identity.Name;
            ordenCompraEstado.OrdenCompra.fechaModificacion = cstTime;

            db.OrdenCompraEstadoOrden.Add(ordenCompraEstado);

            
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                );
            }
            return RedirectToAction("IndexApprove3");
        }

        [HttpPost]
        public ActionResult Disapprove2(OrdenCompra ordenCompra)
        {

            var errors = ModelState.Values.SelectMany(v => v.Errors);

            OrdenCompra OrdenCompra = db.Ordenes.Find(ordenCompra.ordenCompraId);

            DateTime timeUtc = DateTime.UtcNow;
            TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
            DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);
            var estado = db.EstadoOrdenes.Where(p => p.nombre == "Rechazado Aprobación 2").SingleOrDefault(); ;

            var ordenCompraEstado = new OrdenCompraEstadoOrden();


            ordenCompraEstado.ordenCompraId = ordenCompra.ordenCompraId;
            ordenCompraEstado.estadoOrdenId = estado.estadoOrdenId;
            ordenCompraEstado.usuarioCreacion = User.Identity.Name;
            ordenCompraEstado.fechaCreacion = cstTime;
            ordenCompraEstado.comentario = ordenCompra.comentario;


            //Actualiza datos en Orden de Compra
            ordenCompraEstado.OrdenCompra = OrdenCompra;
            ordenCompraEstado.OrdenCompra.estadoOrdenId = estado.estadoOrdenId;
            //OrdenCompra.estadoOrdenId  = estado.estadoOrdenId;
            ordenCompraEstado.OrdenCompra.usuarioModificacion = User.Identity.Name;
            ordenCompraEstado.OrdenCompra.fechaModificacion = cstTime;

            db.OrdenCompraEstadoOrden.Add(ordenCompraEstado);


            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                );
            }
            return RedirectToAction("IndexApprove2");
        }



        [HttpPost]
        public ActionResult Disapprove(OrdenCompra ordenCompra)
        {

            var errors = ModelState.Values.SelectMany(v => v.Errors);

            OrdenCompra OrdenCompra = db.Ordenes.Find(ordenCompra.ordenCompraId);

            DateTime timeUtc = DateTime.UtcNow;
            TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
            DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);
            var estado = db.EstadoOrdenes.Where(p => p.nombre == "Rechazado Aprobación 1").SingleOrDefault(); ;

            var ordenCompraEstado = new OrdenCompraEstadoOrden();


            ordenCompraEstado.ordenCompraId = ordenCompra.ordenCompraId;
            ordenCompraEstado.estadoOrdenId = estado.estadoOrdenId;
            ordenCompraEstado.usuarioCreacion = User.Identity.Name;
            ordenCompraEstado.fechaCreacion = cstTime;
            ordenCompraEstado.comentario = ordenCompra.comentario;


            //Actualiza datos en Orden de Compra
            ordenCompraEstado.OrdenCompra = OrdenCompra;
            ordenCompraEstado.OrdenCompra.estadoOrdenId = estado.estadoOrdenId;
            //OrdenCompra.estadoOrdenId  = estado.estadoOrdenId;
            ordenCompraEstado.OrdenCompra.usuarioModificacion = User.Identity.Name;
            ordenCompraEstado.OrdenCompra.fechaModificacion = cstTime;

            db.OrdenCompraEstadoOrden.Add(ordenCompraEstado);


            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                );
            }
            return RedirectToAction("IndexApprove");
        }


        // GET: /OrdenCompra/Approve/5
        public ActionResult IndexApprove()
        {
            var estadoList = new string[] { "Pendiente de Aprobación", "Aprobación 1", "Aprobación 2", "Aprobación 3", "Rechazado Aprobación 1", "Rechazado Aprobación 2", "Rechazado Aprobación 3" };
            //var requerimientos = db.Requerimientos.Where(p => estadoList.Contains(p.EstadoRequerimiento.nombre));
            //var ordenes = db.Ordenes.Include(o => o.EstadoOrden).Include(o => o.FormaPago).Include(o => o.Moneda).Include(o => o.Obra).Include(o => o.Proveedor).Include(o => o.Requerimiento);
            //var ordenes = db.Ordenes.Where(p => p.estadoOrdenId==1).Include(o => o.EstadoOrden).Include(o => o.FormaPago).Include(o => o.Moneda).Include(o => o.Obra).Include(o => o.Proveedor).Include(o => o.Requerimiento);
            var ordenes = db.Ordenes.Where(p => estadoList.Contains(p.EstadoOrden.nombre)).Include(o => o.EstadoOrden).Include(o => o.FormaPago).Include(o => o.Moneda).Include(o => o.Obra).Include(o => o.Proveedor).Include(o => o.Requerimiento);
            return View(ordenes.ToList());
        }

        // GET: /OrdenCompra/Approve/5
        public ActionResult IndexApprove2()
        {
            var estadoList = new string[] { "Aprobación 1", "Aprobación 2", "Aprobación 3", "Rechazado Aprobación 2", "Rechazado Aprobación 3" };
            //var ordenes = db.Ordenes.Include(o => o.EstadoOrden).Include(o => o.FormaPago).Include(o => o.Moneda).Include(o => o.Obra).Include(o => o.Proveedor).Include(o => o.Requerimiento);
            //var ordenes = db.Ordenes.Where(p => p.estadoOrdenId==2).Include(o => o.EstadoOrden).Include(o => o.FormaPago).Include(o => o.Moneda).Include(o => o.Obra).Include(o => o.Proveedor).Include(o => o.Requerimiento);
            var ordenes = db.Ordenes.Where(p => estadoList.Contains(p.EstadoOrden.nombre)).Include(o => o.EstadoOrden).Include(o => o.FormaPago).Include(o => o.Moneda).Include(o => o.Obra).Include(o => o.Proveedor).Include(o => o.Requerimiento);
            return View(ordenes.ToList());
        }

        // GET: /OrdenCompra/Approve/5
        public ActionResult IndexApprove3()
        {
            var estadoList = new string[] { "Aprobación 2", "Aprobación 3", "Rechazado Aprobación 3" };
            //var ordenes = db.Ordenes.Include(o => o.EstadoOrden).Include(o => o.FormaPago).Include(o => o.Moneda).Include(o => o.Obra).Include(o => o.Proveedor).Include(o => o.Requerimiento);
            //var ordenes = db.Ordenes.Where(p => p.estadoOrdenId == 3).Include(o => o.EstadoOrden).Include(o => o.FormaPago).Include(o => o.Moneda).Include(o => o.Obra).Include(o => o.Proveedor).Include(o => o.Requerimiento);
            var ordenes = db.Ordenes.Where(p => estadoList.Contains(p.EstadoOrden.nombre)).Include(o => o.EstadoOrden).Include(o => o.FormaPago).Include(o => o.Moneda).Include(o => o.Obra).Include(o => o.Proveedor).Include(o => o.Requerimiento);
            return View(ordenes.ToList());
        }

        // GET: /OrdenCompra/IndexAcounting/
        public ActionResult IndexAccounting()
        {                        
            var estadoList = new int[] { 4, 5, 6 };
            var ordenes = db.Ordenes.Where(o => estadoList.Contains(o.estadoOrdenId)).Include(o => o.FormaPago).Include(o => o.Moneda).Include(o => o.Obra).Include(o => o.Proveedor).Include(o => o.Requerimiento);

            //var ordenes = db.Ordenes.Include(p => p.EstadoOrden).Include(o => o.FormaPago).Include(o => o.Moneda).Include(o => o.Obra).Include(o => o.Proveedor).Include(o => o.Requerimiento);
            //var ordenes = db.Ordenes.Where(p => p.estadoOrdenId == 3).Include(o => o.EstadoOrden).Include(o => o.FormaPago).Include(o => o.Moneda).Include(o => o.Obra).Include(o => o.Proveedor).Include(o => o.Requerimiento);
            return View(ordenes.ToList());
        }


        // GET: /OrdenCompra/IndexAcounting/
        public ActionResult IndexWarehouse()
        {
            var estadoList = new int[] {4,6};
            var ordenes = db.Ordenes.Where(o => estadoList.Contains(o.estadoOrdenId)).Include(o => o.FormaPago).Include(o => o.Moneda).Include(o => o.Obra).Include(o => o.Proveedor).Include(o => o.Requerimiento);

            //var ordenes = db.Ordenes.Include(p => p.EstadoOrden).Include(o => o.FormaPago).Include(o => o.Moneda).Include(o => o.Obra).Include(o => o.Proveedor).Include(o => o.Requerimiento);
            //var ordenes = db.Ordenes.Where(p => p.estadoOrdenId == 3).Include(o => o.EstadoOrden).Include(o => o.FormaPago).Include(o => o.Moneda).Include(o => o.Obra).Include(o => o.Proveedor).Include(o => o.Requerimiento);
            return View(ordenes.ToList());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Approve([Bind(Include="ordenCompraId,numero,fecha,proveedorId,incluyeIgv,igv,total,obraId,estadoOrdenId,requerimientoId,comentario,adelanto,formaPagoId,monedaId")] OrdenCompra ordencompra)
        {
            //if (ModelState.IsValid)
            //{
                //db.Entry(ordencompra).State = EntityState.Modified;

            OrdenCompra orderCompra = db.Ordenes.Find(ordencompra.ordenCompraId);
            if (orderCompra == null)
            {
                return HttpNotFound();
            }

            orderCompra.estadoOrdenId = 2;
                db.SaveChanges();
                return RedirectToAction("IndexApprove");
            //}
            //ViewBag.obraId = new SelectList(db.Obras, "id", "direccion", ordencompra.ordenCompraId);
            return View(ordencompra);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Approve2([Bind(Include = "ordenCompraId,numero,fecha,proveedorId,incluyeIgv,igv,total,obraId,estadoOrdenId,requerimientoId,comentario,adelanto,formaPagoId,monedaId")] OrdenCompra ordencompra)
        {
            //if (ModelState.IsValid)
            //{
            //db.Entry(ordencompra).State = EntityState.Modified;

            OrdenCompra orderCompra = db.Ordenes.Find(ordencompra.ordenCompraId);
            if (orderCompra == null)
            {
                return HttpNotFound();
            }

            orderCompra.estadoOrdenId = 3;
            db.SaveChanges();
            return RedirectToAction("IndexApprove2");
            //}
            //ViewBag.obraId = new SelectList(db.Obras, "id", "direccion", ordencompra.ordenCompraId);
            return View(ordencompra);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Approve3([Bind(Include = "ordenCompraId,numero,fecha,proveedorId,incluyeIgv,igv,total,obraId,estadoOrdenId,requerimientoId,comentario,adelanto,formaPagoId,monedaId")] OrdenCompra ordencompra)
        {
            //if (ModelState.IsValid)
            //{
            //db.Entry(ordencompra).State = EntityState.Modified;

            OrdenCompra orderCompra = db.Ordenes.Find(ordencompra.ordenCompraId);
            if (orderCompra == null)
            {
                return HttpNotFound();
            }

            orderCompra.estadoOrdenId = 4;
            db.SaveChanges();
            return RedirectToAction("IndexApprove3");
            //}
            //ViewBag.obraId = new SelectList(db.Obras, "id", "direccion", ordencompra.ordenCompraId);
            return View(ordencompra);
        }

        //[HttpPost]
        ////[ValidateAntiForgeryToken]
        //public ActionResult ApproveOrder(int? id)
        //{

        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    OrdenCompra orderCompra = db.Ordenes.Find(id);
        //    if (orderCompra == null)
        //    {
        //        return HttpNotFound();
        //    }

           
        //        orderCompra.estadoOrdenId = 1;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return RedirectToAction("Index");
        }
    }
//}
