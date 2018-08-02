using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Moq;
using Promociones.Domain.Core;
using Promociones.Infrastructure;
using Promociones.Presentation.Api.Services;

namespace Promociones.Presentation.Api.ConfiguracionIOC
{
    public class ConfiguracionLocal : IConfiguracionIOC
    {
        public IContainer ObtenerConfiguracionIOC(IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<PromocionContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly("Promociones.Infrastructure")));
            Mock<IServicioMedioPago> mockMediosPago = new Mock<IServicioMedioPago>();
            mockMediosPago.Setup(m => m.ValidarMediosPago(It.IsAny<int[]>())).Returns(Task.FromResult(true));

            Mock<IServicioProductoCategoria> mockProductoCategoria = new Mock<IServicioProductoCategoria>();
            mockProductoCategoria.Setup(m => m.ValidarCategoriasProducto(It.IsAny<int[]>())).Returns(Task.FromResult(true));

            var containerBuilder = new ContainerBuilder();
            containerBuilder.Register(reg =>
            {
                return new MongoClient(configuration.GetConnectionString("DefaultConnection"));
            }).As<IMongoClient>();

            //containerBuilder.RegisterType<PromocionContext>().As<DbContext>();
            containerBuilder.RegisterType<RepositorioPromocion>().As<IRepositorioPromocion>();
            containerBuilder.RegisterType<ServicioPromocion>().As<IServicioPromocion>();
            containerBuilder.RegisterInstance(mockMediosPago.Object).As<IServicioMedioPago>();
            containerBuilder.RegisterInstance(mockProductoCategoria.Object).As<IServicioProductoCategoria>();
            containerBuilder.Populate(services);
            return containerBuilder.Build();
        }
    }
}
