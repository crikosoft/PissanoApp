using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class TipoMaterial
    {
        public int tipoMaterialId { get; set; }
        public string nombre { get; set; }
        public List<Material> Materiales { get; set; }
        public List<Proveedor> Proveedores { get; set; }
    }
}