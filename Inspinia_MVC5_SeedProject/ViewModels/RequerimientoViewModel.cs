using PissanoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PissanoApp.ViewModels
{
    public class RequerimientoViewModel
    {
        public int? requerimientoViewModelId { get; set; }
        public List<Obra> Obras { get; set; }
        public List<Material> Materiales { get; set; }
        public List<Prioridad> Prioridades { get; set; }

        public List<Requerimiento> Requerimientos { get; set; }

        public RequerimientoViewModel(List<Obra> obras, List<Material> materiales, List<Prioridad> prioridades, List<Requerimiento> requerimientos)
        {
            Obras = obras;
            Materiales = materiales;
            Prioridades = prioridades;
            Requerimientos = requerimientos;
        }


    }
}