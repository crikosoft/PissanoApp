using PissanoApp.Models;
using PissanoApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PissanoApp.Controllers
{
    public class PresupuestoViewModelController : Controller
    {
        
        private PissanoContext db = new PissanoContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(int? id)
        {
            Presupuesto customer = db.Presupuestos.Single(x => x.presupuestoId == id);
            var detalles = db.PresupuestoDetalles.Where(p => p.presupuestoId == id);
            var categorias = db.Categoria.Where(p => p.categoriaPadreId == null);

            var subCategorias = db.Categoria.Where(p => p.categoriaPadreId != null);


            //var materiales = db.Materiales.Include(m => m.TipoMaterial).Include(m => m.UnidadMedida).Where(p => p.nombre.ToLower().Contains(searchText));

            var presupuestoViewModel = new PresupuestoViewModel(customer, detalles.ToList(), categorias.ToList(), subCategorias.ToList());
            

            return View(presupuestoViewModel);
        }


        // POST: /Obra/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection Presupuesto)
        {


            //if (ModelState.IsValid)
            //{
            ////    db.Obras.Add(obra);
            ////    db.SaveChanges();
            ////    return RedirectToAction("Index");
            //}

            ////ViewBag.empresaId = new SelectList(db.Empresas, "empresaId", "nombre", obra.empresaId);
            //return View(presupuestoViewModel);
            return View();
        }

	}
}