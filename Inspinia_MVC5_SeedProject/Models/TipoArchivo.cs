using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class TipoArchivo
    {
        public int tipoArchivoId { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }

        public List<Archivo> Archivos { get; set; }
    }
}