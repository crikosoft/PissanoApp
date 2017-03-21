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
            ViewData["SubTitle"] = "Bienvenido al Sistema de Gestión de Compras de PISSANO ";
            ViewData["Message"] = "Nos encontramos en la etapa de Construcción";

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