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
	}
}