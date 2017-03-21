using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class Empresa
    {
        
        public int empresaId { get; set; }

        [Required()]
        [Display(Name="Nombre de la Empresa")]
        public string nombre { get; set; }

        [Required()]
        public string ruc { get; set; }
        public bool agenteRetenedor { get; set; }

        public string telefono { get; set; }

        public string direccion { get; set; }

        public virtual List<Obra> Obras { get; set; } 

    }
}