using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class Requerimiento
    {
        [DisplayName("Id")]
        public int requerimientoId { get; set; }

        [DisplayName("Fecha Registro")]
        [DataType(DataType.Date)]  
        public DateTime fecha { get; set; }

        [DisplayName("Numero")]
        [MaxLength(10)]
        public String numero { get; set; }

        [DisplayName("Comentarios")]
        [MaxLength(1000)]
        public String comentario { get; set; }

        [DisplayName("Obra")]
        public int obraId { get; set; }

        [DisplayName("Obra")]
        public virtual Obra Obra { get; set; }

        [DisplayName("Estado")]
        public bool ordenGenerada { get; set; }

        [DisplayName("Prioridad")]
        public int prioridadId { get; set; }

        [DisplayName("Prioridad")]
        public virtual Prioridad Prioridad { get; set; }

        [DisplayName("Detalles")]
        public virtual List<RequerimientoDetalle> Detalles { get; set; }

        public virtual List<OrdenCompra> OrdenCompras { get; set; }


    }
}