using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class Prioridad
    {
        [DisplayName("Prioridad")]
        public int prioridadId { get; set; }

        [DisplayName("Prioridad")]
        public string nombre { get; set; }

        [DisplayName("Prioridad")]
        public int plazoDias { get; set; }

        public virtual List<Requerimiento> Requerimientos { get; set; }
    }
}