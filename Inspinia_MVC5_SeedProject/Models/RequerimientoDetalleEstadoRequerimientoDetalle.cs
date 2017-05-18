using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class RequerimientoDetalleEstadoRequerimientoDetalle
    {

        public int requerimientoDetalleEstadoRequerimientoDetalleId { get; set; }

        public int requerimientoDetalleId { get; set; }

        public virtual RequerimientoDetalle RequerimientoDetalle { get; set; }

        public int estadoRequerimientoDetalleId { get; set; }

        public virtual EstadoRequerimientoDetalle EstadoRequerimientoDetalle { get; set; }

        [Required()]
        public string usuarioCreacion { get; set; }

        [Required()]
        public DateTime fechaCreacion { get; set; }

    }
}