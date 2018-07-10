using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Promociones.Domain.Entities
{
    [Table("PromocionesEntidadesFinancieras")]
    public class PromocionEntidadFinanciera
    {
        public int EntidadFinancieraId { get; set; }
        public int PromocionId { get; set; }

    }
}
