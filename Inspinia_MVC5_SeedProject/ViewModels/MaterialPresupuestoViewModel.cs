using PissanoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PissanoApp.ViewModels
{
    public class MaterialPresupuestoViewModel
    {
        public List<Material> MaterialesPadres { get; set; }

        public List<Categoria> CategoriasPadres { get; set; }

        public List<TipoMaterial> TipoMateriales { get; set; }


        public MaterialPresupuestoViewModel(List<Material> materialesPadres, List<Categoria> categoriasPadres, List<TipoMaterial> tipoMateriales)
        {
            MaterialesPadres = materialesPadres;
            CategoriasPadres = categoriasPadres;
            TipoMateriales = tipoMateriales;
        }

    }
}