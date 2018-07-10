using Microsoft.EntityFrameworkCore;
using Promociones.Domain.Entities;
using Promociones.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Promociones.Infrastructure
{
    public class RepositorioPromocion : RepositorioGenerico<Promocion>, IRepositorioPromocion
    {
        public RepositorioPromocion(DbContext context) : base(context)
        {
        }
    }
}
