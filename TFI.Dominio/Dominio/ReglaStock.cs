using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFI.Dominio.Dominio
{
    public sealed class ReglaStock
    {
        private readonly static ReglaStock _instance = new ReglaStock();

        private readonly int _cantidadMaxima = 50;
        private readonly int _cantidadMinima = 5;

        private ReglaStock()
        {
        }

        public static ReglaStock Instance
        {
            get
            {
                return _instance;
            }
        }

        public void VerificarCantidad(int cantidad)
        {
            if(cantidad <= 0)
            {
                throw new Exception("La cantidad no puede ser 0 o menor");
            }
            if (cantidad > _cantidadMaxima)
            {
                throw new Exception("La cantidad no puede ser mayor a la cantidad maxima\n (Cant Maxima:"+_cantidadMaxima+")");
            }
        }
    }
}
