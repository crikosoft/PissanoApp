﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PissanoApp.Controllers
{
    public class OrdenCompraController : Controller
    {
        //
        // GET: /OrdenCompra/
        public ActionResult Index()
        {
            return View();
        }

        // GET: /OrdenCompra/
        public ActionResult Approve()
        {
            return View();
        }

        //
        // GET: /OrdenCompra/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /OrdenCompra/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /OrdenCompra/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /OrdenCompra/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /OrdenCompra/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /OrdenCompra/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /OrdenCompra/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
