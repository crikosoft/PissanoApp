using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PissanoApp.Models;

namespace PissanoApp.ViewModels
{
    public class PresupuestoViewModel
    {
        public int? presupuestoViewModelId { get; set; }

        public Presupuesto Presupuesto { get; set; }

        public List<PresupuestoDetalle> PresupuestoDetalles { get; set; }

        public List<Categoria> Categorias { get; set; }

        public List<Categoria> SubCategorias { get; set; }

        public StatesDictionary States { get; set; }

        public PresupuestoViewModel(Presupuesto presupuesto, List<PresupuestoDetalle> presupuestoDetalles, List<Categoria> categorias, List<Categoria> subCategorias)
        {
            Presupuesto = presupuesto;
            PresupuestoDetalles = presupuestoDetalles;
            Categorias = categorias;
            SubCategorias = subCategorias;
            States = new StatesDictionary();
        }
    }
}