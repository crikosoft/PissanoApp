using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class UnidadMedida
    {

        public int unidadMedidaId { get; set; }
        public string nombre { get; set; }
        public string sigla { get; set; }
        public List<Material> Materiales { get; set; }
    }
}