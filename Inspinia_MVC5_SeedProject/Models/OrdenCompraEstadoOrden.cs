using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class OrdenCompraEstadoOrden
    {
        public int ordenCompraEstadoOrdenId { get; set; }

        public int ordenCompraId { get; set; }

        public virtual OrdenCompra OrdenCompra { get; set; }

        public int estadoOrdenId { get; set; }

        public virtual EstadoOrden EstadoOrden { get; set; }

        public string comentario { get; set; }

        [Required()]
        public string usuarioCreacion { get; set; }

        [Required()]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime fechaCreacion { get; set; }
    }
}