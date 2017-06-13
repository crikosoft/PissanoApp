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

            var estadoRequerimientoDetalle = db.EstadoRequerimientoDetalle.Where(p => p.nombre == "Aprobado").SingleOrDefault(); ;

            var requerimiento = db.Requerimientos.Single(p => p.requerimientoId == id);

            requerimiento.Detalles = requerimiento.Detalles.Where(p => p.estadoRequerimientoDetalleId == estadoRequerimientoDetalle.estadoRequerimientoDetalleId).ToList();

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
                
                //Traer datos de parametros
                var paramtext = "OC";

                if (ordenCompra.Requerimiento.TipoCompra.nombre == "Materiales")
                {
                    if (ordenCompra.fechaCreacion != DateTime.MinValue)
                        paramtext = "OCE";
                }
                else if (ordenCompra.Requerimiento.TipoCompra.nombre == "SubContratos")
                {
                    paramtext = "OS";
                }

                var parametro = db.Parametro.Single(p => p.nombre == paramtext);


                string ceros = new String('0', 5 - parametro.ultimoNumero.ToString().Length);
                if (ordenCompra.Requerimiento.TipoCompra.nombre == "Materiales")
                {
                    ordenCompra.numero = "OC-" + ceros + (parametro.ultimoNumero + 1).ToString() + "-" + ordenCompra.Requerimiento.Obra.identificador;
                }
                else {
                    ordenCompra.numero = "OS-" + ceros + (parametro.ultimoNumero + 1).ToString() + "-" + ordenCompra.Requerimiento.Obra.identificador;
                }

                DateTime timeUtc = DateTime.UtcNow;
                TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
                DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);

                //Si es nuevo, no antiguo
                if (ordenCompra.fechaCreacion == DateTime.MinValue)
                    ordenCompra.fechaCreacion = cstTime;
                
                ordenCompra.usuarioCreacion = User.Identity.Name;
                ordenCompra.fechaModificacion = cstTime;
                //ordenCompra.igv = 10;
                //ordenCompra.total = 100;
                //ordenCompra.estadoOrdenId = 1;

                var cantidadDetallesConOc = 0;
                cantidadDetallesConOc = ordenCompra.Requerimiento.Detalles.Where(p => p.estadoRequerimientoDetalleId == 2).Count();
                if (cantidadDetallesConOc + ordenCompra.OrdenesCompraDetalles.Count() == ordenCompra.Requerimiento.Detalles.Count())
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

        // GET: /RequerimientoViewModel/Create
        public ActionResult Edit(int? id)
        {

            var formasPago = db.FormaPagos;
            var proveedores = db.Proveedores;

            var estadoRequerimientoDetalle = db.EstadoRequerimientoDetalle.Where(p => p.nombre == "Aprobado").SingleOrDefault();

            var ordenesCompra = db.Ordenes.Where(p => p.ordenCompraId == id).Single();

            var requerimiento = db.Requerimientos.Single(p => p.requerimientoId == ordenesCompra.requerimientoId);

            var estadosRequerimientoDetalle = new string[] { "Aprobado", "Con OC" };
        
            //var ordenes = db.Ordenes.Where(p => estadoList.Contains(p.EstadoOrden.nombre)).Include(o => o.EstadoOrden).Include(o => o.FormaPago).Include(o => o.Moneda).Include(o => o.Obra).Include(o => o.Proveedor).Include(o => o.Requerimiento);


            requerimiento.Detalles = requerimiento.Detalles.Where((p => estadosRequerimientoDetalle.Contains(p.EstadoRequerimientoDetalle.nombre))).ToList();


            var monedas = db.Monedas;

            var tipoCompra = db.TipoCompra.Find(requerimiento.tipoCompraId);

            List<OrdenCompra> oc = new List<OrdenCompra>();
            oc.Add(ordenesCompra);

            var OrdenCompraViewModels = new OrdenCompraViewModel(formasPago.ToList(), proveedores.ToList(), requerimiento, oc.ToList(), monedas.ToList(), tipoCompra);


            ViewBag.proveedor = new SelectList(db.Proveedores, "proveedorId", "razonSocial", ordenesCompra.proveedorId);
            ViewBag.formaPago = new SelectList(db.FormaPagos, "formapagoId", "nombre", ordenesCompra.formaPagoId);
            ViewBag.moneda = new SelectList(db.Monedas, "monedaId", "nombre", ordenesCompra.monedaId);


            return View(OrdenCompraViewModels);


        }


        [HttpPost]
        public ActionResult EditarOrdenCompra(OrdenCompra ordenCompra)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid)
            {

                // 0. Traer datos Orden Compra Original

                var OrdenCompraOriginal = db.Ordenes.Find(ordenCompra.ordenCompraId);

                // 0. Definición de variables
                DateTime timeUtc = DateTime.UtcNow;
                TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
                DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);

                var estadoReqDetalleOC = db.EstadoRequerimientoDetalle.Where(p => p.nombre == "Con OC").SingleOrDefault();
                var estadoReqDetalleApr = db.EstadoRequerimientoDetalle.Where(p => p.nombre == "Aprobado").SingleOrDefault();
                var estadoReqDetalleList = new string[] { "Con OC", "Aprobación 1", "Aprobado"};

                // 1. Elimina Orden Compra Detalles

                foreach (var item in OrdenCompraOriginal.OrdenesCompraDetalles.ToList())
                {
                    db.OrdenDetalles.Remove(item);
                }



                // 2. Agrega OC Detalles

                var total = 0.0;

                foreach (var item in ordenCompra.OrdenesCompraDetalles)
                {
                    item.ordenCompraId = ordenCompra.ordenCompraId;
                    item.estadoOrdenDetalleId = 1;
                    item.precioTotal = item.cantidad * item.precioUnitario;
                    total = total + item.cantidad * item.precioUnitario;
                    db.OrdenDetalles.Add(item);

                }



                // 3. Agrega OC Cabecera

                OrdenCompraOriginal.proveedorId = ordenCompra.proveedorId;
                OrdenCompraOriginal.formaPagoId = ordenCompra.formaPagoId;
                OrdenCompraOriginal.monedaId = ordenCompra.monedaId;
                OrdenCompraOriginal.comentario = ordenCompra.comentario;
                OrdenCompraOriginal.usuarioModificacion = User.Identity.Name;
                OrdenCompraOriginal.fechaModificacion = cstTime;
                OrdenCompraOriginal.adelanto = 1;
                OrdenCompraOriginal.subTotal = total;
                OrdenCompraOriginal.igv = total * 0.18;
                OrdenCompraOriginal.total = total + total * 0.18;
                OrdenCompraOriginal.estadoOrdenId = ordenCompra.estadoOrdenId;


                // 4. Agrega Estado - Orden Compras



                // 6. Actualiza Requerimiento

                var cantidadDetallesConOc = 0;
                //cantidadDetallesConOc = ordenCompra.Requerimiento.Detalles.Where(p => p.estadoRequerimientoDetalleId == estadoReqDetalleOC.estadoRequerimientoDetalleId).Count();
                cantidadDetallesConOc = OrdenCompraOriginal.Requerimiento.Detalles.Where(p => p.ordenCompraId != ordenCompra.ordenCompraId && p.EstadoRequerimientoDetalle.nombre != "Aprobado").Count();

                if (cantidadDetallesConOc + ordenCompra.OrdenesCompraDetalles.Count() == OrdenCompraOriginal.Requerimiento.Detalles.Count())
                {
                    OrdenCompraOriginal.Requerimiento.estadoRequerimientoId = 3; // OC total
                }
                else
                {
                    OrdenCompraOriginal.Requerimiento.estadoRequerimientoId = 2; // OC Parcial
                }


                // 5. Actualiza Requerimiento Detalle


                foreach (var item in OrdenCompraOriginal.Requerimiento.Detalles.Where(p => p.ordenCompraId == ordenCompra.ordenCompraId || p.EstadoRequerimientoDetalle.nombre == "Aprobado"))

                //foreach (var item in OrdenCompraOriginal.Requerimiento.Detalles)
                {
                    item.estadoRequerimientoDetalleId = estadoReqDetalleApr.estadoRequerimientoDetalleId;
                    item.ordenCompraId = null;
                    foreach (var item2 in OrdenCompraOriginal.OrdenesCompraDetalles)
                    {

                        if (item.requerimientoDetalleId == item2.ordenCompradetalleId)
                        {
                            item.estadoRequerimientoDetalleId = estadoReqDetalleOC.estadoRequerimientoDetalleId;
                            item.ordenCompraId = ordenCompra.ordenCompraId;
                        }

                    }
                }


                db.SaveChanges();
                return RedirectToAction("Index");


                
            }

            return View();
        }

	}
}