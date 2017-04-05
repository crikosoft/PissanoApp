using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class SubPresupuesto
    {
        public int subPresupuestoId { get; set; }
        public string nombre { get; set; }

        public virtual List<PresupuestoTitulo> PresupuestoTitulo { get; set; }
    }
}