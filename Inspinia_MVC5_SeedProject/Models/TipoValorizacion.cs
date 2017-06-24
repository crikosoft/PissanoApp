using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class TipoValorizacion
    {
        public int tipoValorizacionId { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }

        public virtual List<Contrato> Contrato { get; set; }

    }
}