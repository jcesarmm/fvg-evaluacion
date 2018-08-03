using Promociones.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Promociones.Domain.Core.Common;
using Promociones.Infrastructure.Common;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace Promociones.Presentation.Api.Services
{
    public abstract class ServicioBase<T> : IServicio<T> where T : Entidad
    {
        IRepositorioGenerico<T> repositorioGenerico;

        public ServicioBase(IRepositorioGenerico<T> repositorioGenerico)
        {
            this.repositorioGenerico = repositorioGenerico;
        }

        public virtual void Actualizar(T entidad)
        {
            repositorioGenerico.Actualizar(entidad);
        }

        public virtual void Eliminar(object id)
        {
            var entidad = repositorioGenerico.Buscar(t => t.Id == id).FirstOrDefault();
            if (entidad != null)
            {
                repositorioGenerico.Eliminar(entidad);
            }
        }

        public virtual Task<string> Insertar(T entidad)
        {
            repositorioGenerico.Insertar(entidad);
            return Task.FromResult("Ok");
        }

        public virtual T ObtenerPorId(object id)
        {
            return repositorioGenerico.ObtenerPorId(id);
        }

        public virtual IEnumerable<T> ObtenerTodos()
        {
            return repositorioGenerico.ObtenerTodos();
        }
    }
}
