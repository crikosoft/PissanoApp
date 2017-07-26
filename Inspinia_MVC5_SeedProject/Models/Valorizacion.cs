using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class Valorizacion
    {
        public int valorizacionId { get; set; }
        public int contratoId { get; set; }
        public string concepto { get; set; }

        [DisplayName("Fecha de Cierre")]
        [Required(ErrorMessage = "Fecha de Cierre es requerido")]
        [DataType(DataType.Date)]
        public DateTime fechacierre { get; set; }

        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
        public double avanceMonto { get; set; }
        public double avancePorc { get; set; }
        public double avanceMetrado { get; set; }

        public int estadoValorizacionId { get; set; }

        public virtual Contrato Contrato { get; set; }
        public virtual EstadoValorizacion EstadoValorizacion { get; set; }

        public string usuarioCreacion { get; set; }

        public string usuarioModificacion { get; set; }

        public DateTime? fechaCreacion { get; set; }

        public DateTime? fechaModificacion { get; set; }

        public virtual List<ValorizacionDetalle> ValorizacionDetalles { get; set; }

        public virtual List<Descuento> Descuentos { get; set; }

        public virtual List<FondoGarantia> FondosGarantia { get; set; }

    }
}