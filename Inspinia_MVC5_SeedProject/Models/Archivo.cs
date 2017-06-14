using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class Archivo
    {

        public int archivoId { get; set; }
        public int tipoArchivoId { get; set; }
        public string ruta { get; set; }

        public int? ordenCompraId { get; set; }

        public virtual TipoArchivo TipoArchivo { get; set; }
        public virtual OrdenCompra  OrdenCompra{ get; set; }

    }
}