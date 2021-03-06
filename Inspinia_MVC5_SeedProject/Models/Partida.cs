﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class Partida
    {
        public int partidaId { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int subPresupuestoId { get; set; }

        public string usuarioCreacion { get; set; }

        public string usuarioModificacion { get; set; }

        public DateTime fechaCreacion { get; set; }

        public DateTime fechaModificacion { get; set; }

        public virtual SubPresupuesto SubPresupuesto { get; set; }
        //public virtual ICollection<Titulo> Titulos { get; set; }


    }
}