﻿using Promociones.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Promociones.Domain.Entities
{
    public class Categoria: Entidad
    {
        [StringLength(50)]
        [Required]
        public string Descripcion { get; private set; }

        public List<PromocionProductoCategoria> PromocionesProductosCategorias { private set; get; }
    }
}
