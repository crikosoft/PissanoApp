using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class Ingreso
    {
        public int ingresoId { get; set; }
        public int ordenCompraId { get; set; }
        public virtual OrdenCompra OrdenCompra { get; set; }
        public string numeroGuia { get; set; } //o sin numero en caso de servicios
        public DateTime fecha { get; set; }

        public virtual List<IngresoDetalle> IngresoDetalles { get; set; }

        public virtual DocumentoPago DocumentoPago { get; set; }

    }
}