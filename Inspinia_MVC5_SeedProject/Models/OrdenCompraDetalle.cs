using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class OrdenCompraDetalle
    {
        public int ordenCompradetalleId { get; set; }

        [Required()]
        public int ordenCompraId { get; set; }
        public virtual OrdenCompra OrdenCompra { get; set; }

        [Required()]              
        public int materialId { get; set; }
        public virtual Material Material { get; set; }
        [Required()]
        public double cantidad { get; set; }

        [Required()]
        public double precioUnitario { get; set; }
        public double precioTotal { get; set; }

        [Required()]
        public int estadoOrdenDetalleId { get; set; }
        public virtual EstadoOrdenDetalle EstadoOrdenDetalle { get; set; }
    }
}