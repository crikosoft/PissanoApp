using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class Material
    {
        public int materialId { get; set; }

        [Required()]        
        [StringLength(500)]
        [DisplayName("Nombre")]
        public string nombre { get; set; }
        
        [Required()]
        [StringLength(20)]
        [DisplayName("Código")]
        public string codigo { get; set; }


        public int unidadMedidaId { get; set; }

        [DisplayName("Unidad de Medida")]
        public virtual UnidadMedida UnidadMedida { get; set; }
        public int tipoMaterialId { get; set; }
        [DisplayName("Tipo de Material")]
        public virtual TipoMaterial TipoMaterial { get; set; }

        public int? materialPadreId { get; set; }

        [DisplayName("Familia")]
        public Material MaterialPadre { get; set; }


//        public virtual MaterialNivelStock MaterialNivelStock { get; set; }

    }
}