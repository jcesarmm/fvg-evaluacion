using Promociones.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Promociones.Domain.Core
{
    public interface IServicioMedioPago
    {
        Task<bool> ValidarMediosPago(int[] idsMediosPago);
    }
}
