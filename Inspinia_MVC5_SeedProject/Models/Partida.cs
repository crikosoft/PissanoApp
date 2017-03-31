using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class Partida
    {
        public int partidaId { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int unidadMedidaId { get; set; }

        public virtual UnidadMedida UnidadMedida { get; set; }
        public virtual ICollection<Titulo> Titulos { get; set; }


    }
}