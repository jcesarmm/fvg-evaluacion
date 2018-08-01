using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Promociones.Domain.Core;
using Promociones.Infrastructure;
using Promociones.Presentation.Api.Services;

namespace Promociones.Presentation.Api.ConfiguracionIOC
{
    public class ConfiguracionServicios: IConfiguracionIOC
    {
        public IContainer ObtenerConfiguracionIOC(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PromocionContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly("Promociones.Infrastructure")));

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<PromocionContext>().As<DbContext>();
            containerBuilder.RegisterType<RepositorioPromocion>().As<IRepositorioPromocion>();
            containerBuilder.RegisterType<ServicioPromocion>().As<IServicioPromocion>();

            //TODO: Registrar Servicios reales a medios de pago y productos categoria
            //containerBuilder.RegisterInstance(mockMediosPago.Object).As<IServicioMedioPago>();
            //containerBuilder.RegisterInstance(mockProductoCategoria.Object).As<IServicioProductoCategoria>();

            containerBuilder.Populate(services);
            return containerBuilder.Build();
        }
    }
}
