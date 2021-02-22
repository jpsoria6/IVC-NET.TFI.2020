using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFI.Dominio;

namespace TFI.AccesoADatos
{
    public class IvcNetContext : DbContext
    {
        public IvcNetContext() : base("name=IvcDb")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Venta>().ToTable("Ventas");
            modelBuilder.Entity<LineaDeVenta>().ToTable("LineasDeVenta");
            modelBuilder.Entity<Empleado>().ToTable("Empleados");
            modelBuilder.Entity<Factura>().ToTable("Facturas");
            modelBuilder.Entity<Stock>().ToTable("Stock");
            modelBuilder.Entity<Talle>().ToTable("Talles");
            modelBuilder.Entity<Pago>().ToTable("Pagos");
            modelBuilder.Entity<Indumentaria>().ToTable("Indumentarias");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<LineaDeVenta> LineasDeVenta { get; set; }
        public DbSet<Factura> Facturas  { get; set; }
        public DbSet<Stock> Stocks  { get; set; }
        public DbSet<Talle> Talles { get; set; }
        public DbSet<Indumentaria> Indumentarias { get; set; }
        public DbSet<Pago> Pagos { get; set; }


    }
}
