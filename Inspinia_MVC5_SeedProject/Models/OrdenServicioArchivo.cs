using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class OrdenServicioArchivo
    {
        public int ordenServicioArchivoId { get; set; }
        public int ordenServicioId { get; set; }
        public int archivoId { get; set; }

        public virtual OrdenServicio OrdenServicio { get; set; }
        public virtual Archivo Archivo { get; set; }
    }
}