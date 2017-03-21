using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class Requerimiento
    {
        public int requerimientoId { get; set; }
        public DateTime fecha { get; set; }
        public int obraId { get; set; }
        public String numero { get; set; }
        public virtual Obra Obra { get; set; }
        public virtual List<OrdenCompra> OrdenCompras { get; set; }
    }
}