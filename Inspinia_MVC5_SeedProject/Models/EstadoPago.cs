using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class EstadoPago
    {
        public int estadoPagoId { get; set; }

        [Required()]
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public virtual List<Pago> PagosEstadoPago { get; set; }
    }
}