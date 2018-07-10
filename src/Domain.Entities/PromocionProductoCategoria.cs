using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Promociones.Domain.Entities
{
    [Table("PromocionesProductosCategorias")]
    public class PromocionProductoCategoria
    {
        public int PromocionId { get; set; }
        public int CategoriaId { get; set; }
    }
}
