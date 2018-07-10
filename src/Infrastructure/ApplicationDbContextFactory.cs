using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Promociones.Infrastructure
{
    class ApplicationDbContextFactory : IDesignTimeDbContextFactory<PromocionContext>
    {
        public PromocionContext CreateDbContext(string[] args)
        {
            var builderOption = new DbContextOptionsBuilder<PromocionContext>();
            builderOption.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=PromocionesDB;Trusted_Connection=True;MultipleActiveResultSets=true", x => x.MigrationsAssembly("Promociones.Infrastructure"));
            return new PromocionContext(builderOption.Options);
        }
    }
}
