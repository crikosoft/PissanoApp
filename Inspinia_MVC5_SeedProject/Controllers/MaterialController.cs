using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PissanoApp.Models;
using Microsoft.AspNet.Identity;
using System.Web.UI.WebControls;

namespace PissanoApp.Controllers
{
    public class MaterialController : Controller
    {
        private PissanoContext db = new PissanoContext();

        // GET: /Material/
        public ActionResult Index()
        {
            var materiales = db.Materiales.Include(m => m.MaterialPadre).Include(m => m.TipoMaterial).Include(m => m.UnidadMedida);
            ViewBag.tipoMaterialId = new SelectList(db.TipoMateriales, "nombre", "nombre");
            ViewBag.materialPadreId = new SelectList(db.Materiales.Where(a => a.materialPadreId == null),"nombre","nombre");
            
            return View(materiales.ToList());
        }

        // GET: /Material/
        public ActionResult Filter(string searchText)
        {
            if (String.IsNullOrEmpty(searchText))
                searchText = "";
            else
                searchText = searchText.ToLower();

            var materiales = db.Materiales.Include(m => m.TipoMaterial).Include(m => m.UnidadMedida).Include(m => m.MaterialNivelStocks).Where(p => p.nombre.ToLower().Contains(searchText));

            return View(materiales.ToList());

        }


        // GET: /Material/
        public ActionResult Inventory()
        {
            var materiales = db.Materiales.Where(m => m.TipoMaterial.nombre == "Materiales").Include(m => m.MaterialPadre).Include(m => m.TipoMaterial).Include(m => m.UnidadMedida).Include(m => m.MaterialNivelStocks);
//            var materiales = db.Materiales.Where(m => m.TipoMaterial.nombre == "Materiales").Include(m => m.MaterialPadre).Include(m => m.TipoMaterial).Include(m => m.UnidadMedida).Include(m => m.MaterialNivelStocks).Select(c => c.MaterialNivelStocks.Where(a => a.Almacen.Obra.nombre == "Barcelona"));
            ViewBag.obraId = new SelectList(db.Obras, "nombre", "nombre");
            return View(materiales.ToList());

        }
        // GET: /Material/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Material material = db.Materiales.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            return View(material);
        }

        // GET: /Material/Create
        public ActionResult Create()
        {

            ViewBag.materialPadreId = new SelectList(db.Materiales, "materialId", "nombre");
            ViewBag.tipoMaterialId = new SelectList(db.TipoMateriales, "tipoMaterialId", "nombre");
            ViewBag.unidadMedidaId = new SelectList(db.UnidadMedidas, "unidadMedidaId", "nombre");
            return View();
        }

        // POST: /Material/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="materialId,nombre,codigo,unidadMedidaId,tipoMaterialId,materialPadreId")] Material material)
        {
            if (ModelState.IsValid)
            {

                DateTime timeUtc = DateTime.UtcNow;
                TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
                DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);

                // Registrar Familia

                if (material.materialPadreId == null)
                {

                    var paramtext = "FAM-MATERIAL";

                    if (material.tipoMaterialId == 1) //1: Materiales, 2: Sibcontratos
                    {
                        paramtext = "FAM-MATERIAL";
                    }
                    else if (material.tipoMaterialId == 2)
                    {
                        paramtext = "FAM-SUBCONTR";
                    }

                    var parametro = db.Parametro.Single(p => p.nombre == paramtext);

                    string ceros = new String('0', 8 - (parametro.ultimoNumero + 1).ToString().Length -1);
                    if (material.tipoMaterialId == 1) //1: Materiales, 2: Sibcontratos
                    {
                        material.codigo = "2" + ceros + (parametro.ultimoNumero + 1).ToString();
                    }
                    else if (material.tipoMaterialId == 2)
                    {
                        material.codigo = "5" + ceros + (parametro.ultimoNumero + 1).ToString();
                    }

                    parametro.ultimoNumero = parametro.ultimoNumero + 1;

                    //Fin registrar familia
                }
                else {

                    var materialeshijos = db.Materiales.Where(p => p.materialPadreId == material.materialPadreId);

                    var materialpadre = db.Materiales.Find(material.materialPadreId);
                    string ceros = new String('0', 4 - (materialeshijos.Count()+1).ToString().Length);
                    material.codigo = materialpadre.codigo + "-" + ceros + (materialeshijos.Count() + 1).ToString();

                }



                material.fechaCreacion = cstTime;
                material.usuarioCreacion = User.Identity.Name;
                material.fechaModificacion = cstTime;

                db.Materiales.Add(material);

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.materialPadreId = new SelectList(db.Materiales, "materialId", "nombre", material.materialPadreId);
            ViewBag.tipoMaterialId = new SelectList(db.TipoMateriales, "tipoMaterialId", "nombre", material.tipoMaterialId);
            ViewBag.unidadMedidaId = new SelectList(db.UnidadMedidas, "unidadMedidaId", "nombre", material.unidadMedidaId);
            return View(material);
        }

        // GET: /Material/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Material material = db.Materiales.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            ViewBag.materialPadreId = new SelectList(db.Materiales, "materialId", "nombre", material.materialPadreId);
            ViewBag.tipoMaterialId = new SelectList(db.TipoMateriales, "tipoMaterialId", "nombre", material.tipoMaterialId);
            ViewBag.unidadMedidaId = new SelectList(db.UnidadMedidas, "unidadMedidaId", "nombre", material.unidadMedidaId);
            return View(material);
        }

        // POST: /Material/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="materialId,nombre,codigo,unidadMedidaId,tipoMaterialId,materialPadreId")] Material material)
        {
            if (ModelState.IsValid)
            {

                DateTime timeUtc = DateTime.UtcNow;
                TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
                DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);


                //material.fechaCreacion = cstTime;
                //material.usuarioCreacion = User.Identity.Name;
                material.fechaModificacion = cstTime;
                material.usuarioModificacion = User.Identity.Name;


                var materialoriginal = db.Materiales.AsNoTracking().Where( a=> a.materialId==material.materialId).FirstOrDefault();

                if (materialoriginal.materialPadreId != material.materialPadreId)
                { 
                // Logica de reenumeración

                    if (material.materialPadreId == null)
                    {

                        var paramtext = "FAM-MATERIAL";

                        if (material.tipoMaterialId == 1) //1: Materiales, 2: Sibcontratos
                        {
                            paramtext = "FAM-MATERIAL";
                        }
                        else if (material.tipoMaterialId == 2)
                        {
                            paramtext = "FAM-SUBCONTR";
                        }

                        var parametro = db.Parametro.Single(p => p.nombre == paramtext);

                        string ceros = new String('0', 8 - (parametro.ultimoNumero + 1).ToString().Length-1);
                        if (material.tipoMaterialId == 1) //1: Materiales, 2: Sibcontratos
                        {
                            material.codigo = "2" + ceros + (parametro.ultimoNumero + 1).ToString();
                        }
                        else if (material.tipoMaterialId == 2)
                        {
                            material.codigo = "5" + ceros + (parametro.ultimoNumero + 1).ToString();
                        }

                        parametro.ultimoNumero = parametro.ultimoNumero + 1;

                        //Fin registrar familia
                    }
                    else
                    {
                        // Aplica cuando 
                        // Si Cambio es de Familia a Material && la familia no tiene hijos.
                        // Si Cambio es de Material a Material 
                        if (materialoriginal.materialPadreId != null || (materialoriginal.materialPadreId == null && db.Materiales.Where(a => a.materialPadreId == materialoriginal.materialId).Count() == 0))
                        {
                            var materialeshijos = db.Materiales.Where(p => p.materialPadreId == material.materialPadreId);

                            var materialpadre = db.Materiales.Find(material.materialPadreId);
                            string ceros = new String('0', 4 - (materialeshijos.Count() + 1).ToString().Length);
                            material.codigo = materialpadre.codigo + "-" + ceros + (materialeshijos.Count() + 1).ToString();

                        }
                        else
                        {
                            material.materialPadreId = materialoriginal.materialPadreId;
                        }
                    }
                }

                db.Entry(material).State = EntityState.Modified;

                db.Entry(material).Property(x => x.fechaCreacion).IsModified = false;
                db.Entry(material).Property(x => x.usuarioCreacion).IsModified = false;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.materialPadreId = new SelectList(db.Materiales, "materialId", "nombre", material.materialPadreId);
            ViewBag.tipoMaterialId = new SelectList(db.TipoMateriales, "tipoMaterialId", "nombre", material.tipoMaterialId);
            ViewBag.unidadMedidaId = new SelectList(db.UnidadMedidas, "unidadMedidaId", "nombre", material.unidadMedidaId);
            return View(material);
        }

        // GET: /Material/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Material material = db.Materiales.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            return View(material);
        }

        // POST: /Material/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Material material = db.Materiales.Find(id);
            db.Materiales.Remove(material);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
