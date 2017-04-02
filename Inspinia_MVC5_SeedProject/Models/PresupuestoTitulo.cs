using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class PresupuestoTitulo
    {
         [Key, Column(Order = 0)]
        public int presupuestoId { get; set; }

        public virtual Presupuesto Presupuesto { get; set; }

        [Key, Column(Order = 1)]
        public int tituloId { get; set; }

        public virtual Titulo Titulo { get; set; }

        public int orden { get; set; }
    }
}