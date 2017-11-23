using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class ArchivoTelecredito
    {
        public int archivoTelecreditoId { get; set; }
        public string nombre { get; set; }
        public string ruta { get; set; }
        public string usuarioCreacion { get; set; }
        public DateTime? fechaCreacion { get; set; }

        public virtual List<Pago> Pagos { get; set; }
    }
}