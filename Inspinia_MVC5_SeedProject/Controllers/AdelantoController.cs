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
    public class AdelantoController : Controller
    {
        private PissanoContext db = new PissanoContext();

        // GET: /Adelanto/
        public ActionResult Index()
        {
            var adelanto = db.Adelanto.Include(a => a.Contrato).Include(a => a.EstadoAdelanto);
            return View(adelanto.ToList());
        }

        // GET: /Adelanto/
        public ActionResult IndexContrato(int? id)
        {
            //var adelanto = db.Adelanto.Include(a => a.Contrato).Include(a => a.EstadoAdelanto);
            var adelanto = db.Adelanto.Where(a => a.contratoId == id).Include(a => a.Contrato).Include(a => a.EstadoAdelanto);
            
            if (adelanto == null)
            {
                return HttpNotFound();
            }
            ViewBag.contratoId = id;
            return View(adelanto);

        }

        // GET: /Adelanto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adelanto adelanto = db.Adelanto.Find(id);
            if (adelanto == null)
            {
                return HttpNotFound();
            }
            return View(adelanto);
        }

        // GET: /Adelanto/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = db.Contrato.Find(id);
            Adelanto Adelanto = new Adelanto();
            Adelanto.contratoId = contrato.contratoId;
            Adelanto.Contrato = contrato;

            if (Adelanto == null)
            {
                return HttpNotFound();
            }


            ViewBag.contratoId = new SelectList(db.Contrato, "contratoId", "comentario");
            ViewBag.estadoAdelantoId = new SelectList(db.EstadoAdelanto, "estadoAdelantoId", "nombre");
            return View(Adelanto);
        }

        // POST: /Adelanto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="adelantoId,contratoId,descripcion,adelantoMonto,adelantoPorc,estadoAdelantoId,usuarioCreacion,usuarioModificacion,fechaCreacion,fechaModificacion")] Adelanto adelanto)
        {
            if (ModelState.IsValid)
            {
                db.Adelanto.Add(adelanto);
                db.SaveChanges();
                return RedirectToAction("IndexContrato/" + adelanto.contratoId, "Adelanto");
                //return RedirectToAction("Index");
            }

            ViewBag.contratoId = new SelectList(db.Contrato, "contratoId", "comentario", adelanto.contratoId);
            ViewBag.estadoAdelantoId = new SelectList(db.EstadoAdelanto, "estadoAdelantoId", "nombre", adelanto.estadoAdelantoId);

            
            return View(adelanto);
        }

        // GET: /Adelanto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adelanto adelanto = db.Adelanto.Find(id);
            if (adelanto == null)
            {
                return HttpNotFound();
            }
            ViewBag.contratoId = new SelectList(db.Contrato, "contratoId", "comentario", adelanto.contratoId);
            ViewBag.estadoAdelantoId = new SelectList(db.EstadoAdelanto, "estadoAdelantoId", "nombre", adelanto.estadoAdelantoId);
            return View(adelanto);
        }

        // POST: /Adelanto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="adelantoId,contratoId,descripcion,adelantoMonto,adelantoPorc,estadoAdelantoId,usuarioCreacion,usuarioModificacion,fechaCreacion,fechaModificacion")] Adelanto adelanto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adelanto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.contratoId = new SelectList(db.Contrato, "contratoId", "comentario", adelanto.contratoId);
            ViewBag.estadoAdelantoId = new SelectList(db.EstadoAdelanto, "estadoAdelantoId", "nombre", adelanto.estadoAdelantoId);
            return View(adelanto);
        }

        // GET: /Adelanto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adelanto adelanto = db.Adelanto.Find(id);
            if (adelanto == null)
            {
                return HttpNotFound();
            }
            return View(adelanto);
        }

        // POST: /Adelanto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adelanto adelanto = db.Adelanto.Find(id);
            db.Adelanto.Remove(adelanto);
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
