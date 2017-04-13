using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class Moneda
    {
        public int monedaId { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }

        public virtual List<Presupuesto> Presupuestos { get; set; }

        public virtual List<OrdenCompra> OrdenesCompra { get; set; }
    }
}