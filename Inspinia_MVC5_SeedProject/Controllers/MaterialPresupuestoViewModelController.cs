using PissanoApp.Models;
using PissanoApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PissanoApp.Controllers
{
    public class MaterialPresupuestoViewModelController : Controller
    {

        private PissanoContext db = new PissanoContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {

            var materialesPadres = db.Materiales.Where(p => p.MaterialPadre == null);

            var categoriasPadres = db.Categoria.Where(p => p.categoriaPadreId == null);


            //var materiales = db.Materiales.Include(m => m.TipoMaterial).Include(m => m.UnidadMedida).Where(p => p.nombre.ToLower().Contains(searchText));

            var presupuestoViewModel = new MaterialPresupuestoViewModel(materialesPadres.ToList(), categoriasPadres.ToList());


            return View(presupuestoViewModel);
        }

	}
}