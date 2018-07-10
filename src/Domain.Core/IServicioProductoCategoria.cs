using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Promociones.Domain.Core
{
    public interface IServicioProductoCategoria
    {
        Task<bool> ValidarCategoriasProducto(List<int> idsMediosPago);
    }
}
