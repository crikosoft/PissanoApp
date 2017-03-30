using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class Titulo
    {
        public int tituloId { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public virtual ICollection<Partida> Partidas { get; set; }
    }
}