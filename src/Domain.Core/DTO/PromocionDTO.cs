using System;
using System.Collections.Generic;
using System.Text;

namespace Promociones.Domain.Core.DTO
{
    public class PromocionDTO
    {
        public PromocionDTO(int idMedioPago, int idTipoMedioPago, int idEntidadFinanciera, int cantCuotas, int idCatProd)
        {
            IdMedioPago = idMedioPago;
            IdTipoMedioPago = idTipoMedioPago;
            IdEntidadFinanciera = idEntidadFinanciera;
            CantCuotas = cantCuotas;
            IdCatProd = idCatProd;
        }
        public int IdMedioPago { get; private set; }

        public int IdTipoMedioPago { get; private set; }

        public int IdEntidadFinanciera { get; private set; }

        public int CantCuotas { get; private set; }

        public int IdCatProd { get; private set; }

    }
}
