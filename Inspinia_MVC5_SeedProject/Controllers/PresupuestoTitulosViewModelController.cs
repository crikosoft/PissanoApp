using PissanoApp.Models;
using PissanoApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PissanoApp.Controllers
{
    public class PresupuestoTitulosViewModelController : Controller
    {

        private PissanoContext db = new PissanoContext();

        //
        // GET: /PresupuestoTitulosViewModel/
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Create(int? id)
        {

            var titulos = db.Titulo;

            var presupuesto = db.Presupuestos.Single(p => p.presupuestoId == id);


            var PresupuestoTitulosViewModel = new PresupuestoTitulosViewModel(titulos.ToList(), presupuesto);


            return View(PresupuestoTitulosViewModel);
        }


        [HttpPost]
        public ActionResult Crear(PresupuestoTitulo presupuestoTitulo)
        {
            if (ModelState.IsValid)
            {
                db.PresupuestoTitulo.Add(presupuestoTitulo);
                db.SaveChanges();
                return RedirectToAction("Create/1");
            }

            return View(presupuestoTitulo);
        }

        [HttpPost]
        public ActionResult CrearLista(List<PresupuestoTitulo> presupuestoTitulos)
        {
            if (ModelState.IsValid)
            {
                
                //var presupuestoTits = new List<PresupuestoTitulo>();
                //foreach (var presupuestoTitulo in presupuestoTitulos)
                //{
                //    var presupuestoTit = new PresupuestoTitulo
                //    {
                //        presupuestoId = presupuestoTitulo.presupuestoId,
                //        tituloId = presupuestoTitulo.tituloId,
                //        orden = presupuestoTitulo.orden
                //    };

                //}

                foreach (var item in presupuestoTitulos)
                {
                    db.PresupuestoTitulo.Add(item);
                }
  
                db.SaveChanges();


                return RedirectToAction("Create/1");
            }

            return View(presupuestoTitulos);
        }
	}
}