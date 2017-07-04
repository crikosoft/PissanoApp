using System;
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
using System.IO;

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

            var obrasList = new string[] { "Barcelona", "San Borja Norte" };
            if (User.Identity.Name == "david.moreano")
            {
                obrasList = new string[] { "Barcelona" };
            }
            else if (User.Identity.Name == "jorge.bernardo")
            {
                obrasList = new string[] { "San Borja Norte" };
            }

            var estadoList = new string[] { "Pendiente de Aprobación", "Aprobación 1", "Aprobación 2", "Aprobación 3", "Rechazado Aprobación 1", "Rechazado Aprobación 2", "Rechazado Aprobación 3" };

            ViewBag.estadoOrdenId = new SelectList(db.EstadoOrdenes.Where(p => estadoList.Contains(p.nombre)), "nombre", "nombre");
            ViewBag.obraId = new SelectList(db.Obras.Where(p => obrasList.Contains(p.nombre)), "nombre", "nombre");

            var ordenes = db.Ordenes.Where(p => obrasList.Contains(p.Obra.nombre)).Where(p => estadoList.Contains(p.EstadoOrden.nombre)).Include(o => o.EstadoOrden).Include(o => o.FormaPago).Include(o => o.Moneda).Include(o => o.Obra).Include(o => o.Proveedor).Include(o => o.Requerimiento);
            return View(ordenes.ToList());
        }

        // GET: /OrdenCompra/Approve/5
        public ActionResult IndexApprove2()
        {
           
            
            var estadoList = new string[] { "Aprobación 1", "Aprobación 2", "Aprobación 3", "Rechazado Aprobación 2", "Rechazado Aprobación 3" };

            ViewBag.estadoOrdenId = new SelectList(db.EstadoOrdenes.Where(p => estadoList.Contains(p.nombre)), "nombre", "nombre");
            ViewBag.obraId = new SelectList(db.Obras, "nombre", "nombre");

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


            ViewBag.estadoOrdenId = new SelectList(db.EstadoOrdenes.Where(p => estadoList.Contains(p.nombre)), "nombre", "nombre");
            ViewBag.obraId = new SelectList(db.Obras, "nombre", "nombre");
            
            return View(ordenes.ToList());
        }

        // GET: /OrdenCompra/IndexAcounting/
        public ActionResult IndexAccounting()
        {                        
            var estadoList = new int[] { 4, 5, 6, 10, 11 };
            var ordenes = db.Ordenes.Where(o => estadoList.Contains(o.estadoOrdenId)).Include(o => o.FormaPago).Include(o => o.Moneda).Include(o => o.Obra).Include(o => o.Proveedor).Include(o => o.Requerimiento);


            ViewBag.estadoOrdenId = new SelectList(db.EstadoOrdenes, "nombre", "nombre");
            ViewBag.obraId = new SelectList(db.Obras, "nombre", "nombre");

            return View(ordenes.ToList());

        }

        // GET: /OrdenCompra/IndexWarehouse/
        public ActionResult IndexWarehouse()
        {
            
            var estadoList = new int[] { 4, 5, 6};
            var estadoListNombre = new string[] { "Aprobación 3", "Ingreso Parcial", "Ingreso Total" };
            var ordenes = db.Ordenes.Where(o => estadoList.Contains(o.estadoOrdenId)).Include(o => o.FormaPago).Include(o => o.Moneda).Include(o => o.Obra).Include(o => o.Proveedor).Include(o => o.Requerimiento);

            ViewBag.estadoOrdenId = new SelectList(db.EstadoOrdenes, "nombre", "nombre");
            ViewBag.estadoOrdenId = new SelectList(db.EstadoOrdenes.Where(p => estadoListNombre.Contains(p.nombre)), "nombre", "nombre");

            ViewBag.obraId = new SelectList(db.Obras, "nombre", "nombre");

            return View(ordenes.ToList());
        }


        // GET: /OrdenCompra/Approve/5
        public ActionResult Analytics()
        {
           // var estadoList = new string[] { "Aprobación 3", "Ingreso Total", "Ingreso Parcial" };
           //var ordenes = db.Ordenes.Where(p => estadoList.Contains(p.EstadoOrden.nombre)).Include(o => o.EstadoOrden).Include(o => o.FormaPago).Include(o => o.Moneda).Include(o => o.Obra).Include(o => o.Proveedor).Include(o => o.Requerimiento);

            ViewBag.estadoOrdenId = new SelectList(db.EstadoOrdenes, "nombre", "nombre");
            ViewBag.obraId = new SelectList(db.Obras, "nombre", "nombre");

            var ordenes = db.Ordenes;
            return View(ordenes.ToList());
        }

        // GET: /OrdenCompra/Approve/5
        public ActionResult DetailedAnalysis()
        {
            // var estadoList = new string[] { "Aprobación 3", "Ingreso Total", "Ingreso Parcial" };
            //var ordenes = db.Ordenes.Where(p => estadoList.Contains(p.EstadoOrden.nombre)).Include(o => o.EstadoOrden).Include(o => o.FormaPago).Include(o => o.Moneda).Include(o => o.Obra).Include(o => o.Proveedor).Include(o => o.Requerimiento);

            ViewBag.estadoOrdenId = new SelectList(db.EstadoOrdenes, "nombre", "nombre");
            ViewBag.obraId = new SelectList(db.Obras, "nombre", "nombre");

            var ordenes = db.Ordenes;
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

            OrdenCompra OrdenCompraOriginal = db.Ordenes.Find(ordenCompra.ordenCompraId);


            DateTime timeUtc = DateTime.UtcNow;
            TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
            DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);
            var estadoIngresoTotal = db.EstadoOrdenes.Where(p => p.nombre == "Ingreso Total").SingleOrDefault();
            var estadoIngresoParcial = db.EstadoOrdenes.Where(p => p.nombre == "Ingreso Parcial").SingleOrDefault();
            var estadoDetalleIngresoTotal = db.EstadoOrdenDetalles.Where(p => p.nombre == "Atendido Total").SingleOrDefault();
            var estadoDetalleIngresoParcial = db.EstadoOrdenDetalles.Where(p => p.nombre == "Atendido Parcial").SingleOrDefault(); 

            //1. Registra Estado Orden Ingreso Total
            //2. Registra Estado Orden Detalles Ingreso Total
            //3. Registra Estado Orden Ingreso Parcial
            //4. Registra Estado Orden Detalles Ingreso Parcial
            //5. Registra Ingreso documento
            //6. Actualiza Inventario en Almacén

            //Revisa detalles

            // Tabla Ingreso

            var ingreso = new Ingreso();
            var ingresosDetalle = new List<IngresoDetalle>();
            var cantidadDetallesAtendidos = 0;

            //3 Atendido Total
            cantidadDetallesAtendidos = OrdenCompraOriginal.OrdenesCompraDetalles.Where(p => p.estadoOrdenDetalleId == 3).Count();

           

            // Actualiza estado de Requerimientos
            OrdenCompraOriginal.estadoOrdenId = estadoIngresoTotal.estadoOrdenId;

            foreach (var item in ordenCompra.OrdenesCompraDetalles)
            {
                foreach (var item2 in OrdenCompraOriginal.OrdenesCompraDetalles)
                {
                    if (item.ordenCompradetalleId == item2.ordenCompradetalleId)
                    {
                        var cantidadIngresados = 0.0;

                        cantidadIngresados = item2.IngresoDetalles.Sum(survey => survey.cantidad);

                        if ((item.cantidad + cantidadIngresados) == item2.cantidad)
                        {
                            item2.estadoOrdenDetalleId = estadoDetalleIngresoTotal.estadoOrdenDetalleId;
                        }
                        else
                        {
                            item2.estadoOrdenDetalleId = estadoDetalleIngresoParcial.estadoOrdenDetalleId;
                            OrdenCompraOriginal.estadoOrdenId = estadoIngresoParcial.estadoOrdenId;
                        }

                        var ingresoDetalle = new IngresoDetalle();

                        ingresoDetalle.Ingreso = ingreso;
                        ingresoDetalle.cantidad = double.Parse(item.cantidad.ToString());
                        ingresoDetalle.ordenCompradetalleId = item.ordenCompradetalleId;
                        ingresoDetalle.avance = 0;

                        ingresosDetalle.Add(ingresoDetalle);

                        var materialNivelStock = new MaterialNivelStock();

                        materialNivelStock.almacenId = OrdenCompraOriginal.Obra.Almacenes[0].almacenId;
                        materialNivelStock.cantidad = materialNivelStock.cantidad + double.Parse(item.cantidad.ToString());
                        materialNivelStock.materialId = item2.materialId;
                        materialNivelStock.fechaStock = cstTime;
                        db.MaterialNivelStock.Add(materialNivelStock);
                     }
                }
            }

            ingreso.IngresoDetalles = ingresosDetalle;

            


            //var ordenes = db.Ordenes.Where(p => estadoList.Contains(p.EstadoOrden.nombre))


            if (ordenCompra.OrdenesCompraDetalles.Count + cantidadDetallesAtendidos != OrdenCompraOriginal.OrdenesCompraDetalles.Count)
            {
                OrdenCompraOriginal.estadoOrdenId = estadoIngresoParcial.estadoOrdenId;
            }
            // Fin Actualiza estado Requerimientos

            //Actualiza datos en Orden de Compra

            OrdenCompraOriginal.usuarioModificacion = User.Identity.Name;
            OrdenCompraOriginal.fechaModificacion = cstTime;

            

            var ordenCompraEstado = new OrdenCompraEstadoOrden();

            ordenCompraEstado.OrdenCompra = OrdenCompraOriginal;
            ordenCompraEstado.ordenCompraId = ordenCompra.ordenCompraId;
            ordenCompraEstado.estadoOrdenId = OrdenCompraOriginal.estadoOrdenId;
            ordenCompraEstado.usuarioCreacion = User.Identity.Name;
            ordenCompraEstado.fechaCreacion = cstTime;
            //ordenCompraEstado.comentario = ordenCompra.comentario;


            ingreso.numeroGuia = ordenCompra.comentario;
            ingreso.OrdenCompra = OrdenCompraOriginal;
            ingreso.ordenCompraId = OrdenCompraOriginal.ordenCompraId;
            ingreso.usuarioCreacion = User.Identity.Name;
            ingreso.fecha = cstTime;
            ingreso.fechaCreacion = cstTime;
            ingreso.fechaModificacion = cstTime;
            ingreso.usuarioModificacion = User.Identity.Name;


            db.OrdenCompraEstadoOrden.Add(ordenCompraEstado);
            db.Ingresos.Add(ingreso);





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


        public ActionResult FileUpload(int? id)
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
        public ActionResult FileUploadHandler(int? ordenCompraId)
        {


            if (ordenCompraId == null)
            {
                return HttpNotFound();
            }

            OrdenCompra OrdenCompra = db.Ordenes.Find(ordenCompraId);

            foreach (var fileKey in Request.Files.AllKeys)
            {
                var file = Request.Files[fileKey];
                try
                {
                    if (file != null)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Uploads"), OrdenCompra.numero +"-"+ fileName);
                        file.SaveAs(path);



                         Archivo archivo = new Archivo();
                         archivo.ordenCompraId = OrdenCompra.ordenCompraId;
                         archivo.tipoArchivoId = 1;
                         archivo.ruta = OrdenCompra.numero + "-" + fileName;

                         db.Archivo.Add(archivo);
                         db.SaveChanges();
                        

                    }
                }
                catch (Exception ex)
                {
                    return Json(new { Message = "Error guardando Archivo(s)" });
                }
            }
            return Json(new { Message = "Archivo(s) guardados" });
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
