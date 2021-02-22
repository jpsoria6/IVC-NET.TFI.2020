using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFI.Dominio;
using TFI.Dominio.Contratos;

namespace TFI.AccesoADatos
{
    public class Repositorio : IRepositorio
    {
        private readonly IvcNetContext _context;
        public Repositorio(IvcNetContext context)
        {
            this._context = context;
        }

        public Indumentaria BuscarIndumentaria(int codigo)
        {
            return this._context.Indumentarias.FirstOrDefault(ind => ind.Codigo == codigo);
        }

        public Stock BuscarStock(Indumentaria indumentaria, int talleId)
        {
            return _context.Stocks.Where(stock => stock.Indumentaria.Id == indumentaria.Id && stock.Talle.Id == talleId).FirstOrDefault();
        }

        public List<Talle> GetTalles()
        {
            return _context.Talles.ToList();
        }

        public void GuardarVenta(Venta venta)
        {
            _context.Ventas.Add(venta);
            _context.SaveChanges();
        }

        public bool IniciarSesion(int legajo, string contraseña)
        {
            return _context.Empleados.Where(e => e.Legajo == legajo && e.Contraseña == contraseña).Any();
        }
    }
}
