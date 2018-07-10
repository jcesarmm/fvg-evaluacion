using Microsoft.EntityFrameworkCore;
using Promociones.Domain.Entities.Common;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Promociones.Infrastructure.Common
{
    public abstract class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : Entidad
    {
        protected DbContext context;
        protected readonly DbSet<T> dbset;

        public RepositorioGenerico(DbContext context)
        {
            this.context = context;
            dbset = context.Set<T>();
        }
        public void Actualizar(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<T> Buscar(Expression<Func<T, bool>> filtro)
        {
            return dbset.Where(filtro).AsEnumerable();
        }

        public void Eliminar(T entity)
        {
            dbset.Remove(entity);
        }

        public void Insertar(T entity)
        {
            dbset.Add(entity);
        }

        public IEnumerable<T> ObtenerTodos()
        {
            return dbset.AsEnumerable<T>();
        }

        public int GuardarCambios()
        {
            return context.SaveChanges();
        }
    }
}
