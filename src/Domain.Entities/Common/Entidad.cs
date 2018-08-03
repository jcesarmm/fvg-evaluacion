using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Promociones.Domain.Entities.Common
{
    public abstract class Entidad : IEntidad
    {
        public object Id { get; set; }
    }
}
