using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promociones.Presentation.Api.ConfiguracionIOC
{
    public interface IConfiguracionIOC
    {
        IContainer ObtenerConfiguracionIOC(IServiceCollection services, IConfiguration configuration);
    }
}
