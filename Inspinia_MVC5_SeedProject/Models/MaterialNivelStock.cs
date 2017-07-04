using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class MaterialNivelStock
    {
        public int materialNivelStockId { get; set; }
        public int almacenId { get; set; }
        public virtual Almacen Almacen { get; set; }
        public int materialId { get; set; }
        public virtual Material Material { get; set; }
        public DateTime fechaStock { get; set; }
        public double cantidad { get; set; }
        public virtual List<Movimiento> Movimientos { get; set; }

    }
}