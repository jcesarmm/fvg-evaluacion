using System;
using System.Collections.Generic;
using System.Text;

namespace Promociones.Domain.Entities.Common
{
    public abstract class Entidad : IEntidad
    {
        public int Id { get; set; }
    }
}
