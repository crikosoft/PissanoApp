using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class PresupuestoAndPresupuestoDetalle
    {

        public IEnumerable<Presupuesto> Presupuestos { get; set; }

        public IEnumerable<PresupuestoDetalle> PresupuestoDetalles { get; set; }

    }
}