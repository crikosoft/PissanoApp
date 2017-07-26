using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class FondoGarantia
    {
        public int fondoGarantiaId { get; set; }
        public int valorizacionId { get; set; }

        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
        public double? fondoMonto { get; set; }

        public string descripcion { get; set; }
        public int estadoFondoGarantiaId { get; set; }

        public string usuarioCreacion { get; set; }
        public string usuarioModificacion { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime fechaCreacion { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? fechaModificacion { get; set; }

        public virtual Valorizacion Valorizacion { get; set; }
        public virtual EstadoFondoGarantia EstadoFondoGarantia { get; set; }
    }
}