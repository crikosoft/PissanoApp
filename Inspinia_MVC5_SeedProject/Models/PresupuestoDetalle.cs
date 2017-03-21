using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class PresupuestoDetalle
    {
        public int presupuestoDetalleId { get; set; }
        public int presupuestoId { get; set; }
        public virtual Presupuesto Presupuesto { get; set; }
        public int materialId { get; set; }
        public virtual Material Material { get; set; }
        public int cantidad { get; set; }
        public double precioUnitario { get; set; }
        public double precioTotal { get; set; }

    }
}