using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Promociones.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Autofac;
using Promociones.Domain.Core;
using Autofac.Extensions.DependencyInjection;
using Promociones.Infrastructure;
using Microsoft.AspNetCore.Routing;
using Moq;
using Microsoft.Extensions.Configuration;

namespace Promociones.Presentation.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            Mock<IServicioMedioPago> mockMediosPago = new Mock<IServicioMedioPago>();
            mockMediosPago.Setup(m => m.ValidarMediosPago(It.IsAny<List<int>>())).Returns(Task.FromResult(true));

            Mock<IServicioProductoCategoria> mockProductoCategoria = new Mock<IServicioProductoCategoria>();
            mockProductoCategoria.Setup(m => m.ValidarCategoriasProducto(It.IsAny<List<int>>())).Returns(Task.FromResult(true));


            services.AddMvc().AddControllersAsServices();
            services.AddDbContext<PromocionContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), x=>x.MigrationsAssembly("Promociones.Infrastructure")));

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<PromocionContext>().As<DbContext>();
            containerBuilder.RegisterType<RepositorioPromocion>().As<IRepositorioPromocion>();
            containerBuilder.RegisterType<ServicioPromocion>().As<IServicioPromocion>();
            containerBuilder.RegisterInstance(mockMediosPago.Object).As<IServicioMedioPago>();
            containerBuilder.RegisterInstance(mockProductoCategoria.Object).As<IServicioProductoCategoria>();

            containerBuilder.Populate(services);
            var container = containerBuilder.Build();
            var serviceProvider = new AutofacServiceProvider(container);
            return serviceProvider;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
