using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class Banco
    {
        public int bancoId { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }

        public virtual List<CuentaBancaria> CuentasBancarias { get; set; }
    }
}