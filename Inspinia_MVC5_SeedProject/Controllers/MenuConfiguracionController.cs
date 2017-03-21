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
    public class MenuConfiguracionController : Controller
    {

        private PissanoContext db = new PissanoContext();

        public ActionResult Empresa()
        {
            return View(db.Empresas.ToList());
        }


        public ActionResult Obra()
        {
            var obras = db.Obras.Include(o => o.empresa);
            return View(obras.ToList());
        }

	}
}