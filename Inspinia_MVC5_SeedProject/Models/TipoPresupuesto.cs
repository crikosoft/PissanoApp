using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class TipoPresupuesto
    {
        public int tipoPresupuestoId { get; set; }
        public string descripcion { get; set; }

        public virtual List<Presupuesto> Presupuestos { get; set; }


    }
}