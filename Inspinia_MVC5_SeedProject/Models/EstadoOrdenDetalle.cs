using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class EstadoOrdenDetalle
    {

        public int estadoOrdenDetalleId { get; set; }

        [Required()]
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public virtual List<OrdenCompraDetalle> OrdenCompraDetalles { get; set; }


    }
}