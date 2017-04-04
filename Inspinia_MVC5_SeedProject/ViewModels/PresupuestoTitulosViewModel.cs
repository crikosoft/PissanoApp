using PissanoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PissanoApp.ViewModels
{
    public class PresupuestoTitulosViewModel
    {
        public int? presupuestoTitulosViewModelId { get; set; }

        public List<Titulo> Titulos { get; set; }

        public Presupuesto Presupuesto { get; set; }

        public PresupuestoTitulo PresupuestoTitulo { get; set; }


        public PresupuestoTitulosViewModel(List<Titulo> titulos, Presupuesto presupuesto)
        {
            Titulos = titulos;
            Presupuesto = presupuesto;
        }

    }
}