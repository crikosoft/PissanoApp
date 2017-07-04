using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class TipoDetraccion
    {
        public int? tipoDetraccionId { get; set; }
        [StringLength(10)]
        public string codigo { get; set; }
        public string  tipoBienServicio { get; set; }
        public double porcentaje { get; set; }
    }
}