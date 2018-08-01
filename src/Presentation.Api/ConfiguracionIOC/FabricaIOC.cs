using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Promociones.Presentation.Api.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promociones.Presentation.Api.ConfiguracionIOC
{
    public class FabricaIOC
    {
        private IServiceCollection services;
        private IConfiguration configuration;

        public FabricaIOC(IServiceCollection services, IConfiguration configuration)
        {
            this.services = services;
            this.configuration = configuration;
        }
        public IContainer ObtenerConfiguracion(string ambiente)
        {
            IContainer container;
            var builder = new ContainerBuilder();
            switch (ambiente.ToUpper())
            {
                case Constantes.ENV_DEVELOPMENT:
                    container = new ConfiguracionLocal().ObtenerConfiguracionIOC(services, configuration);
                    break;
                case Constantes.ENV_TESTING:
                case Constantes.ENV_STAGING:
                case Constantes.ENV_PRODUCTION:
                    container = new ConfiguracionServicios().ObtenerConfiguracionIOC(services, configuration);
                    break;
                default:
                    container = new ConfiguracionServicios().ObtenerConfiguracionIOC(services, configuration);
                    break;

            }
            return container;
        }
    }
}
