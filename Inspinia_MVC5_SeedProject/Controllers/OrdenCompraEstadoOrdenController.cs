using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PissanoApp.Models;

namespace PissanoApp.Controllers
{
    public class OrdenCompraEstadoOrdenController : Controller
    {
        private PissanoContext db = new PissanoContext();

        // GET: /OrdenCompraEstadoOrden/
        public ActionResult Index()
        {
            var ordencompraestadoorden = db.OrdenCompraEstadoOrden.Include(o => o.EstadoOrden).Include(o => o.OrdenCompra);
            return View(ordencompraestadoorden.ToList());
        }


    }
}
