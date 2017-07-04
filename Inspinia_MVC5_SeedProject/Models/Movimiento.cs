using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class Movimiento
    {
        public int movimientoId { get; set; }
        public int tipoMovimientoId { get; set; }
        public int materialNivelStockId { get; set; }
        public double cantidad { get; set; }
        public string usuarioSolicitante { get; set; }
        public int? partidaId { get; set; }
        public string comentario { get; set; }

        public string usuarioCreacion { get; set; }
        public string usuarioModificacion { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime fechaCreacion { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? fechaModificacion { get; set; }

        public virtual TipoMovimiento TipoMovimientos { get; set; }
        public virtual MaterialNivelStock MaterialNivelStock { get; set; }
        public virtual Partida Partida { get; set; }


    }
}