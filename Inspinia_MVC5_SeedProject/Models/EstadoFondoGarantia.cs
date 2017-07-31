﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class EstadoFondoGarantia
    {
        public int estadoFondoGarantiaId { get; set; }

        [Required()]
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public virtual List<FondoGarantia> FondoGarantiaEstado { get; set; }
    }
}