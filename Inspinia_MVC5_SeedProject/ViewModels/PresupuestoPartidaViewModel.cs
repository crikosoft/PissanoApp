using PissanoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PissanoApp.ViewModels
{
    public class PresupuestoPartidaViewModel
    {

        public int? presupuestoPartidaViewModelId { get; set; }

        public List<SubPresupuesto> SubPresupuestos { get; set; }

        public List<Partida> Partidas { get; set; }

        public Presupuesto Presupuesto { get; set; }


        public List<PresupuestoTitulo> PresupuestoTitulos { get; set; }


        public PresupuestoPartidaViewModel(List<SubPresupuesto> subPresupuestos, List<Partida> partidas, Presupuesto presupuesto, List<PresupuestoTitulo> presupuestoTitulos)
        {
            SubPresupuestos = subPresupuestos;
            Partidas = partidas;
            Presupuesto = presupuesto;
            PresupuestoTitulos = presupuestoTitulos;
        }



    }
}