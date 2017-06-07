using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class EstadoValorizacion
    {
        public int estadoValorizacionId { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }

        public virtual List<Valorizacion> Valorizaciones { get; set; }
    }
}