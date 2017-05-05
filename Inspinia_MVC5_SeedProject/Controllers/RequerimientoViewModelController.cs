﻿using System;
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


        [HttpPost]
        public ActionResult CrearRequerimiento(Requerimiento requerimiento)
        {
            if (ModelState.IsValid)
            {

                requerimiento.estadoRequerimientoId = 1;
                requerimiento.fecha = DateTime.Today;


                db.Requerimientos.Add(requerimiento);
                //db.SaveChanges();


                foreach (var item in requerimiento.Detalles)
                {
                    db.RequerimientoDetalles.Add(item);
                }

                db.SaveChanges();



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
