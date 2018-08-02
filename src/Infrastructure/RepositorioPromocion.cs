using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Promociones.Domain.Entities;
using Promociones.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Promociones.Infrastructure
{
    public class RepositorioPromocion : RepositorioGenericoMongoDB<Promocion>, IRepositorioPromocion
    {
        public RepositorioPromocion(IMongoClient mongoClient) : base(mongoClient)
        {
        }
    }
}
