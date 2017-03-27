using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class Presupuesto
    {


        public int presupuestoId { get; set; }

        [StringLength(200)]
        [Required(ErrorMessage = "Descripción es requerida")]
        public string descripcion { get; set; }

        [DisplayName("Obra")]
        [Required(ErrorMessage = "Obra es requerida")]
        public int obraId { get; set; }
        public virtual Obra Obra { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fecha { get; set; }

        [DisplayName("Plazo")]
        public int plazo { get; set; }

        [Required(ErrorMessage = "Moneda es requerida")]
        [DisplayName("Moneda")]
        public int monedaId { get; set; }
        public virtual Moneda Moneda { get; set; }

        [DisplayName("Total")]
        public double total { get; set; }
        public ICollection<PresupuestoDetalle> PresupuestoDetalles { get; set; }

        [Required(ErrorMessage = "Tipo de Presupuesto es requerida")]
        [DisplayName("TipoPresupuesto")]
        public int tipoPresupuestoId { get; set; }
        public virtual TipoPresupuesto TipoPresupuesto { get; set; }

        //public ICollection<string> Skills { get; set; }
        //public virtual ICollection<PresupuestoDetalle> PresupuestoDetalles { get; set; }
    }
}