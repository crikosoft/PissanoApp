using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class RequerimientoEstadoRequerimiento
    {
        public int requerimientoEstadoRequerimientoId { get; set; }

        public int requerimientoId { get; set; }

        public virtual Requerimiento Requerimiento { get; set; }

        public int estadoRequerimientoId { get; set; }

        public virtual EstadoRequerimiento  EstadoRequerimiento { get; set; }

        [Required()]
        public string usuarioCreacion { get; set; }

        [Required()]
        public DateTime fechaCreacion { get; set; }
       
    }
}