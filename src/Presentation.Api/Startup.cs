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

namespace Promociones.Presentation.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddControllersAsServices();
            services.AddDbContext<PromocionContext>(options => options.UseSqlServer("Name=DefaultConnection"));

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<PromocionContext>().As<DbContext>();
            containerBuilder.RegisterType<RepositorioPromocion>().As<IRepositorioPromocion>();
            containerBuilder.RegisterType<ServicioPromocion>().As<IServicioPromocion>();

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
