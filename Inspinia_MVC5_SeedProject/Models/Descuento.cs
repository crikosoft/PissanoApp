﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class Descuento
    {
        public int descuentoId { get; set; }
        public int tipoDescuentoId { get; set; }
        public int valorizacionId { get; set; }

        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
        public double? descuentoMonto { get; set; }
        public double? avancePorc { get; set; }

        public string descripcion { get; set; }

        public string usuarioCreacion { get; set; }
        public string usuarioModificacion { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime fechaCreacion { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? fechaModificacion { get; set; }

        public virtual Valorizacion Valorizacion { get; set; }
        public virtual  TipoDescuento TipoDescuento{ get; set; }
    }
}