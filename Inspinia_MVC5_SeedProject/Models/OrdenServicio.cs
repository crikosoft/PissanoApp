using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class OrdenServicio
    {
        public int ordenServicioId { get; set; }

        [Required()]
        [StringLength(20)]
        [DisplayName("Código")]
        public string codigo { get; set; }

        [DisplayName("Servicio")]
        [Required(ErrorMessage = "Servicio es requerida")]
        public int materialId { get; set; }

        [DisplayName("Proveedor")]
        [Required(ErrorMessage = "Proveedor es requerido")]
        public int proveedorId { get; set; }

        public double metrado { get; set; }
        public double precioUnitario { get; set; }
        public double subtotal { get; set; }
        public double igv { get; set; }
        public double total { get; set; }

        [DisplayName("Forma de Pago")]
        [Required(ErrorMessage = "Forma de Pago es requerido")]
        public int formaPagoId  { get; set; }

        [DisplayName("Moneda")]
        [Required(ErrorMessage = "Moneda es requerida")]
        public int monedaId  { get; set; }

        [DisplayName("Adelanto")]
        public double? adelanto { get; set; }
        
        [DisplayName("Adelanto %")]
        public double? adelantoPorc { get; set; }

        [DisplayName("Fondo de Garantía")]
        public double? fondoGarantia { get; set; }

        [DisplayName("Fondo de Garantía %")]
        public double? fondoGarantiaPorc { get; set; }

        [DisplayName("Tipo de valorización")]
        [Required(ErrorMessage = "Tipo de valorización es requerido")]
        public int tipoValorizacionId { get; set; }

        [DisplayName("Fecha de Inicio")]
        [Required(ErrorMessage = "Fecha de Inicio es requerido")]
        [DataType(DataType.Date)]
        public DateTime fechaInicio { get; set; }

        public int? duracion { get; set; }

        [DisplayName("Partida")]
        [Required(ErrorMessage = "Partida es requerida")]
        public int partidaId { get; set; }

        public double? avance { get; set; }
        public double? avancePorc { get; set; }
        public double? saldo { get; set; }
        public double? saldoPorc { get; set; }
        public int numeroPagos { get; set; }


        [Required()]
        [StringLength(1000)]
        [DisplayName("Comentario")]
        public string comentario { get; set; }

        public virtual Material Material { get; set; }
        public virtual Proveedor Proveedor { get; set; }
        public virtual FormaPago FormaPago{ get; set; }
        public virtual Moneda Moneda{ get; set; }
        public virtual TipoValorizacion TipoValorizacion { get; set; }
        public virtual List<OrdenServicioArchivo> OrdenServicioArchivos { get; set; }
        public virtual Partida Partida { get; set; }


        [Required()]
        public string usuarioCreacion { get; set; }

        public string usuarioModificacion { get; set; }

        [Required()]
        public DateTime fechaCreacion { get; set; }

        public DateTime fechaModificacion { get; set; }



    }
}