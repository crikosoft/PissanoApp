using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PissanoApp.Models;
using System.IO;


namespace PissanoApp.Controllers
{
    public class PagoController : Controller
    {
        private PissanoContext db = new PissanoContext();

        // GET: /Pago/
        public ActionResult Index()
        {

            //var estadoList = new string[] { "Pendiente de Pago", "Pago Realizado" };
            ViewBag.estadoPagoId = new SelectList(db.EstadosPago, "nombre", "nombre");
            ViewBag.obraId = new SelectList(db.Obras, "nombre", "nombre");

            var pagos = db.Pagos.Include(p => p.EstadoPago).Include(p => p.OrdenCompra).Include(p => p.TipoDetraccion).Include(p => p.TipoDocumento);
            return View(pagos.ToList());
        }

        // GET: /Pago/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pago pago = db.Pagos.Find(id);
            if (pago == null)
            {
                return HttpNotFound();
            }
            return View(pago);
        }

        // GET: /Pago/Create
        public ActionResult CreateDefault()
        {
            ViewBag.estadoOrdenId = new SelectList(db.EstadoOrdenes, "estadoOrdenId", "nombre");
            ViewBag.ordenCompraId = new SelectList(db.Ordenes, "ordenCompraId", "numero");
            ViewBag.tipoDetraccionId = new SelectList(db.TipoDetracciones, "tipoDetraccionId", "tipoBienServicio");
            ViewBag.tipoDocumentoId = new SelectList(db.TipoDocumentos, "tipoDocumentoId", "nombre");

            //var estado = db.EstadoOrdenes.Where(p => p.nombre == "Pendiente de Pago").SingleOrDefault();

            return View();
        }

        public ActionResult Create(int? id)
        {

            Pago Pago = new Pago();
            OrdenCompra OrdenCompra = db.Ordenes.Where(a => a.ordenCompraId == id).FirstOrDefault();
            Pago.ordenCompraId = OrdenCompra.ordenCompraId;
            Pago.OrdenCompra = OrdenCompra;

            ViewBag.estadoPagoId = new SelectList(db.EstadosPago, "estadoPagoId", "nombre");
            ViewBag.ordenCompraId = new SelectList(db.Ordenes, "ordenCompraId", "numero");
            ViewBag.tipoDetraccionId = new SelectList(db.TipoDetracciones, "tipoDetraccionId", "tipoBienServicio");
            ViewBag.tipoDocumentoId = new SelectList(db.TipoDocumentos, "tipoDocumentoId", "nombre");

            return View(Pago);
        }

        // POST: /Pago/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pagoId,ordenCompraId,tipoDocumentoId,numero,fechaPagoProg,fechaPagoReal,tipoDetraccionId,estadoPagoId,pagoMonto,preguntaPagoTotal,fechaFactura")] Pago pago)
        {
            if (ModelState.IsValid)
            {

                DateTime timeUtc = DateTime.UtcNow;
                TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
                DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);
                OrdenCompra ordenCompra = db.Ordenes.Find(pago.ordenCompraId);


                pago.fechaCreacion = cstTime;
                pago.usuarioCreacion = User.Identity.Name;

                //Actualiza datos en Orden de Compra

                var paramtext = "Pago Registrado";

                if (pago.estadoPagoId == 1) //1: Pendiente de Pago
                    paramtext = "Pago Registrado";
                else if (pago.estadoPagoId == 2 && pago.preguntaPagoTotal==true) // && Pago Completo ==true // 2 Pago Realizado
                    paramtext = "Pago Total";
                else if (pago.estadoPagoId == 2 && pago.preguntaPagoTotal == false) // && PacoCompleto ==false // 2 Pago Realizado
                    paramtext = "Pago Parcial";

                var estadoOrden = db.EstadoOrdenes.Single(p => p.nombre == paramtext);

                pago.OrdenCompra = ordenCompra;
                pago.OrdenCompra.estadoOrdenId = estadoOrden.estadoOrdenId;
                pago.OrdenCompra.usuarioModificacion = User.Identity.Name;
                pago.OrdenCompra.fechaModificacion = cstTime;
                

                // Guarda en Tabla Estados
                var ordenCompraEstado = new OrdenCompraEstadoOrden();
                ordenCompraEstado.ordenCompraId = ordenCompra.ordenCompraId;
                ordenCompraEstado.estadoOrdenId = estadoOrden.estadoOrdenId;
                ordenCompraEstado.usuarioCreacion = User.Identity.Name;
                ordenCompraEstado.fechaCreacion = cstTime;
                pago.OrdenCompra.OrdenCompraEstados.Add(ordenCompraEstado);

                // Calculo de Detracción
                 if (pago.tipoDetraccionId != null)
                 { 
                    TipoDetraccion tipoDetraccion = db.TipoDetracciones.Find(pago.tipoDetraccionId);
                    pago.pagoDetraccion = tipoDetraccion.porcentaje * pago.pagoMonto /100;
                    pago.pagoDetraccion = Math.Round((double)pago.pagoDetraccion, MidpointRounding.AwayFromZero);
                 }

                db.Pagos.Add(pago);
                db.SaveChanges();
                return RedirectToAction("Index", "Pago");
            }

            ViewBag.estadoPagoId = new SelectList(db.EstadosPago, "estadoPagoId", "nombre", pago.estadoPagoId);
            ViewBag.ordenCompraId = new SelectList(db.Ordenes, "ordenCompraId", "numero", pago.ordenCompraId);
            ViewBag.tipoDetraccionId = new SelectList(db.TipoDetracciones, "tipoDetraccionId", "tipoBienServicio", pago.tipoDetraccionId);
            ViewBag.tipoDocumentoId = new SelectList(db.TipoDocumentos, "tipoDocumentoId", "nombre", pago.tipoDocumentoId);
            return View(pago);
        }

        // GET: /Pago/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pago pago = db.Pagos.Find(id);
            if (pago == null)
            {
                return HttpNotFound();
            }



            OrdenCompra OrdenCompra = db.Ordenes.Where(a => a.ordenCompraId == pago.pagoId).FirstOrDefault();
            //Pago.ordenCompraId = OrdenCompra.ordenCompraId;
            //Pago.OrdenCompra = OrdenCompra;

            ViewBag.estadoPagoId = new SelectList(db.EstadosPago, "estadoPagoId", "nombre", pago.estadoPagoId);

            ViewBag.ordenCompraId = new SelectList(db.Ordenes, "ordenCompraId", "numero", pago.ordenCompraId);
            ViewBag.tipoDetraccionId = new SelectList(db.TipoDetracciones, "tipoDetraccionId", "tipoBienServicio", pago.tipoDetraccionId);
            ViewBag.tipoDocumentoId = new SelectList(db.TipoDocumentos, "tipoDocumentoId", "nombre", pago.tipoDocumentoId);


            return View(pago);

        }

        // POST: /Pago/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include="pagoId,ordenCompraId,tipoDocumentoId,numero,fechaPagoProg,fechaPagoReal,estadoOrdenId,pagoMonto,tipoDetraccionId,pagoDetraccion,asientoContable,fechaContable,usuarioCreacion,usuarioModificacion,fechaCreacion,fechaModificacion")] Pago pago)
        public ActionResult Edit([Bind(Include = "pagoId,ordenCompraId,tipoDocumentoId,numero,fechaPagoProg,fechaPagoReal,tipoDetraccionId,estadoPagoId,pagoMonto,preguntaPagoTotal,fechaFactura")] Pago pago)
        {
            if (ModelState.IsValid)
            {

                DateTime timeUtc = DateTime.UtcNow;
                TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
                DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);
                OrdenCompra ordenCompra = db.Ordenes.Find(pago.ordenCompraId);


                pago.fechaModificacion= cstTime;
                pago.usuarioModificacion = User.Identity.Name;


                //Actualiza datos en Orden de Compra

                var paramtext = "Pendiente de Pago";
               
                if (pago.estadoPagoId == 1) //1: Pendiente de Pago
                    paramtext = "Pago Registrado";
                else if (pago.estadoPagoId == 2 && pago.preguntaPagoTotal == true) // && Pago Completo ==true // 2 Pago Realizado
                    paramtext = "Pago Total";
                else if (pago.estadoPagoId == 2 && pago.preguntaPagoTotal == false) // && PacoCompleto ==false // 2 Pago Realizado
                    paramtext = "Pago Parcial";

                var estadoOrden = db.EstadoOrdenes.Single(p => p.nombre == paramtext);


                pago.OrdenCompra = ordenCompra;
                pago.OrdenCompra.estadoOrdenId = estadoOrden.estadoOrdenId;
                pago.OrdenCompra.usuarioModificacion = User.Identity.Name;
                pago.OrdenCompra.fechaModificacion = cstTime;

                // Guarda en Tabla Estados
                var ordenCompraEstado = new OrdenCompraEstadoOrden();
                ordenCompraEstado.ordenCompraId = ordenCompra.ordenCompraId;
                ordenCompraEstado.estadoOrdenId = estadoOrden.estadoOrdenId;
                ordenCompraEstado.usuarioCreacion = User.Identity.Name;
                ordenCompraEstado.fechaCreacion = cstTime;
                pago.OrdenCompra.OrdenCompraEstados.Add(ordenCompraEstado);

                // Calculo de Detracción
                if (pago.tipoDetraccionId != null)
                {
                    TipoDetraccion tipoDetraccion = db.TipoDetracciones.Find(pago.tipoDetraccionId);
                    pago.pagoDetraccion = tipoDetraccion.porcentaje * pago.pagoMonto / 100;
                    pago.pagoDetraccion = Math.Round((double)pago.pagoDetraccion, MidpointRounding.AwayFromZero);
                }

                db.Entry(pago).State = EntityState.Modified;
                db.Entry(pago).Property(x => x.fechaCreacion).IsModified = false;
                db.Entry(pago).Property(x => x.usuarioCreacion).IsModified = false;

                db.SaveChanges();
                return RedirectToAction("Index", "Pago");
            }
            ViewBag.estadoPagoId = new SelectList(db.EstadosPago, "estadoPagoId", "nombre", pago.estadoPagoId);
            ViewBag.ordenCompraId = new SelectList(db.Ordenes, "ordenCompraId", "numero", pago.ordenCompraId);
            ViewBag.tipoDetraccionId = new SelectList(db.TipoDetracciones, "tipoDetraccionId", "tipoBienServicio", pago.tipoDetraccionId);
            ViewBag.tipoDocumentoId = new SelectList(db.TipoDocumentos, "tipoDocumentoId", "nombre", pago.tipoDocumentoId);
            return View(pago);
        }

        // GET: /Pago/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pago pago = db.Pagos.Find(id);
            if (pago == null)
            {
                return HttpNotFound();
            }
            return View(pago);
        }

        // POST: /Pago/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pago pago = db.Pagos.Find(id);
            db.Pagos.Remove(pago);
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

        // GET: /Pago/
        public ActionResult IndexTelecredito()
        {

            var estadoList = new string[] { "Pendiente de Pago", "Pago Archivo Telecredito" };
            //ViewBag.estadoPagoId = new SelectList(db.EstadosPago, "estadoPagoId", "nombre");
            ViewBag.obraId = new SelectList(db.Obras, "nombre", "nombre");

            var pagos = db.Pagos.Where(p => estadoList.Contains(p.EstadoPago.nombre)).Include(p => p.EstadoPago).Include(p => p.OrdenCompra).Include(p => p.TipoDetraccion).Include(p => p.TipoDocumento);
            return View(pagos.ToList());
              
        }
        
        [HttpPost]
        public ActionResult GenerarTelecredito(List<Pago> pagos)
        {
            if (ModelState.IsValid)
            {
                DateTime timeUtc = DateTime.UtcNow;
                TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
                DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);

                //Cabecera Telecredito
                var cabecera = "";
                var detalle = "";
                var cabeceraDetalle = "";

                string cabPlanillaNueva ="#";
                string cabTipoRegistro ="1";
                string cabTipoPagoMasivo ="P";
                string cabTipoProducto ="C";
                string cabNroCuentaCorriente ="";
                string cabMoneda ="";
                string cabImporte ="";
                string cabFechaProcesar ="";
                string cabReferencia ="";
                string cabTotalControl ="";
                string cabNroTotalRegistros ="";
                string cabSubTipoPagoMasivo ="0";
                string cabVacio =" ";
                string cabIndicadorNotaCargo ="0";

                string detVacio =" ";
                string detTipoRegistro ="2";
                string detTipoProducto ="C";
                string detNroCuentaAbono ="";
                string detRazonSocialBenef ="";
                string detMoneda ="";
                string detImporteAbonar =""; //7
                string detTipoDocIdentidad ="RUC";
                string detNroDocIdentidad ="";
                string detTipoDocPagar ="F"; //10
                string detNroDocumentoPagar ="";
                string detTipoAbono ="2"; //12
                string detReferenciaAdicional ="";
                string detFlagNotaAbono ="0";
                string detFlagDelivery ="0";
                string detFlagValidaRUC ="0";
                string detDireccion =""; //17
                string detDistrito =""; 
                string detProvincia =""; //19
                string detDepartamento ="";
                string detContacto ="";


                //Cabecera

                 double? cabImporteDouble = 0;
                 foreach (var pago in pagos)
                 {
                     var Pago = db.Pagos.Find(pago.pagoId);
                     cabImporteDouble = cabImporteDouble + Pago.pagoMonto;
                 }
                 //cabImporte = string.Format("{0:0.00}", cabImporteDouble);
                 cabImporte = string.Format("{0:0}", cabImporteDouble * 100);
               
                 cabImporte = cabImporte.PadLeft(15,'0');

                cabFechaProcesar =cstTime.ToString("ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);
                cabReferencia = "Referencia Planilla";
                cabReferencia = cabReferencia.PadRight(20,' ');

                cabNroTotalRegistros = new String('0', 6-pagos.Count().ToString().Length)+ pagos.Count().ToString() ;
                cabVacio = cabVacio.PadRight(15, ' ');
                foreach (var pago in pagos)
                {
                    var Pago = db.Pagos.Find(pago.pagoId);
                    if (Pago.OrdenCompra.Moneda.nombre == "Soles")
                        cabMoneda = "S/";
                    else if (Pago.OrdenCompra.Moneda.nombre == "Dolares")
                        cabMoneda = "US";
                }

                if (cabMoneda == "S/")
                {
                    cabNroCuentaCorriente = "19302254551041";
                }
                else if (cabMoneda == "US")
                {
                    cabNroCuentaCorriente = "19302186463193";
                }
                cabNroCuentaCorriente = cabNroCuentaCorriente.ToString().PadRight(20, ' ');

                //CheckSum

                Int64 sumCabTotalControl = 0;
                sumCabTotalControl = Int64.Parse(cabNroCuentaCorriente.Trim().Substring(3, cabNroCuentaCorriente.Trim().Length - 3));
                foreach (var pago in pagos)
                {
                    //BCP mismo banco usd.txt
                    var Pago = db.Pagos.Find(pago.pagoId);
                    if (Pago.OrdenCompra.Proveedor.CuentasBancarias.Where(a => a.cuentaDefault == true).SingleOrDefault().Banco.nombre =="BCP")
                    { 
                        sumCabTotalControl = sumCabTotalControl + Int64.Parse(Pago.OrdenCompra.Proveedor.CuentasBancarias.Where(a => a.cuentaDefault == true).SingleOrDefault().numeroCuenta.Trim().Substring(3, Pago.OrdenCompra.Proveedor.CuentasBancarias.Where(a => a.cuentaDefault == true).SingleOrDefault().numeroCuenta.Trim().Length - 3));
                    }
                    else
                    {
                        sumCabTotalControl = sumCabTotalControl + Int64.Parse(Pago.OrdenCompra.Proveedor.CuentasBancarias.Where(a => a.cuentaDefault == true).SingleOrDefault().numeroCuenta.Trim().Substring(10, Pago.OrdenCompra.Proveedor.numeroCuenta.Trim().Length - 10));
                    }
                }
                cabTotalControl = sumCabTotalControl.ToString().PadLeft(15, '0'); // pendiente
                //Fin Check Sum

                cabecera = cabPlanillaNueva + cabTipoRegistro + cabTipoPagoMasivo + cabTipoProducto + cabNroCuentaCorriente + cabMoneda + cabImporte +cabFechaProcesar + cabReferencia + cabTotalControl + cabNroTotalRegistros + cabSubTipoPagoMasivo + cabVacio + cabIndicadorNotaCargo;
               
                //Detalle
                foreach (var pago in pagos)
                {
                    var Pago = db.Pagos.Find(pago.pagoId);
                    var estadoPago = db.EstadosPago.Single(p => p.nombre == "Pago Archivo Telecredito");
                    Pago.estadoPagoId = estadoPago.estadoPagoId;
                    detNroCuentaAbono = Pago.OrdenCompra.Proveedor.CuentasBancarias.Where(a => a.cuentaDefault == true).SingleOrDefault().numeroCuenta.Trim();
                    if (detNroCuentaAbono.Length ==13)
                    {
                        detNroCuentaAbono = detNroCuentaAbono.Substring(0, 3) + "0" + detNroCuentaAbono.Substring(3, 10);
                        detNroCuentaAbono = detNroCuentaAbono.PadRight(20, ' ');
                    }
                    else
                    {
                        detNroCuentaAbono = detNroCuentaAbono.PadRight(20, ' ');
                    }
                    detRazonSocialBenef = Pago.OrdenCompra.Proveedor.razonSocial.TrimStart().TrimEnd();
                    detRazonSocialBenef = detRazonSocialBenef.PadRight(40, ' ');
                    detRazonSocialBenef = detRazonSocialBenef.Substring(0, 40);

                    

                    //detRazonSocialBenef = detRazonSocialBenef.PadRight(40,' ');
                    if (Pago.OrdenCompra.Moneda.nombre == "Soles")
                        detMoneda = "S/";
                    else if (Pago.OrdenCompra.Moneda.nombre == "Dolares")
                        detMoneda = "US";

                    double? detImporteAbonarDouble = 0;
                    detImporteAbonarDouble = Pago.pagoMonto;
                    //detImporteAbonar = string.Format("{0:0,0.00}", detImporteAbonarDouble);                    
                    detImporteAbonar = string.Format("{0:0}", detImporteAbonarDouble * 100);
                    detImporteAbonar = detImporteAbonar.PadLeft(15, '0');
                    detNroDocIdentidad = Pago.OrdenCompra.Proveedor.ruc.TrimEnd();
                    detNroDocIdentidad = detNroDocIdentidad.PadRight(12, ' ');

                    detNroDocumentoPagar = Pago.numero.Substring(0,10);
                    detNroDocumentoPagar = detNroDocumentoPagar.PadLeft(10, '0');


                    detReferenciaAdicional = detReferenciaAdicional.PadRight(40, ' ');

                    detDireccion = Pago.OrdenCompra.Proveedor.direccion.TrimStart().TrimEnd();
                    detDireccion = detDireccion.PadRight(40, ' ');
                    detDireccion = detDireccion.Substring(0, 40);

                    //detDireccion = Pago.OrdenCompra.Proveedor.direccion.Trim();
                    //detDireccion = detDireccion.PadRight(40, ' ');

                    detDistrito = detDistrito.PadRight(20,' ');
                    detProvincia = detProvincia.PadRight(20, ' ');
                    detDepartamento = detDepartamento.PadRight(20, ' ');
                    detContacto = detContacto.PadRight(40, ' ');

                    detalle = detalle + "&" + detVacio + detTipoRegistro + detTipoProducto + detNroCuentaAbono + detRazonSocialBenef + detMoneda + detImporteAbonar + detTipoDocIdentidad + detNroDocIdentidad + detTipoDocPagar + detNroDocumentoPagar + detTipoAbono + detReferenciaAdicional + detFlagNotaAbono + detFlagDelivery + detFlagValidaRUC + detDireccion + detDistrito + detProvincia + detDepartamento + detContacto;

                }


                //string tipoRegistro = "1";
                //string cantidadAbonos = new String('0', 6-pagos.Count().ToString().Length)+ pagos.Count().ToString() ;
                //string fechaProceso = cstTime.ToString("yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                //string tipocuenta = "C";
                //string moneda = "";

                //foreach (var pago in pagos)
                //{
                //    var Pago = db.Pagos.Find(pago.pagoId);
                //    if (Pago.OrdenCompra.Moneda.nombre == "Soles")
                //    {
                //        moneda = "0001";
                //    }
                //    else
                //    {
                //        moneda = "1001";
                //    }
                //}

                 
                // string numeroCuentaCargo = "12345678912345678912";
                // string montoTotalPlanilla = "";
                // double? montoTotalPlanillaDouble = 0;
                // foreach (var pago in pagos)
                // {
                //     var Pago = db.Pagos.Find(pago.pagoId);
                //     montoTotalPlanillaDouble = montoTotalPlanillaDouble + Pago.pagoMonto;
                // }
                // montoTotalPlanilla = string.Format("{0:0,0.00}", montoTotalPlanillaDouble);
                // montoTotalPlanilla = montoTotalPlanilla.PadLeft(17,'0');

                // string referenciaPlanilla = "";
                // referenciaPlanilla = referenciaPlanilla.PadRight(40,'0');
                // string exoneracionITF = "N";
                // string totalControl = "1";
                // totalControl = totalControl.PadRight(15,'0');
                // cabecera = tipoRegistro + cantidadAbonos + fechaProceso + tipocuenta + moneda + numeroCuentaCargo + montoTotalPlanilla + referenciaPlanilla + exoneracionITF + totalControl;


                ////Fin Cabecera

                //// Inicio Detalle Proveedores
                // var detalleProveedores = "";
                // string tipoRegistroDet = "";
                // string tipCuentaAbonoDet = "";
                // string cuentaAbonoDet = "";
                // string modalidadPagoDet = "";
                // string tipoDocProvDet = "";
                // string nroDocProvDet = "";
                // string corrDocProvDet = "";
                // string nomProvDet = "";
                // string referenciaBenefDet = "";
                // string referenciaEmpDet = "";
                // string monedaImporteDet = "";
                // string importeDet = "";
                // string flagIDCDet = "";

                //// Inicio Detalle Documentos de Beneficiario
                // var detalleDocumentoBeneficiario = "";
                // string tipoRegistroDetBen = "";
                // string tipoDocPagarDetBen = "";
                // string nroDocPagarDetBen = "";
                // string importeDocPagarDetBen = "";


                //foreach (var pago in pagos)
                //{
                //    var Pago = db.Pagos.Find(pago.pagoId);
                //    var estadoPago = db.EstadosPago.Single(p => p.nombre == "Pago Archivo Telecredito");
                //    Pago.estadoPagoId = estadoPago.estadoPagoId;

                //    tipoRegistroDet = "2";
                //    tipCuentaAbonoDet = "C";
                //    cuentaAbonoDet = Pago.OrdenCompra.Proveedor.numeroCuenta;
                //    cuentaAbonoDet = cuentaAbonoDet.PadRight(20, ' ');
                //    modalidadPagoDet = "1";
                //    tipoDocProvDet = "6";

                //    nroDocProvDet = Pago.OrdenCompra.Proveedor.ruc;
                //    nroDocProvDet = nroDocProvDet.PadRight(12, ' ');

                //    corrDocProvDet = "";
                //    corrDocProvDet = corrDocProvDet.PadRight(3);

                //    nomProvDet = Pago.OrdenCompra.Proveedor.razonSocial;
                //    nomProvDet = nomProvDet.PadRight(75, ' ');

                //    referenciaBenefDet = Pago.numero;
                //    referenciaBenefDet = referenciaBenefDet.PadRight(40, ' ');

                //    referenciaEmpDet = Pago.OrdenCompra.numero;
                //    referenciaEmpDet = referenciaEmpDet.PadRight(20, ' ');

                //    if (Pago.OrdenCompra.Moneda.nombre == "Soles")
                //    {
                //        monedaImporteDet = "0001";
                //    }
                //    else if (Pago.OrdenCompra.Moneda.nombre == "Dolares")
                //    {
                //        monedaImporteDet = "1001";
                //    }
                //    double? importeDetDouble = 0;
                //    importeDetDouble = Pago.pagoMonto;

                //    importeDet = "";
                //    importeDet = string.Format("{0:0,0.00}", importeDetDouble);
                //    importeDet = importeDet.PadLeft(17, '0');

                //    flagIDCDet = "N";

                //    detalleProveedores = detalleProveedores + "&" + tipoRegistroDet + tipCuentaAbonoDet + cuentaAbonoDet + modalidadPagoDet + tipoDocProvDet + nroDocProvDet + corrDocProvDet + nomProvDet + referenciaBenefDet + referenciaEmpDet + monedaImporteDet + importeDet + flagIDCDet;


                //    //Documento Beneficiario
                //    tipoRegistroDetBen = "3";
                //    tipoDocPagarDetBen = "F";
                //    nroDocPagarDetBen = Pago.numero;
                //    nroDocPagarDetBen = nroDocPagarDetBen.PadRight(15, ' ');
                //    importeDocPagarDetBen = importeDet;

                //    detalleDocumentoBeneficiario = detalleDocumentoBeneficiario + "&" + tipoRegistroDetBen + tipoDocPagarDetBen + nroDocPagarDetBen + importeDocPagarDetBen;
                  //}

                //Guardar información Archivo en BD
                ArchivoTelecredito archivoTelecredito = new ArchivoTelecredito();
                var fileName = "Telecredito_" + cstTime.ToString("yyyyMMdd-HHmmss", System.Globalization.CultureInfo.InvariantCulture) + ".txt";

                archivoTelecredito.nombre = fileName;
                archivoTelecredito.ruta = fileName;
                archivoTelecredito.fechaCreacion = cstTime;
                archivoTelecredito.usuarioCreacion = User.Identity.Name;
                db.ArchivosTelecredito.Add(archivoTelecredito);


                //Create File
                var path = Path.Combine(Server.MapPath("~/FilesGenerated"), fileName );
                //file.SaveAs(path);

                //string path = @"C:\GitHub\MyTest.txt";
                FileStream fs = null;
                if (!System.IO.File.Exists(path))
                {
                    using (fs = System.IO.File.Create(path))
                    {
                        
                    }
                }
                //else
                //{
                using (StreamWriter sw = new StreamWriter(path))
                {

                    //sw.Write(cabecera);
                    // Uniendo cabecera y detalle 
                    cabeceraDetalle = cabecera + detalle;
                    string[] documentoPartes = cabeceraDetalle.Split('&');
                    foreach (string word in documentoPartes)
                    {
                        //Console.WriteLine(word);
                        sw.WriteLine(word);
                    }
                }
                //}

                //Actualiza Pago con numero de Archivo Generado
                 foreach (var pago in pagos)
                 {
                    var Pago = db.Pagos.Find(pago.pagoId);
                    Pago.archivoTelecreditoId = archivoTelecredito.archivoTelecreditoId;
                 }


                //Guardar Transacción
                db.SaveChanges();


                return RedirectToAction("IndexTelecredito");
            }
            var estadoList = new string[] { "Pendiente de Pago", "Pago Archivo Telecredito" };
            //ViewBag.estadoPagoId = new SelectList(db.EstadosPago, "estadoPagoId", "nombre");
            ViewBag.obraId = new SelectList(db.Obras, "nombre", "nombre");

            var pagosNew = db.Pagos.Where(p => estadoList.Contains(p.EstadoPago.nombre)).Include(p => p.EstadoPago).Include(p => p.OrdenCompra).Include(p => p.TipoDetraccion).Include(p => p.TipoDocumento);
            //.Include(v => v.EstadoPedido).Include(v => v.Ventas);
            return View(pagosNew.ToList());
        }
    }
}
