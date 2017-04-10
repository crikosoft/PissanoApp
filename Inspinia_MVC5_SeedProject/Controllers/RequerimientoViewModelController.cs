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
    public class RequerimientoViewModelController : Controller
    {
        private PissanoContext db = new PissanoContext();

        // GET: /RequerimientoViewModel/
        public ActionResult Index()
        {
            var obras = db.Obras;

            var materiales = db.Materiales;

            var prioridades = db.Prioridad;

            var requerimientos = db.Requerimientos.OrderByDescending(p => p.requerimientoId);


            var RequerimientoViewModels = new RequerimientoViewModel(obras.ToList(), materiales.ToList(), prioridades.ToList(), requerimientos.ToList());


            return View(RequerimientoViewModels);
        }

        // GET: /RequerimientoViewModel/Details/5
        public ActionResult Details(int? id)
        {

            return View();
        }

        // GET: /RequerimientoViewModel/Create
        public ActionResult Create()
        {


            var obras = db.Obras;

            var materiales = db.Materiales;

            var prioridades = db.Prioridad;

            var requerimientos = db.Requerimientos;


            var RequerimientoViewModels = new RequerimientoViewModel(obras.ToList(), materiales.ToList(), prioridades.ToList(), requerimientos.ToList());


            return View(RequerimientoViewModels);

        }


        [HttpPost]
        public ActionResult CrearRequerimiento(Requerimiento requerimiento)
        {
            if (ModelState.IsValid)
            {

                requerimiento.ordenGenerada = false;
                requerimiento.fecha = DateTime.Today;


                db.Requerimientos.Add(requerimiento);
                //db.SaveChanges();


                foreach (var item in requerimiento.Detalles)
                {
                    db.RequerimientoDetalles.Add(item);
                }

                db.SaveChanges();



                //return View("Index");  
                return RedirectToAction("Index");
            }

            return View();
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
