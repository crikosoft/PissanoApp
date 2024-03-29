﻿using PissanoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PissanoApp.ViewModels
{
    public class OrdenCompraViewModel
    {
        public int? ordenCompraViewModelId { get; set; }
        public List<FormaPago> FormasPago { get; set; }
        public List<Proveedor> Proveedores { get; set; }
        public Requerimiento Requerimiento { get; set; }
        public List<OrdenCompra> Ordenes { get; set; }
        public List<Moneda> Monedas { get; set; }
        public TipoCompra TipoCompra { get; set; }

        public OrdenCompraViewModel(List<FormaPago> formasPago, List<Proveedor> proveedores, Requerimiento requerimiento, List<OrdenCompra> ordenes, List<Moneda> monedas, TipoCompra tipoCompra)
        {
            FormasPago = formasPago;
            Proveedores = proveedores;
            Requerimiento = requerimiento;
            Ordenes = ordenes;
            Monedas = monedas;
            TipoCompra = tipoCompra;
        }
    }
}