using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;



namespace PissanoApp.Models
{
    public class Contrato
    {
        public int contratoId  { get; set; }
        public int ordenCompraId { get; set; }
        public virtual OrdenCompra OrdenCompra { get; set; }

        [DisplayName("Comentarios")]
        public string comentario { get; set; }

        public double metrado { get; set; }

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

        public double? avance { get; set; }
        public double? avancePorc { get; set; }
        public double? saldo { get; set; }
        public double? saldoPorc { get; set; }
        public int numeroPagos { get; set; }

        public virtual TipoValorizacion TipoValorizacion { get; set; }
        public virtual List<Archivo> ContratoArchivos { get; set; }
        public virtual List<Valorizacion> Valorizaciones { get; set; }

        public string usuarioCreacion { get; set; }

        public string usuarioModificacion { get; set; }

        public DateTime? fechaCreacion { get; set; }

        public DateTime? fechaModificacion { get; set; }

    }
}