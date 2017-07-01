using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class ValorizacionDetalle
    {
        public int valorizacionDetalleId { get; set; }
        public int valorizacionId { get; set; }
        public int ordenCompradetalleId { get; set; }

        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
        public double avanceMonto { get; set; }
        public double avancePorc { get; set; }
        public double avanceMetrado { get; set; }


        public string usuarioCreacion { get; set; }
        public string usuarioModificacion { get; set; }
        public DateTime? fechaCreacion { get; set; }
        public DateTime? fechaModificacion { get; set; }


        public virtual Valorizacion Valorizacion { get; set; }
        public virtual OrdenCompraDetalle OrdenCompraDetalle { get; set; }
    }
}