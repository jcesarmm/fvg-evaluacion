using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Promociones.Domain.Entities.Common
{
    public interface IEntidad
    {
        [BsonId]
        object Id { get; set; }
    }
}
