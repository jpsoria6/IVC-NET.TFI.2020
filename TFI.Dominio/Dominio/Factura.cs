using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFI.Dominio
{
    public class Factura
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public double Total { get; set; }

        public Factura (double total)
        {
            this.FechaHora = DateTime.Now;
            this.Total = total;
        }
    }
}
