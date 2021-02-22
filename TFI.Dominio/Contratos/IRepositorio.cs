using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFI.Dominio.Contratos
{
    public interface IRepositorio
    {
        bool IniciarSesion(int legajo, string contraseña);
        List<Talle> GetTalles();
        void GuardarVenta(Venta venta);
        Indumentaria BuscarIndumentaria(int codigo);
        Stock BuscarStock(Indumentaria indumentaria, int talleId);
    }
}
