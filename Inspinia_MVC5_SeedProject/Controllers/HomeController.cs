using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PissanoApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["SubTitle"] = "Bienvenido al Sistema de Gestión de Compras PISSANO ";
            ViewData["Message"] = "1era Versión. Disponible con los módulos de Requerimiento, Aprobación de Requerimiento, Creación de Ordenes de Compra, Aprobaciones de Ordenes de Compra (Ing. Residente, Jefatura de Proyecto y Gerente General)";

            return View();
        }

        public ActionResult Minor()
        {
            ViewData["SubTitle"] = "Simple example of second view";
            ViewData["Message"] = "Data are passing to view by ViewData from controller";

            return View();
        }
    }
}