using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class TipoCompra
    {
        public int tipoCompraId { get; set; }
        public string nombre { get; set; }
        public virtual List<Requerimiento> Requerimientos { get; set; }
    }
}