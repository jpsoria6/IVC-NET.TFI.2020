using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFI.Dominio.Dominio;

namespace TFI.Dominio
{
    public class Stock
    {
        public int Id { get; set; }
        public Indumentaria Indumentaria { get; set; }
        public int Cantidad { get; set; }
        public Talle Talle { get; set; }

        public Stock()
        {

        }

        public void AgregarCantidad(int cantidad)
        {
            this.Cantidad += cantidad;
            ReglaStock.Instance.VerificarCantidad(cantidad);
        }
        public void DisminuirCantidad(int cantidad)
        {
            if(Cantidad - cantidad < 0)
            {
                throw new Exception("Stock insuficiente");
            }
            this.Cantidad -= cantidad;
        }
    }
}
