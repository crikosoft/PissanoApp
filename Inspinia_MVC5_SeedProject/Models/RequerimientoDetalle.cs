using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class RequerimientoDetalle
    {
        public int requerimientoDetalleId { get; set; }

        public int requerimientoId { get; set; }
        public virtual Requerimiento Requerimiento { get; set; }

        public int materialId { get; set; }
        public virtual Material Material { get; set; }
        public int cantidad { get; set; }
    }
}