using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class Adelanto
    {
        public int adelantoId { get; set; }
        public int contratoId { get; set; }
        public string descripcion { get; set; }

        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
        public double? adelantoMonto { get; set; }
        public double? adelantoPorc { get; set; }

        public int estadoAdelantoId { get; set; }

        public string usuarioCreacion { get; set; }
        public string usuarioModificacion { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime fechaCreacion { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? fechaModificacion { get; set; }

        public virtual Contrato Contrato { get; set; }
        public virtual EstadoAdelanto EstadoAdelanto { get; set; }
    }
}