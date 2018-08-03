using MongoDB.Bson;
using Promociones.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Promociones.Domain.Core.Common
{
    public interface IServicio<T> where T : Entidad
    {
        Task<string> Insertar(T entidad);

        T ObtenerPorId(object id);

        IEnumerable<T> ObtenerTodos();

        void Actualizar(T entidad);

        void Eliminar(object id);

    }
}
