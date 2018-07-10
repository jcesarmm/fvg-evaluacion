using Promociones.Domain.Core.Common;
using Promociones.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Promociones.Domain.Core
{
    public interface IServicioPromocion : IServicio<Promocion>
    {
        IEnumerable<Promocion> ObtenerTodosVigentes();
        IEnumerable<Promocion> ObtenerTodosVigentesFecha(DateTime fecha);
        IEnumerable<Promocion> ObtenerTodosVigentesVenta(int idMedioPago, int idTipoMedioPago, int idEntidadFinanciera, int cantCuotas, int idCatProd);
        bool ValidarPromocionVigente(int id);
    }
}
