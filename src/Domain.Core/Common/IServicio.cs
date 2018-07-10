﻿using Promociones.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Promociones.Domain.Core.Common
{
    public interface IServicio<T> where T : Entidad
    {
        void Insertar(T entidad);

        IEnumerable<T> ObtenerTodos();

        void Actualizar(T entidad);

        void Eliminar(int id);

    }
}
