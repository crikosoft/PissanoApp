using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class DocumentoPago
    {
        public int documentoPagoId { get; set; }
        public string numero { get; set; }
        public int tipoDocumentoId { get; set; }
        public virtual TipoDocumento TipoDocumento { get; set; }
        public DateTime fecha { get; set; }

    }
}