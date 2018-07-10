using Promociones.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Promociones.Infrastructure.Common
{
    public interface IRepositorioGenerico<T> where T : Entidad
    {
        IEnumerable<T> ObtenerTodos();
        IEnumerable<T> Buscar(Expression<Func<T, bool>> filtro);

        void Insertar(T entity);
        void Eliminar(T entity);
        void Actualizar(T entity);

        int GuardarCambios();
    }
}
