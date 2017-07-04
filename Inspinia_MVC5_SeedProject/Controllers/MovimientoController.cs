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
    public class MovimientoController : Controller
    {
        private PissanoContext db = new PissanoContext();

        // GET: /Movimiento/
        public ActionResult Index()
        {
            var movimientoes = db.Movimiento.Include(m => m.MaterialNivelStock).Include(m => m.Partida).Include(m => m.TipoMovimientos);
            ViewBag.obraId = new SelectList(db.Obras, "nombre", "nombre");
            return View(movimientoes.ToList());
        }

        // GET: /Movimiento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movimiento movimiento = db.Movimiento.Find(id);
            if (movimiento == null)
            {
                return HttpNotFound();
            }
            return View(movimiento);
        }


        // GET: /Movimiento/Create
        public ActionResult CreateDefault()
        {
            ViewBag.materialNivelStockId = new SelectList(db.MaterialNivelStock, "materialNivelStockId", "materialNivelStockId");
            ViewBag.partidaId = new SelectList(db.Partida, "partidaId", "nombre");
            ViewBag.tipoMovimientoId = new SelectList(db.TipoMovimientos, "tipoMovimientoId", "nombre");
            return View();
        }

        // GET: /Movimiento/Create
        public ActionResult Create(int? id)
        {

            Movimiento Movimiento = new Movimiento();
            MaterialNivelStock MaterialNivelStock = db.MaterialNivelStock.Where(a => a.materialNivelStockId == id).FirstOrDefault();
            Movimiento.materialNivelStockId = MaterialNivelStock.materialNivelStockId;
            Movimiento.MaterialNivelStock = MaterialNivelStock;

            ViewBag.materialNivelStockId = new SelectList(db.MaterialNivelStock, "materialNivelStockId", "materialNivelStockId");
            ViewBag.partidaId = new SelectList(db.Partida, "partidaId", "nombre");
            ViewBag.tipoMovimientoId = new SelectList(db.TipoMovimientos, "tipoMovimientoId", "nombre");
            return View(Movimiento);
        }

        // POST: /Movimiento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="movimientoId,tipoMovimientoId,materialNivelStockId,cantidad,usuarioSolicitante,partidaId,comentario")] Movimiento movimiento)
        {
            if (ModelState.IsValid)
            {

                DateTime timeUtc = DateTime.UtcNow;
                TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
                DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);

                MaterialNivelStock materialNivelStock = db.MaterialNivelStock.Find(movimiento.materialNivelStockId);

                movimiento.usuarioCreacion = User.Identity.Name;
                movimiento.fechaCreacion = cstTime;

                //Actualiza datos en MaterialNivelStock
                movimiento.MaterialNivelStock = materialNivelStock;
                if (movimiento.tipoMovimientoId == 2) //2. Salida hacia Obra
                { 
                    movimiento.MaterialNivelStock.cantidad = materialNivelStock.cantidad - movimiento.cantidad;
                }
                else if (movimiento.tipoMovimientoId == 1) //1. Ingreso desde Obra
                {
                    movimiento.MaterialNivelStock.cantidad = materialNivelStock.cantidad + movimiento.cantidad;
                }
                movimiento.MaterialNivelStock.fechaStock = cstTime;

                db.Movimiento.Add(movimiento);
                db.SaveChanges();
                return RedirectToAction("Index", "MaterialNivelStock");
            }

            ViewBag.materialNivelStockId = new SelectList(db.MaterialNivelStock, "materialNivelStockId", "materialNivelStockId", movimiento.materialNivelStockId);
            ViewBag.partidaId = new SelectList(db.Partida, "partidaId", "nombre", movimiento.partidaId);
            ViewBag.tipoMovimientoId = new SelectList(db.TipoMovimientos, "tipoMovimientoId", "nombre", movimiento.tipoMovimientoId);
            return View(movimiento);
        }

        // GET: /Movimiento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movimiento movimiento = db.Movimiento.Find(id);
            if (movimiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.materialNivelStockId = new SelectList(db.MaterialNivelStock, "materialNivelStockId", "materialNivelStockId", movimiento.materialNivelStockId);
            ViewBag.partidaId = new SelectList(db.Partida, "partidaId", "nombre", movimiento.partidaId);
            ViewBag.tipoMovimientoId = new SelectList(db.TipoMovimientos, "tipoMovimientoId", "nombre", movimiento.tipoMovimientoId);
            return View(movimiento);
        }

        // POST: /Movimiento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="movimientoId,tipoMovimientoId,materialNivelStockId,cantidad,usuarioSolicitante,partidaId,comentario,usuarioCreacion,usuarioModificacion,fechaCreacion,fechaModificacion")] Movimiento movimiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movimiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.materialNivelStockId = new SelectList(db.MaterialNivelStock, "materialNivelStockId", "materialNivelStockId", movimiento.materialNivelStockId);
            ViewBag.partidaId = new SelectList(db.Partida, "partidaId", "nombre", movimiento.partidaId);
            ViewBag.tipoMovimientoId = new SelectList(db.TipoMovimientos, "tipoMovimientoId", "nombre", movimiento.tipoMovimientoId);
            return View(movimiento);
        }

        // GET: /Movimiento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movimiento movimiento = db.Movimiento.Find(id);
            if (movimiento == null)
            {
                return HttpNotFound();
            }
            return View(movimiento);
        }

        // POST: /Movimiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movimiento movimiento = db.Movimiento.Find(id);
            db.Movimiento.Remove(movimiento);
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
