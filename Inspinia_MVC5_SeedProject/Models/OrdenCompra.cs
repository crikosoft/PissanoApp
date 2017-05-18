using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class OrdenCompra
    {
        public int ordenCompraId { get; set; }

        [Required()]
        public string numero { get; set; }

        [Required()]
        public int proveedorId { get; set; }
        public virtual Proveedor Proveedor { get; set; }

        [Required()]
        public bool incluyeIgv { get; set; }

        [Required()]
        public double subTotal { get; set; }

        [Required()]
        public double igv { get; set; }

        [Required()]
        public double total { get; set; }

        [Required()]
        public int obraId { get; set; }
        public virtual Obra Obra { get; set; }

        [Required()]
        public int estadoOrdenId { get; set; }
        public virtual EstadoOrden EstadoOrden { get; set; }

        public int requerimientoId { get; set; }
        public virtual Requerimiento Requerimiento { get; set; }

        public string comentario { get; set; }

        public int adelanto { get; set; }

        public int formaPagoId { get; set; }

        [Required()]
        public string usuarioCreacion { get; set; }

        public string usuarioModificacion { get; set; }

        [Required()]
        public DateTime fechaCreacion { get; set; }

        public DateTime fechaModificacion { get; set; }

        public virtual FormaPago FormaPago { get; set; }

        public virtual List<OrdenCompraDetalle> OrdenesCompraDetalles { get; set; }

        public int monedaId { get; set; }

        public virtual Moneda Moneda { get; set; }

    }
}