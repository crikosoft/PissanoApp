using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PissanoApp.ViewModels;
using PissanoApp.Models;
using System.Data.Entity.Validation;
using System.Text;

namespace PissanoApp.Controllers
{
        //[Authorize(Roles = "Obra")]
    public class RequerimientoViewModelController : Controller
    {
        private PissanoContext db = new PissanoContext();

        // GET: /RequerimientoViewModel/
        public ActionResult Index(int? id)
        {
            var obras = db.Obras;

           

            var materiales = db.Materiales;

            var prioridades = db.Prioridad;

            //var requerimientos = db.Requerimientos.OrderByDescending(p => p.requerimientoId);
            var requerimientos = db.Requerimientos.Where(p => p.tipoCompraId == id).OrderByDescending(p => p.requerimientoId);

            var tipoCompra = db.TipoCompra.Find(id);

            var partidas = db.Partida;

            var subPresupuestos = db.SubPresupuesto;

            var RequerimientoViewModels = new RequerimientoViewModel(obras.ToList(), materiales.ToList(), prioridades.ToList(), requerimientos.ToList(), tipoCompra, partidas.ToList(), subPresupuestos.ToList());


            return View(RequerimientoViewModels);
        }

        // GET: /RequerimientoViewModel/Details/5
        public ActionResult Details(int? id)
        {

            return View();
        }

        // GET: /RequerimientoViewModel/Create/1
        public ActionResult Create(int? id)
        {


            var obras = db.Obras;

            var materiales = db.Materiales.Where(p => p.tipoMaterialId == id);

   

            var prioridades = db.Prioridad;

            var requerimientos = db.Requerimientos;

            var tipoCompra = db.TipoCompra.Find(id);


            var partidas = db.Partida;

            var subPresupuestos = db.SubPresupuesto;

            var RequerimientoViewModels = new RequerimientoViewModel(obras.ToList(), materiales.ToList(), prioridades.ToList(), requerimientos.ToList(), tipoCompra, partidas.ToList(), subPresupuestos.ToList());


            return View(RequerimientoViewModels);

        }

        public ActionResult Edit(int? id)
        {

            var obras = db.Obras;

            var prioridades = db.Prioridad;

            var requerimientos = db.Requerimientos.Where(p => p.requerimientoId == id).Single();


            //var estadoDetalle = db.EstadoRequerimientoDetalle.Where(p => p.nombre == "Sin Aprobación").SingleOrDefault();
            //var requerimientos = db.Requerimientos.Where(p => p.requerimientoId == id).Select(c => c.Detalles.Where(d => d.EstadoRequerimientoDetalle == estadoDetalle));

            
            // aqui

            var estadoRequerimientoDetalle = db.EstadoRequerimientoDetalle.Where(p => p.nombre == "Sin Aprobación").FirstOrDefault(); ;

            //var requerimiento = db.Requerimientos.Single(p => p.requerimientoId == id);

            requerimientos.Detalles = requerimientos.Detalles.Where(p => p.estadoRequerimientoDetalleId == estadoRequerimientoDetalle.estadoRequerimientoDetalleId).ToList();


            // fin aqui



           // var materiales = db.Materiales.Where(p => p.tipoMaterialId == requerimientos.FirstOrDefault().tipoCompraId);

            var materiales = db.Materiales.Where(p => p.tipoMaterialId == requerimientos.tipoCompraId);

            //var tipoCompra = db.TipoCompra.Where(p => p.tipoCompraId == requerimientos.FirstOrDefault().tipoCompraId).FirstOrDefault();

            var tipoCompra = db.TipoCompra.Where(p => p.tipoCompraId == requerimientos.tipoCompraId).FirstOrDefault();


            var partidas = db.Partida;

            var subPresupuestos = db.SubPresupuesto;

            //var RequerimientoViewModels = new RequerimientoViewModel(obras.ToList(), materiales.ToList(), prioridades.ToList(), requerimientos.ToList(), tipoCompra, partidas.ToList(), subPresupuestos.ToList());

            List<Requerimiento> reqs = new List<Requerimiento>();
            reqs.Add(requerimientos);
            var RequerimientoViewModels = new RequerimientoViewModel(obras.ToList(), materiales.ToList(), prioridades.ToList(), reqs, tipoCompra, partidas.ToList(), subPresupuestos.ToList());

            return View(RequerimientoViewModels);

        }


        [HttpPost]
        public ActionResult CrearRequerimiento(Requerimiento requerimiento)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid)
            {

                var estado = db.EstadoRequerimiento.Where(p => p.nombre == "Pendiente Aprobación").SingleOrDefault();
                var estadoDetalle = db.EstadoRequerimientoDetalle.Where(p => p.nombre == "Sin Aprobación").SingleOrDefault();
                DateTime timeUtc = DateTime.UtcNow;
                TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
                DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);

                requerimiento.fechaCreacion = cstTime;
                requerimiento.usuarioCreacion = User.Identity.Name;
                requerimiento.fechaModificacion = cstTime;
                requerimiento.EstadoRequerimiento = estado;

                db.Requerimientos.Add(requerimiento);
                //db.SaveChanges();


                foreach (var item in requerimiento.Detalles)
                {
                    item.estadoRequerimientoDetalleId = estadoDetalle.estadoRequerimientoDetalleId;
                    db.RequerimientoDetalles.Add(item);

                    var requerimientoDetalleEstadoRequerimientoDetalle = new RequerimientoDetalleEstadoRequerimientoDetalle();
                    requerimientoDetalleEstadoRequerimientoDetalle.RequerimientoDetalle = item;
                    requerimientoDetalleEstadoRequerimientoDetalle.estadoRequerimientoDetalleId = estadoDetalle.estadoRequerimientoDetalleId;
                    requerimientoDetalleEstadoRequerimientoDetalle.usuarioCreacion = User.Identity.Name;
                    requerimientoDetalleEstadoRequerimientoDetalle.fechaCreacion = cstTime;

                    db.RequerimientoDetalleEstadoRequerimientoDetalle.Add(requerimientoDetalleEstadoRequerimientoDetalle);
                }

                var requerimientoEstado = new RequerimientoEstadoRequerimiento();
                requerimientoEstado.Requerimiento = requerimiento;
                
                
                requerimientoEstado.estadoRequerimientoId = estado.estadoRequerimientoId;
                requerimientoEstado.usuarioCreacion = User.Identity.Name;
                requerimientoEstado.fechaCreacion = cstTime;

                db.RequerimientoEstadoRequerimiento.Add(requerimientoEstado);



                db.SaveChanges();



                //return View("Index");  
                //return RedirectToAction("Index/" + requerimiento.tipoCompraId);
                return RedirectToAction("Index");
            }

            return View(requerimiento);
        }


        [HttpPost]
        public ActionResult EditarRequerimiento(Requerimiento requerimiento)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid)
            {
                Requerimiento Requerimiento = db.Requerimientos.Find(requerimiento.requerimientoId);
                

                var estado = db.EstadoRequerimiento.Where(p => p.nombre == "Pendiente Aprobación").SingleOrDefault();
                var estadoDetalle = db.EstadoRequerimientoDetalle.Where(p => p.nombre == "Sin Aprobación").SingleOrDefault();
                DateTime timeUtc = DateTime.UtcNow;
                TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
                DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);

                //Actualiza Datos Requerimiento Existente
                Requerimiento.obraId = requerimiento.obraId;
                Requerimiento.prioridadId = requerimiento.prioridadId;
                Requerimiento.comentario = requerimiento.comentario;
                Requerimiento.fechaModificacion = cstTime;
                Requerimiento.EstadoRequerimiento = estado;

                //db.Requerimientos.Add(requerimiento);


                foreach (var item in Requerimiento.Detalles.Where(p => p.EstadoRequerimientoDetalle.descripcion == "Sin Aprobación").Where(p => p.requerimientoId == requerimiento.requerimientoId).ToList())
                {
                    var req = item;
                    foreach (var item2 in item.RequerimientoDetalleEstadosRequerimientoDetalle.ToList())
                    {
                        var reqDetalleEstado = item2;
                        db.RequerimientoDetalleEstadoRequerimientoDetalle.Remove(reqDetalleEstado);

                    }

                    db.RequerimientoDetalles.Remove(req);
                }


                //db.RequerimientoDetalles.RemoveRange(db.RequerimientoDetalles.Where(p => p.EstadoRequerimientoDetalle.descripcion == "Sin Aprobación").Where(p => p.requerimientoId == requerimiento.requerimientoId));


                foreach (var item in requerimiento.Detalles)
                {
                    item.estadoRequerimientoDetalleId = estadoDetalle.estadoRequerimientoDetalleId;
                    item.requerimientoId = requerimiento.requerimientoId;
                    db.RequerimientoDetalles.Add(item);

                    var requerimientoDetalleEstadoRequerimientoDetalle = new RequerimientoDetalleEstadoRequerimientoDetalle();
                    requerimientoDetalleEstadoRequerimientoDetalle.RequerimientoDetalle = item;
                    requerimientoDetalleEstadoRequerimientoDetalle.estadoRequerimientoDetalleId = estadoDetalle.estadoRequerimientoDetalleId;
                    requerimientoDetalleEstadoRequerimientoDetalle.usuarioCreacion = User.Identity.Name;
                    requerimientoDetalleEstadoRequerimientoDetalle.fechaCreacion = cstTime;

                    db.RequerimientoDetalleEstadoRequerimientoDetalle.Add(requerimientoDetalleEstadoRequerimientoDetalle);

                }

                //foreach (var item in requerimiento.Detalles)
                //{

                //    var requerimientoDetalleEstadoRequerimientoDetalle = new RequerimientoDetalleEstadoRequerimientoDetalle();
                //    requerimientoDetalleEstadoRequerimientoDetalle.RequerimientoDetalle = item;
                //    requerimientoDetalleEstadoRequerimientoDetalle.estadoRequerimientoDetalleId = estadoDetalle.estadoRequerimientoDetalleId;
                //    requerimientoDetalleEstadoRequerimientoDetalle.usuarioCreacion = User.Identity.Name;
                //    requerimientoDetalleEstadoRequerimientoDetalle.fechaCreacion = cstTime;

                //    db.RequerimientoDetalleEstadoRequerimientoDetalle.Add(requerimientoDetalleEstadoRequerimientoDetalle);
                //}




                

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
                catch (Exception ex)
                {





                }



                //return View("Index");  
                //return RedirectToAction("Index/" + requerimiento.tipoCompraId);
                return RedirectToAction("Index");
            }

            return View(requerimiento);
        }


        [HttpPost]
        public ActionResult CrearReq()
        {
            if (ModelState.IsValid)
            {


               
            }

            return View();
        }




        
    }
}
