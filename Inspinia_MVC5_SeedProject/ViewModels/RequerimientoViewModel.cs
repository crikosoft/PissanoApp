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

        public TipoCompra TipoCompra{ get; set; }

        public List<Partida> Partidas { get; set; }

        public List<SubPresupuesto> SubPresupuestos { get; set; }

        public RequerimientoViewModel(List<Obra> obras, List<Material> materiales, List<Prioridad> prioridades, List<Requerimiento> requerimientos, TipoCompra tipoCompra, List<Partida> partidas, List<SubPresupuesto> subPresupuestos)
        {
            Obras = obras;
            Materiales = materiales;
            Prioridades = prioridades;
            Requerimientos = requerimientos;
            TipoCompra = tipoCompra;
            Partidas = partidas;
            SubPresupuestos = SubPresupuestos;
        }


    }
}