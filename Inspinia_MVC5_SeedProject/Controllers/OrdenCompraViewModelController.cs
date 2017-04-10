using PissanoApp.Models;
using PissanoApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PissanoApp.Controllers
{
    public class OrdenCompraViewModelController : Controller
    {

        private PissanoContext db = new PissanoContext();
        
        // GET: /OrdenCompraViewModel/

        public ActionResult Index()
        {
            var formasPago = db.FormaPagos;

            var proveedores = db.Proveedores;

            var requerimiento = db.Requerimientos.Single(p => p.requerimientoId == 1);

            var ordenesCompra = db.Ordenes;

            var OrdenCompraViewModels = new OrdenCompraViewModel(formasPago.ToList(), proveedores.ToList(), requerimiento, ordenesCompra.ToList());


            return View(OrdenCompraViewModels);
        }

        // GET: /RequerimientoViewModel/Create
        public ActionResult Create(int? id)
        {



            var formasPago = db.FormaPagos;

            var proveedores = db.Proveedores;

            var requerimiento = db.Requerimientos.Single(p => p.requerimientoId == id);

            var ordenesCompra = db.Ordenes;

            var OrdenCompraViewModels = new OrdenCompraViewModel(formasPago.ToList(), proveedores.ToList(), requerimiento, ordenesCompra.ToList());


            return View(OrdenCompraViewModels);

        
        }

        [HttpPost]
        public ActionResult CrearOrdenCompra(OrdenCompra ordenCompra)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid)
            {
                ordenCompra.Requerimiento = db.Requerimientos.Single(p => p.requerimientoId == ordenCompra.requerimientoId);
                ordenCompra.numero = "OC-" + ordenCompra.Requerimiento.requerimientoId.ToString();
                ordenCompra.fecha = DateTime.Today;
                ordenCompra.igv = 10;
                ordenCompra.total = 100;
                ordenCompra.estadoOrdenId = 1;

                ordenCompra.Requerimiento.ordenGenerada = true;

                ordenCompra.adelanto = 1;
                ordenCompra.obraId = ordenCompra.Requerimiento.obraId;

                db.Ordenes.Add(ordenCompra);
                //db.SaveChanges();

                var igv=0.0;
                var total=0.0;

                foreach (var item in ordenCompra.OrdenesCompraDetalles)
                {
                    item.ordenCompraId = ordenCompra.ordenCompraId;
                    item.estadoOrdenDetalleId = 1;
                    item.precioTotal = item.cantidad * item.precioUnitario;
                    total = total + item.cantidad * item.precioUnitario;
                    db.OrdenDetalles.Add(item);

                }

                ordenCompra.igv = total*0.18;
                ordenCompra.total = total + total * 0.18;

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

	}
}