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
        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
        public double precioUnitario { get; set; }
        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
        public double precioTotal { get; set; }

        [Required()]
        public int estadoOrdenDetalleId { get; set; }
        public virtual EstadoOrdenDetalle EstadoOrdenDetalle { get; set; }

        public virtual List<IngresoDetalle> IngresoDetalles { get; set; }

        public virtual List<ValorizacionDetalle> ValorizacionDetalles { get; set; }
    }
}