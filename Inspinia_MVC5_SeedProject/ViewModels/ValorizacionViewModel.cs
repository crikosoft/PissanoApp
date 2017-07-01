using PissanoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PissanoApp.ViewModels
{
    public class ValorizacionViewModel
    {
        public int? ordenCompraViewModelId { get; set; }
        public Contrato Contrato { get; set; }
        public List<Contrato> Contratos { get; set; }


        public ValorizacionViewModel(Contrato contrato, List<Contrato> contratos)
        {
            Contrato = contrato;
            Contratos = contratos;

        }
    }
}