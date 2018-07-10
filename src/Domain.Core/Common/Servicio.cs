using Promociones.Domain.Entities.Common;
using Promociones.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Promociones.Domain.Core.Common
{
    public abstract class Servicio<T> : IServicio<T> where T : Entidad
    {
        IRepositorioGenerico<T> repositorioGenerico;

        public Servicio(IRepositorioGenerico<T> repositorioGenerico)
        {
            this.repositorioGenerico = repositorioGenerico;
        }

        public virtual void Actualizar(T entidad)
        {
            repositorioGenerico.Actualizar(entidad);
            repositorioGenerico.GuardarCambios();
        }

        public virtual void Eliminar(int id)
        {
            var entidad = repositorioGenerico.Buscar(t => t.Id == id).FirstOrDefault();
            if (entidad != null)
            {
                repositorioGenerico.Eliminar(entidad);
                repositorioGenerico.GuardarCambios();
            }
        }

        public virtual void Insertar(T entidad)
        {
            repositorioGenerico.Insertar(entidad);
            repositorioGenerico.GuardarCambios();
        }

        public virtual IEnumerable<T> ObtenerTodos()
        {
            return repositorioGenerico.ObtenerTodos();
        }
    }
}
