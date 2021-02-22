using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFI.Dominio
{
    public class LineaDeVenta
    {
        public int Id { get; set; }
        public Indumentaria Indumentaria { get; set; }
        public int CodigoIndumentaria { get { return Indumentaria.Id; } }
        public string DescripcionIndumentaria { get { return Indumentaria.Descripcion; } }
        public double PrecioIndumentaria { get { return Indumentaria.Precio; } }
        public int Cantidad { get; set; }
        public double Subtotal { get { return PrecioIndumentaria * Cantidad; } }

        public LineaDeVenta(Indumentaria indumentaria, int cantidad)
        {
            this.Indumentaria = indumentaria;
            this.Cantidad = cantidad;
        }
    }
}
