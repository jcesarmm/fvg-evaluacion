using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Promociones.Domain.Entities.Common
{
    public abstract class Entidad : IEntidad
    {
        [Key]
        public int Id { get; set; }
    }
}
