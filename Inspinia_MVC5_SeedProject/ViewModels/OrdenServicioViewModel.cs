using PissanoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PissanoApp.ViewModels
{
    public class OrdenServicioViewModel
    {
        public int? ordenCompraViewModelId { get; set; }
        public List<FormaPago> FormasPago { get; set; }
        public List<Proveedor> Proveedores { get; set; }
        public Requerimiento Requerimiento { get; set; }
        public List<OrdenServicio> Ordenes { get; set; }
        public List<Moneda> Monedas { get; set; }
        public TipoCompra TipoCompra { get; set; }
        public List<TipoValorizacion> TipoValorizaciones { get; set; }


        public OrdenServicioViewModel(List<FormaPago> formasPago, List<Proveedor> proveedores, Requerimiento requerimiento, List<OrdenServicio> ordenes, List<Moneda> monedas, TipoCompra tipoCompra, List<TipoValorizacion> tipoValorizaciones)
        {
            FormasPago = formasPago;
            Proveedores = proveedores;
            Requerimiento = requerimiento;
            Ordenes = ordenes;
            Monedas = monedas;
            TipoCompra = tipoCompra;
            TipoValorizaciones = tipoValorizaciones;
        }
    }
}