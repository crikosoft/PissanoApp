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
            return View();
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


            var RequerimientoViewModels = new RequerimientoViewModel(obras.ToList(), materiales.ToList(), prioridades.ToList());


            return View(RequerimientoViewModels);

        }

        // POST: /RequerimientoViewModel/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="requerimientoViewModelId")] RequerimientoViewModel requerimientoviewmodel)
        {


            return View(requerimientoviewmodel);
        }

        // GET: /RequerimientoViewModel/Edit/5
        public ActionResult Edit(int? id)
        {

            return View();
        }

        // POST: /RequerimientoViewModel/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="requerimientoViewModelId")] RequerimientoViewModel requerimientoviewmodel)
        {
           
            return View(requerimientoviewmodel);
        }

        // GET: /RequerimientoViewModel/Delete/5
        public ActionResult Delete(int? id)
        {
            
            return View();
        }

        // POST: /RequerimientoViewModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
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
