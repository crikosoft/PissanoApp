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

namespace PissanoApp.Controllers
{
    public class RequerimientoController : Controller
    {
        private PissanoContext db = new PissanoContext();

        // GET: /Requerimiento/
        public ActionResult Index()
        {
            var requerimientos = db.Requerimientos.Include(r => r.Obra).Include(r => r.Prioridad);
            return View(requerimientos.ToList());
        }


        // GET: /Requerimiento/
        public ActionResult IndexApprove()
        {
            //var requerimientos = db.Requerimientos;
            var obrasList = new string[] { "Barcelona", "San Borja Norte", "SAN BORJA NORTE 717", "Boulevard 286" };
            if (User.Identity.Name == "david.moreano")
            {
                obrasList = new string[] { "Barcelona" };
            }
            else if (User.Identity.Name == "jorge.bernardo")
            {
                obrasList = new string[] { "San Borja Norte", "SAN BORJA NORTE 717" };
            }
            else if (User.Identity.Name == "marco.timoteo")
            {
                obrasList = new string[] { "Boulevard 286" };
            }

            var estadoList = new string[] { "Pendiente Aprobación", "Con OC parcial", "Con OC total", "Aprobado Total", "Con OC parcial", "Aprobado Parcial", "Rechazado Parcial" };



            var requerimientos = db.Requerimientos.Where(p => estadoList.Contains(p.EstadoRequerimiento.nombre)).Where(p => obrasList.Contains(p.Obra.nombre)).Include(r => r.Obra).Include(r => r.Prioridad);
            return View(requerimientos.ToList());
        }


        // GET: /Requerimiento/
        public ActionResult IndexOC()
        {
            var estadoList = new string[] { "Aprobado Total", "Con OC parcial", "Aprobado Parcial" };
            var requerimientos = db.Requerimientos.Where(p => estadoList.Contains(p.EstadoRequerimiento.nombre));
            //var requerimientos = db.Requerimientos.Where(p => p.estadoRequerimientoId==4 ).Include(r => r.Obra).Include(r => r.Prioridad);
            //var requerimientos = db.Requerimientos.Where(p => p.estadoRequerimientoId.ToString().Contains("2,4")).Include(r => r.Obra).Include(r => r.Prioridad);
            
            return View(requerimientos.ToList());
        }

        // GET: /Requerimiento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requerimiento requerimiento = db.Requerimientos.Find(id);
            if (requerimiento == null)
            {
                return HttpNotFound();
            }
            return View(requerimiento);
        }

        // GET: /Requerimiento/Create
        public ActionResult Create()
        {
            ViewBag.obraId = new SelectList(db.Obras, "id", "nombre");
            ViewBag.prioridadId = new SelectList(db.Prioridad, "prioridadId", "nombre");
            return View();
        }

        // POST: /Requerimiento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="requerimientoId,fecha,numero,comentario,obraId,ordenGenerada,prioridadId")] Requerimiento requerimiento)
        {
            if (ModelState.IsValid)
            {
                db.Requerimientos.Add(requerimiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.obraId = new SelectList(db.Obras, "id", "nombre", requerimiento.obraId);
            ViewBag.prioridadId = new SelectList(db.Prioridad, "prioridadId", "nombre", requerimiento.prioridadId);
            return View(requerimiento);
        }

        // GET: /Requerimiento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requerimiento requerimiento = db.Requerimientos.Find(id);
            if (requerimiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.obraId = new SelectList(db.Obras, "id", "nombre", requerimiento.obraId);
            ViewBag.prioridadId = new SelectList(db.Prioridad, "prioridadId", "nombre", requerimiento.prioridadId);
            return View(requerimiento);
        }

        // POST: /Requerimiento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="requerimientoId,fecha,numero,comentario,obraId,ordenGenerada,prioridadId")] Requerimiento requerimiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requerimiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.obraId = new SelectList(db.Obras, "id", "nombre", requerimiento.obraId);
            ViewBag.prioridadId = new SelectList(db.Prioridad, "prioridadId", "nombre", requerimiento.prioridadId);
            return View(requerimiento);
        }

        // GET: /Requerimiento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requerimiento requerimiento = db.Requerimientos.Find(id);
            if (requerimiento == null)
            {
                return HttpNotFound();
            }
            return View(requerimiento);
        }

        // POST: /Requerimiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Requerimiento requerimiento = db.Requerimientos.Find(id);

            //foreach (var item in requerimiento.Detalles)
            //{
            //    db.RequerimientoDetalles.Remove(item);

            //}
            db.Requerimientos.Remove(requerimiento);
            db.SaveChanges();
//            return RedirectToAction("Index");
            return RedirectToAction("Index/1","RequerimientoViewModel" );


        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }



        // GET: /Requerimiento/Document/5
        public ActionResult Document(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requerimiento requerimiento = db.Requerimientos.Find(id);
            if (requerimiento == null)
            {
                return HttpNotFound();
            }
            return View(requerimiento);
        }


        // GET: /Requerimiento/Approve/5
        public ActionResult Approve(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requerimiento requerimiento = db.Requerimientos.Find(id);
            if (requerimiento == null)
            {
                return HttpNotFound();
            }
            return View(requerimiento);
        }

        // GET: /Requerimiento/Approve/5
        public ActionResult Cancel(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requerimiento requerimiento = db.Requerimientos.Find(id);
            if (requerimiento == null)
            {
                return HttpNotFound();
            }
            return View(requerimiento);
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Approve([Bind(Include = "requerimientoId,fecha,numero,comentario,obraId,ordenGenerada,prioridadId")] Requerimiento requerimiento)
        //{
        //    //if (ModelState.IsValid)
        //    //{
        //    //db.Entry(ordencompra).State = EntityState.Modified;

        //    Requerimiento Requerimiento = db.Requerimientos.Find(requerimiento.requerimientoId);
        //    if (Requerimiento == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    Requerimiento.estadoRequerimientoId = 4;
        //    db.SaveChanges();
        //    return RedirectToAction("IndexApprove");
        //    //}
        //    //ViewBag.obraId = new SelectList(db.Obras, "id", "direccion", ordencompra.ordenCompraId);
        //    //return View(requerimiento);
        //}


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Approve(Requerimiento requerimiento)
        {
             var errors = ModelState.Values.SelectMany(v => v.Errors);

             //if (ModelState.IsValid)
             //{

                 Requerimiento Requerimiento = db.Requerimientos.Find(requerimiento.requerimientoId);

                 DateTime timeUtc = DateTime.UtcNow;
                 TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
                 DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);
                 var estado = db.EstadoRequerimiento.Where(p => p.nombre == "Aprobado Total").SingleOrDefault(); ;
                 var estadoDetalle = db.EstadoRequerimientoDetalle.Where(p => p.nombre == "Aprobado").SingleOrDefault();

                 var estadoList = new string[] { "Sin Aprobación", "Aprobación Rechazada"};

                 if (Requerimiento.Detalles.Where(p => estadoList.Contains(p.EstadoRequerimientoDetalle.nombre)).Count() != requerimiento.Detalles.Count())
                 {
                     estado = db.EstadoRequerimiento.Where(p => p.nombre == "Aprobado parcial").SingleOrDefault();

                 }




                 Requerimiento.estadoRequerimientoId = estadoDetalle.estadoRequerimientoDetalleId;


                 var requerimientoEstado = new RequerimientoEstadoRequerimiento();
                 var requerimientoDetalleEstado = new RequerimientoDetalleEstadoRequerimientoDetalle();
                 requerimientoEstado.Requerimiento = Requerimiento;


                 requerimientoEstado.requerimientoId = requerimiento.requerimientoId;
                 requerimientoEstado.estadoRequerimientoId = estado.estadoRequerimientoId;
                 requerimientoEstado.usuarioCreacion = User.Identity.Name;
                 requerimientoEstado.fechaCreacion = cstTime;
                 Requerimiento.estadoRequerimientoId = estado.estadoRequerimientoId;

                 //Actualiza datos en Requerimiento
                 requerimientoEstado.Requerimiento.estadoRequerimientoId = estado.estadoRequerimientoId;
                 requerimientoEstado.Requerimiento.usuarioModificacion = User.Identity.Name;
                 requerimientoEstado.Requerimiento.fechaModificacion = cstTime;

                 db.RequerimientoEstadoRequerimiento.Add(requerimientoEstado);

                 foreach (var item in requerimiento.Detalles)
                 {


                     var requerimientoDetalleEstadoRequerimientoDetalle = new RequerimientoDetalleEstadoRequerimientoDetalle();
                     requerimientoDetalleEstadoRequerimientoDetalle.requerimientoDetalleId = item.requerimientoDetalleId;
                     requerimientoDetalleEstadoRequerimientoDetalle.estadoRequerimientoDetalleId = estadoDetalle.estadoRequerimientoDetalleId;
                     requerimientoDetalleEstadoRequerimientoDetalle.usuarioCreacion = User.Identity.Name;
                     requerimientoDetalleEstadoRequerimientoDetalle.fechaCreacion = cstTime;
                     RequerimientoDetalle RequerimientoDetalle = db.RequerimientoDetalles.Find(item.requerimientoDetalleId);
                     RequerimientoDetalle.estadoRequerimientoDetalleId = estadoDetalle.estadoRequerimientoDetalleId;
                     requerimientoDetalleEstadoRequerimientoDetalle.RequerimientoDetalle = RequerimientoDetalle;
                     db.RequerimientoDetalleEstadoRequerimientoDetalle.Add(requerimientoDetalleEstadoRequerimientoDetalle);



                 }

                // db.SaveChanges();

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
                     ); // Add the original exception as the innerException
                 }
                 return RedirectToAction("IndexApprove");
             //}

             //return View(requerimiento);
        }

        [HttpPost]
        public ActionResult Disapprove(Requerimiento requerimiento)
        {

            var errors = ModelState.Values.SelectMany(v => v.Errors);

            Requerimiento Requerimiento = db.Requerimientos.Find(requerimiento.requerimientoId);

            DateTime timeUtc = DateTime.UtcNow;
            TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
            DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);
            var estado = db.EstadoRequerimiento.Where(p => p.nombre == "Aprobación Rechazada").SingleOrDefault(); ;
            var estadoDetalle = db.EstadoRequerimientoDetalle.Where(p => p.nombre == "Aprobación Rechazada").SingleOrDefault();


            var estadoList = new string[] { "Sin Aprobación", "Aprobación Rechazada" };

            if (Requerimiento.Detalles.Where(p => estadoList.Contains(p.EstadoRequerimientoDetalle.nombre)).Count() != requerimiento.Detalles.Count())
            {
                //if (Requerimiento.EstadoRequerimiento.nombre != "Aprobado Parcial")
                //{ 
                    estado = db.EstadoRequerimiento.Where(p => p.nombre == "Rechazado Parcial").SingleOrDefault();
                //}
            }

            Requerimiento.estadoRequerimientoId = estadoDetalle.estadoRequerimientoDetalleId;

            var requerimientoEstado = new RequerimientoEstadoRequerimiento();
            var requerimientoDetalleEstado = new RequerimientoDetalleEstadoRequerimientoDetalle();
            requerimientoEstado.Requerimiento = Requerimiento;


            requerimientoEstado.requerimientoId = requerimiento.requerimientoId;
            requerimientoEstado.estadoRequerimientoId = estado.estadoRequerimientoId;
            requerimientoEstado.usuarioCreacion = User.Identity.Name;
            requerimientoEstado.fechaCreacion = cstTime;
            Requerimiento.estadoRequerimientoId = estado.estadoRequerimientoId;

            //Actualiza datos en Requerimiento
            requerimientoEstado.Requerimiento.estadoRequerimientoId = estado.estadoRequerimientoId;
            requerimientoEstado.Requerimiento.usuarioModificacion = User.Identity.Name;
            requerimientoEstado.Requerimiento.fechaModificacion = cstTime;

            db.RequerimientoEstadoRequerimiento.Add(requerimientoEstado);

            foreach (var item in requerimiento.Detalles)
            {


                var requerimientoDetalleEstadoRequerimientoDetalle = new RequerimientoDetalleEstadoRequerimientoDetalle();
                requerimientoDetalleEstadoRequerimientoDetalle.requerimientoDetalleId = item.requerimientoDetalleId;
                requerimientoDetalleEstadoRequerimientoDetalle.estadoRequerimientoDetalleId = estadoDetalle.estadoRequerimientoDetalleId;
                requerimientoDetalleEstadoRequerimientoDetalle.usuarioCreacion = User.Identity.Name;
                requerimientoDetalleEstadoRequerimientoDetalle.fechaCreacion = cstTime;
                RequerimientoDetalle RequerimientoDetalle = db.RequerimientoDetalles.Find(item.requerimientoDetalleId);
                RequerimientoDetalle.estadoRequerimientoDetalleId = estadoDetalle.estadoRequerimientoDetalleId;
                requerimientoDetalleEstadoRequerimientoDetalle.RequerimientoDetalle = RequerimientoDetalle;
                db.RequerimientoDetalleEstadoRequerimientoDetalle.Add(requerimientoDetalleEstadoRequerimientoDetalle);



            }

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

        [HttpPost]
        public ActionResult Cancel(Requerimiento requerimiento)
        {

            var errors = ModelState.Values.SelectMany(v => v.Errors);

            Requerimiento Requerimiento = db.Requerimientos.Find(requerimiento.requerimientoId);

            DateTime timeUtc = DateTime.UtcNow;
            TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
            DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);
            var estado = db.EstadoRequerimiento.Where(p => p.nombre == "Anulado").SingleOrDefault(); ;
            var estadoDetalle = db.EstadoRequerimientoDetalle.Where(p => p.nombre == "Anulado").SingleOrDefault();

            Requerimiento.estadoRequerimientoId = estadoDetalle.estadoRequerimientoDetalleId;

            var requerimientoEstado = new RequerimientoEstadoRequerimiento();
            var requerimientoDetalleEstado = new RequerimientoDetalleEstadoRequerimientoDetalle();
            requerimientoEstado.Requerimiento = Requerimiento;


            requerimientoEstado.requerimientoId = requerimiento.requerimientoId;
            requerimientoEstado.estadoRequerimientoId = estado.estadoRequerimientoId;
            requerimientoEstado.usuarioCreacion = User.Identity.Name;
            requerimientoEstado.fechaCreacion = cstTime;
            Requerimiento.estadoRequerimientoId = estado.estadoRequerimientoId;

            //Actualiza datos en Requerimiento
            requerimientoEstado.Requerimiento.estadoRequerimientoId = estado.estadoRequerimientoId;
            requerimientoEstado.Requerimiento.usuarioModificacion = User.Identity.Name;
            requerimientoEstado.Requerimiento.fechaModificacion = cstTime;

            db.RequerimientoEstadoRequerimiento.Add(requerimientoEstado);

            foreach (var item in Requerimiento.Detalles)
            {


                var requerimientoDetalleEstadoRequerimientoDetalle = new RequerimientoDetalleEstadoRequerimientoDetalle();
                requerimientoDetalleEstadoRequerimientoDetalle.requerimientoDetalleId = item.requerimientoDetalleId;
                requerimientoDetalleEstadoRequerimientoDetalle.estadoRequerimientoDetalleId = estadoDetalle.estadoRequerimientoDetalleId;
                requerimientoDetalleEstadoRequerimientoDetalle.usuarioCreacion = User.Identity.Name;
                requerimientoDetalleEstadoRequerimientoDetalle.fechaCreacion = cstTime;
                RequerimientoDetalle RequerimientoDetalle = db.RequerimientoDetalles.Find(item.requerimientoDetalleId);
                RequerimientoDetalle.estadoRequerimientoDetalleId = estadoDetalle.estadoRequerimientoDetalleId;
                requerimientoDetalleEstadoRequerimientoDetalle.RequerimientoDetalle = RequerimientoDetalle;
                db.RequerimientoDetalleEstadoRequerimientoDetalle.Add(requerimientoDetalleEstadoRequerimientoDetalle);



            }

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
            return RedirectToAction("Index");
        }


        // GET: /Requerimiento/Details/5
        public ActionResult Tracking(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requerimiento requerimiento = db.Requerimientos.Find(id);
            if (requerimiento == null)
            {
                return HttpNotFound();
            }
            return View(requerimiento);
        }

        // GET: /Requerimiento/Details/5
        public ActionResult Zoom(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requerimiento requerimiento = db.Requerimientos.Find(id);
            if (requerimiento == null)
            {
                return HttpNotFound();
            }
            return View(requerimiento);
        }

        // GET: /OrdenCompra/Approve/5
        public ActionResult DetailedAnalysis()
        {
            // var estadoList = new string[] { "Aprobación 3", "Ingreso Total", "Ingreso Parcial" };
            //var ordenes = db.Ordenes.Where(p => estadoList.Contains(p.EstadoOrden.nombre)).Include(o => o.EstadoOrden).Include(o => o.FormaPago).Include(o => o.Moneda).Include(o => o.Obra).Include(o => o.Proveedor).Include(o => o.Requerimiento);

            ViewBag.estadoOrdenId = new SelectList(db.EstadoOrdenes, "nombre", "nombre");
            ViewBag.obraId = new SelectList(db.Obras, "nombre", "nombre");

            var requerimientos = db.Requerimientos;
            return View(requerimientos.ToList());
        }
    }
}
