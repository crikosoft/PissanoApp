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
        public double cantidad { get; set; }

        public int partidaId { get; set; }
        public virtual Partida Partida { get; set; }

        public int estadoRequerimientoDetalleId { get; set; }
        public virtual EstadoRequerimientoDetalle EstadoRequerimientoDetalle { get; set; }

        public int? ordenCompraId { get; set; }
        public virtual OrdenCompra OrdenCompra { get; set; }

        public virtual List<RequerimientoDetalleEstadoRequerimientoDetalle> RequerimientoDetalleEstadosRequerimientoDetalle { get; set; }


    }
}