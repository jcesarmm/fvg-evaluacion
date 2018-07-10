using System;
using System.Collections.Generic;
using System.Text;

namespace Promociones.Domain.Entities.Common
{
    public interface IEntidadAuditable
    {
        DateTime FechaCreacion { set; get; }

        DateTime? FechaModificacion { set; get; }
    }
}
