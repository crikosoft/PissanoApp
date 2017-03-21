using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class Almacen
    {
        public int almacenId { get; set; }
        public int obraId { get; set; }
        public virtual Obra Obra { get; set; }
    }
}