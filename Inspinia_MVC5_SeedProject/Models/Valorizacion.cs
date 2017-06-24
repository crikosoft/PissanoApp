﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class Valorizacion
    {
        public int valorizacionId { get; set; }
        public int ordenServicioId { get; set; }
        public string concepto { get; set; }
        public DateTime fechacierre { get; set; }
        public double avance { get; set; }
        public double avancePorc { get; set; }

        public int estadoValorizacionId { get; set; }

        public virtual Contrato Contrato { get; set; }
        public virtual EstadoValorizacion EstadoValorizacion { get; set; }

        [Required()]
        public string usuarioCreacion { get; set; }

        public string usuarioModificacion { get; set; }

        [Required()]
        public DateTime fechaCreacion { get; set; }

        public DateTime fechaModificacion { get; set; }


    }
}