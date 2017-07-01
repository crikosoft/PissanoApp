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
    public class ValorizacionController : Controller
    {
        private PissanoContext db = new PissanoContext();

        // GET: /Valorizacion/
        public ActionResult Index(int? id)
        {
            ViewBag.contratoId = id;
            var contrato = db.Contrato.Find(id);
            ViewBag.numero = contrato.OrdenCompra.numero;
            var valorizacion = db.Valorizacion.Where(a => a.contratoId == id).Include(v => v.Contrato).Include(v => v.EstadoValorizacion);
            return View(valorizacion.ToList());
        }

        // GET: /Valorizacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valorizacion valorizacion = db.Valorizacion.Find(id);
            if (valorizacion == null)
            {
                return HttpNotFound();
            }
            return View(valorizacion);
        }

        // GET: /Valorizacion/Create
        public ActionResult Create(int? id)
        {

            Valorizacion valorizacion = new Valorizacion();
            Contrato contrato = db.Contrato.Where(a => a.contratoId == id).FirstOrDefault();
            valorizacion.contratoId = contrato.contratoId;
            valorizacion.Contrato = contrato;

            ViewBag.contratoId = new SelectList(db.Contrato, "contratoId", "comentario");
            ViewBag.estadoValorizacionId = new SelectList(db.EstadosValorizacion, "estadoValorizacionId", "nombre");
            return View(valorizacion);
        }

        // POST: /Valorizacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="valorizacionId,contratoId,concepto,fechacierre,avanceMonto,avancePorc, avanceMetrado, estadoValorizacionId,usuarioCreacion,usuarioModificacion,fechaCreacion,fechaModificacion")] Valorizacion valorizacion)
        {
            if (ModelState.IsValid)
            {
                var estado = db.EstadosValorizacion.Where(p => p.nombre == "Pendiente de Aprobación").SingleOrDefault();
                DateTime timeUtc = DateTime.UtcNow;
                TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
                DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);

                Contrato contrato = db.Contrato.Find(valorizacion.contratoId);

                double? avance = 0;
                double? saldo = 0;
                if (contrato.avanceMonto > 0)
                    avance = contrato.avanceMonto;
                if (contrato.saldoMonto > 0)
                    saldo = contrato.saldoMonto;

                contrato.avanceMonto = avance + valorizacion.avanceMonto;
                contrato.saldoMonto = contrato.OrdenCompra.total - (avance + valorizacion.avanceMonto);

                valorizacion.EstadoValorizacion = estado;
                valorizacion.fechaCreacion = cstTime;
                valorizacion.usuarioCreacion = User.Identity.Name;
                valorizacion.fechaModificacion = cstTime;


                db.Entry(contrato).State = EntityState.Modified;
                db.Valorizacion.Add(valorizacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.contratoId = new SelectList(db.Contrato, "contratoId", "comentario", valorizacion.contratoId);
            ViewBag.estadoValorizacionId = new SelectList(db.EstadosValorizacion, "estadoValorizacionId", "nombre", valorizacion.estadoValorizacionId);
            return View(valorizacion);
        }

        // GET: /Valorizacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valorizacion valorizacion = db.Valorizacion.Find(id);
            if (valorizacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.contratoId = new SelectList(db.Contrato, "contratoId", "comentario", valorizacion.contratoId);
            ViewBag.estadoValorizacionId = new SelectList(db.EstadosValorizacion, "estadoValorizacionId", "nombre", valorizacion.estadoValorizacionId);
            return View(valorizacion);
        }

        // POST: /Valorizacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="valorizacionId,contratoId,concepto,fechacierre,avance,avancePorc,estadoValorizacionId,usuarioCreacion,usuarioModificacion,fechaCreacion,fechaModificacion")] Valorizacion valorizacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(valorizacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.contratoId = new SelectList(db.Contrato, "contratoId", "comentario", valorizacion.contratoId);
            ViewBag.estadoValorizacionId = new SelectList(db.EstadosValorizacion, "estadoValorizacionId", "nombre", valorizacion.estadoValorizacionId);
            return View(valorizacion);
        }

        // GET: /Valorizacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valorizacion valorizacion = db.Valorizacion.Find(id);
            if (valorizacion == null)
            {
                return HttpNotFound();
            }
            return View(valorizacion);
        }

        // POST: /Valorizacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Valorizacion valorizacion = db.Valorizacion.Find(id);
            db.Valorizacion.Remove(valorizacion);
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


        [HttpPost]
        public ActionResult CreateValorizacion(Valorizacion valorizacion)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid)
            {
                
                DateTime timeUtc = DateTime.UtcNow;
                TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
                DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);

                valorizacion.usuarioCreacion = User.Identity.Name;
                valorizacion.usuarioModificacion = User.Identity.Name;
                valorizacion.fechaCreacion = cstTime;
                valorizacion.fechaModificacion = cstTime;

                var estadoValorizacion = db.EstadosValorizacion.Where(p => p.nombre == "Pendiente de Aprobación").SingleOrDefault();
                valorizacion.estadoValorizacionId = estadoValorizacion.estadoValorizacionId;

                db.Valorizacion.Add(valorizacion);
                //db.SaveChanges();

                var totalAvanceMonto = 0.0;

                foreach (var item in valorizacion.ValorizacionDetalles)
                {
                    item.valorizacionId = valorizacion.valorizacionId;
                    totalAvanceMonto = totalAvanceMonto + item.avanceMonto;
                    item.usuarioCreacion = User.Identity.Name;
                    item.usuarioModificacion = User.Identity.Name;
                    item.fechaCreacion = cstTime;
                    item.fechaModificacion = cstTime;
                    db.ValorizacionDetalle.Add(item);

                }
                valorizacion.avanceMonto = totalAvanceMonto;


                var contrato = db.Contrato.Where(p => p.contratoId == valorizacion.contratoId).Single();

                contrato.avanceMonto = contrato.avanceMonto + valorizacion.avanceMonto;
                contrato.saldoMonto = contrato.saldoMonto - valorizacion.avanceMonto;
                contrato.usuarioModificacion = User.Identity.Name; ;
                contrato.fechaModificacion = cstTime;


                db.SaveChanges();
                return RedirectToAction("Index/" + contrato.contratoId);
            }

            return View();
        }


        //[HttpPost]
        ////[ValidateAntiForgeryToken]
        //public ActionResult Create2(Valorizacion valorizacion)
        //{
        //    var errors = ModelState.Values.SelectMany(v => v.Errors);

        //    //if (ModelState.IsValid)
        //    //{

        //    Valorizacion valorizacion = db.Valorizacion.Find(valorizacion.ordenServicioId);

        //    DateTime timeUtc = DateTime.UtcNow;
        //    TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
        //    DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);

        //    Valorizacion valorizacion2 = db.Valorizacion.Find(valorizacion.valorizacionId);
        //    valorizacion2.avancePorc = valorizacion.avancePorc;
        //    valorizacion2.avance = ordenServicio.total * valorizacion.avancePorc / 100;
        //    valorizacion2.estadoValorizacionId = 2;
        //    valorizacion2.usuarioModificacion = User.Identity.Name;
        //    valorizacion2.fechaModificacion = cstTime;

        //    ordenServicio.avance = ordenServicio.avance + valorizacion2.avance;
        //    ordenServicio.saldo = ordenServicio.saldo - valorizacion2.avance;
        //    ordenServicio.usuarioModificacion = User.Identity.Name;
        //    ordenServicio.fechaModificacion = cstTime;

        //    db.SaveChanges();

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbEntityValidationException ex)
        //    {
        //        StringBuilder sb = new StringBuilder();

        //        foreach (var failure in ex.EntityValidationErrors)
        //        {
        //            sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
        //            foreach (var error in failure.ValidationErrors)
        //            {
        //                sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
        //                sb.AppendLine();
        //            }
        //        }

        //        throw new DbEntityValidationException(
        //            "Entity Validation Failed - errors follow:\n" +
        //            sb.ToString(), ex
        //        ); // Add the original exception as the innerException
        //    }
        //    return RedirectToAction("IndexApprove");
        //    //}

        //    //return View(requerimiento);
        //}
    }
}
