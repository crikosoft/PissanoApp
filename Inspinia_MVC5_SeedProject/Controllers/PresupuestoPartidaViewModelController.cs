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

namespace PissanoApp.Controllers
{
    public class PresupuestoPartidaViewModelController : Controller
    {
        private PissanoContext db = new PissanoContext();

        // GET: /PresupuestoPartidaViewModel/
        public ActionResult Index()
        {
            return View();
        }



        // GET: /PresupuestoPartidaViewModel/Create
        public ActionResult Create(int? id)
        {

            var partidas = db.Partida;

            var presupuesto = db.Presupuestos.Single(p => p.presupuestoId == id);


            var PresupuestoPartidaViewModels = new PresupuestoPartidaViewModel(partidas.ToList(), presupuesto);


            return View(PresupuestoPartidaViewModels);
        }




       
    }
}
