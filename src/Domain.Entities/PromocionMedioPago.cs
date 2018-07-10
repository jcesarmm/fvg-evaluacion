using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Promociones.Domain.Entities
{
    [Table("PromocionesMediosPago")]
    public class PromocionMedioPago
    {
        public int MedioPagoId { get; set; }
        public int PromocionId { get; set; }

    }
}
