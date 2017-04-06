using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    

    public class Obra
    {
        public int id { get; set; }

        [Display(Name = "Nombre de Obra")]
        public string nombre { get; set; }


        [Required()]
        [Display(Name = "Dirección de la Obra")]
        public string direccion { get; set; }
                
        public DateTime fechaInicio { get; set; }
        
        public DateTime fechaFin { get; set; }

        public int tiempoEjecucion { get; set; } //Meses

        public int empresaId { get; set; }
        public virtual Empresa empresa { get; set; }

        public virtual List<Presupuesto> Presupuestos { get; set; }

        public virtual List<Requerimiento> Requerimientos { get; set; }
        
    }
}