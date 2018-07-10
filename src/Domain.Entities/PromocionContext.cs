using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Promociones.Domain.Entities
{
    public class PromocionContext : DbContext
    {
        public PromocionContext(DbContextOptions<PromocionContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PromocionMedioPago>()
                .HasKey(proomocionmediopago => new { proomocionmediopago.PromocionId, proomocionmediopago.MedioPagoId });

            modelBuilder.Entity<PromocionEntidadFinanciera>()
                .HasKey(promocionentidadfinanciera => new { promocionentidadfinanciera.PromocionId, promocionentidadfinanciera.EntidadFinancieraId });

            modelBuilder.Entity<PromocionTipoMedioPago>()
                .HasKey(promociontipomediopago => new { promociontipomediopago.PromocionId, promociontipomediopago.TipoMedioPagoId });

            modelBuilder.Entity<PromocionProductoCategoria>()
                .HasKey(promocionproductocategoria => new { promocionproductocategoria.PromocionId, promocionproductocategoria.CategoriaId });
        }

        public DbSet<Promocion> Promociones { get; set; }
        public DbSet<MedioPago> MediosPago { get; set; }

        public DbSet<EntidadFinanciera> EntidadesFinancieras{ get; set; }

        public DbSet<TipoMedioPago> TiposMediosPago { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<PromocionMedioPago> PromocionesMediosPago { get; set; }

        public DbSet<PromocionEntidadFinanciera> PromocionesEntidadesFinancieras { get; set; }

        public DbSet<PromocionProductoCategoria> PromocionesProductosCategorias { get; set; }

        public DbSet<PromocionTipoMedioPago> PromocionesTiposMedioPago { get; set; }
    }
}
