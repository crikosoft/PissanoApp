using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class IngresoDetalle
    {
        public int ingresoDetalleId { get; set; }
        public int ordenCompradetalleId { get; set; }
        public virtual OrdenCompraDetalle OrdenCompraDetalle { get; set; }
        public double cantidad { get; set; }
        public double avance { get; set; } //utilizado para ingreso de avance de servicios en %
        public virtual Ingreso Ingreso { get; set; }
    }
}