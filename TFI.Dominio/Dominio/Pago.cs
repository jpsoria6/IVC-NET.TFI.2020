using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFI.Dominio
{
    public class Pago
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public double Total { get; set; }
        public Factura Factura { get; set; }

        public Pago(double total)
        {
            this.FechaHora = DateTime.Now;
            this.Total = total;
            GenerarFactura();
        }

        public void GenerarFactura()
        {
            this.Factura = new Factura(Total); 
        }
    }
}
