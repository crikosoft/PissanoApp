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

        public List<Partida> Partidas { get; set; }

        public Presupuesto Presupuesto { get; set; }


        public PresupuestoPartidaViewModel(List<Partida> partidas, Presupuesto presupuesto)
        {
            Partidas = partidas;
            Presupuesto = presupuesto;            
        }



    }
}