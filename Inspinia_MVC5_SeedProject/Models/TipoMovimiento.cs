using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class TipoMovimiento
    {
        public int tipoMovimientoId { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
    }
}