using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace PissanoApp.Models
{
    public class Categoria
    {
        public int categoriaId { get; set; }

        [Required()]
        [StringLength(200)]
        [DisplayName("Descripción")]
        public string descripcion { get; set; }

        [Required()]
        [StringLength(10)]
        [DisplayName("Código")]
        public string codigo { get; set; }

        [DisplayName("Familia")]
        public int? categoriaPadreId { get; set; }

        public Categoria CategoriaPadre { get; set; }

        //public virtual List<Categoria> CategoriaHijas { get; set; }

    }
}