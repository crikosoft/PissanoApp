using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class FormaPago
    {
        public int formaPagoId { get; set; }
        public string nombre { get; set; }

        public virtual List<OrdenCompra> OrdenCompras { get; set; }
        public virtual List<Proveedor> Proveedores { get; set; }
    }
}