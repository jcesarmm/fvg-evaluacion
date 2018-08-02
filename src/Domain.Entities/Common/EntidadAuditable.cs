using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Promociones.Domain.Entities.Common
{
    public abstract class EntidadAuditable : Entidad, IEntidadAuditable
    {
        [BsonElement("FechaCreacion")]
        public DateTime FechaCreacion { get; set; }

        [BsonElement("FechaModificacion")]
        public DateTime? FechaModificacion { get; set; }
    }
}
