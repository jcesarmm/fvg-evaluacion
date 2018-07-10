using System;
using System.Collections.Generic;
using System.Text;

namespace Promociones.Domain.Entities.Common
{
    public abstract class EntidadAuditable : Entidad, IEntidadAuditable
    {
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
