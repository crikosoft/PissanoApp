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

        public ActionResult Index(int? id)
        {
            var formasPago = db.FormaPagos;

            var proveedores = db.Proveedores;


//            var requerimiento = db.Requerimientos.Single(p => p.requerimientoId == 11);
//            var requerimiento = db.Requerimientos.First();

             Requerimiento req = new Requerimiento();

             var requerimiento = req;

            var ordenesCompra = db.Ordenes.Where(p => p.Requerimiento.tipoCompraId == id);

            var tipoCompra = db.TipoCompra.Find(id);

            var monedas = db.Monedas;

            var OrdenCompraViewModels = new OrdenCompraViewModel(formasPago.ToList(), proveedores.ToList(), requerimiento, ordenesCompra.ToList(), monedas.ToList(), tipoCompra);


            return View(OrdenCompraViewModels);
        }


        //public ActionResult IndexApprove()
        //{
        //    var formasPago = db.FormaPagos;

        //    var proveedores = db.Proveedores;

        //    var requerimiento = db.Requerimientos.Single(p => p.requerimientoId == 1);

        //    var ordenesCompra = db.Ordenes;

        //    var monedas = db.Monedas;

        //    var OrdenCompraViewModels = new OrdenCompraViewModel(formasPago.ToList(), proveedores.ToList(), requerimiento, ordenesCompra.ToList(), monedas.ToList());


        //    return View(OrdenCompraViewModels);
        //}



        // GET: /RequerimientoViewModel/Create
        public ActionResult Create(int? id)
        {



            var formasPago = db.FormaPagos;

            var proveedores = db.Proveedores;

            var requerimiento = db.Requerimientos.Single(p => p.requerimientoId == id);

            requerimiento.Detalles =  requerimiento.Detalles.Where(p => p.estadoRequerimientoDetalleId == 1).ToList();

            var ordenesCompra = db.Ordenes;

            var monedas = db.Monedas;

            var tipoCompra = db.TipoCompra.Find(requerimiento.tipoCompraId);

            var OrdenCompraViewModels = new OrdenCompraViewModel(formasPago.ToList(), proveedores.ToList(), requerimiento, ordenesCompra.ToList(), monedas.ToList(), tipoCompra);


            return View(OrdenCompraViewModels);

        
        }

        [HttpPost]
        public ActionResult CrearOrdenCompra(OrdenCompra ordenCompra)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid)
            {
                ordenCompra.Requerimiento = db.Requerimientos.Single(p => p.requerimientoId == ordenCompra.requerimientoId);
                //ordenCompra.numero = "OC-" + ordenCompra.Requerimiento.requerimientoId.ToString() + "-"+ ordenCompra.OrdenesCompraDetalles[0].materialId;
                var parametro = db.Parametro.Single(p => p.nombre=="OC");

                string ceros = new String('0', 5 - parametro.ultimoNumero.ToString().Length);
                ordenCompra.numero = "OC-" + ceros + (parametro.ultimoNumero + 1).ToString() + "-" + ordenCompra.Requerimiento.Obra.identificador;


                DateTime timeUtc = DateTime.UtcNow;
                TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
                DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);

                ordenCompra.fechaCreacion = cstTime;
                ordenCompra.usuarioCreacion = User.Identity.Name;
                ordenCompra.fechaModificacion = cstTime;
                //ordenCompra.igv = 10;
                //ordenCompra.total = 100;
                //ordenCompra.estadoOrdenId = 1;

                var cantidadDetalles = 0;
                cantidadDetalles = ordenCompra.Requerimiento.Detalles.Where(p => p.estadoRequerimientoDetalleId == 1).Count();
                if (cantidadDetalles == ordenCompra.OrdenesCompraDetalles.Count())
                {
                    ordenCompra.Requerimiento.estadoRequerimientoId = 3; // OC total
                }
                else
                {
                    ordenCompra.Requerimiento.estadoRequerimientoId = 2; // OC Parcial
                }


                // Actualiza estado de Requerimientos
                foreach (var item in ordenCompra.Requerimiento.Detalles)
                {
                    foreach (var item2 in ordenCompra.OrdenesCompraDetalles)
                    {
                        if (item.requerimientoDetalleId == item2.ordenCompradetalleId)
                        {
                            item.estadoRequerimientoDetalleId = 2;
                            item.ordenCompraId = ordenCompra.ordenCompraId;
                        }

                    }  
                }
                // Fin Actualiza estado Requerimientos

                

                ordenCompra.adelanto = 1;
                ordenCompra.obraId = ordenCompra.Requerimiento.obraId;

                db.Ordenes.Add(ordenCompra);
                //db.SaveChanges();
                
                var total=0.0;

                foreach (var item in ordenCompra.OrdenesCompraDetalles)
                {
                    item.ordenCompraId = ordenCompra.ordenCompraId;
                    item.estadoOrdenDetalleId = 1; 
                    item.precioTotal = item.cantidad * item.precioUnitario;
                    total = total + item.cantidad * item.precioUnitario;
                    db.OrdenDetalles.Add(item);

                }
                ordenCompra.subTotal = total;
                ordenCompra.igv = total*0.18;
                ordenCompra.total = total + total * 0.18;

                parametro.ultimoNumero = parametro.ultimoNumero + 1;

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

	}
}