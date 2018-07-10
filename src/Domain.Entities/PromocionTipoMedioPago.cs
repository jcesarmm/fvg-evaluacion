using System.ComponentModel.DataAnnotations.Schema;

namespace Promociones.Domain.Entities
{
    [Table("PromocionesTiposMedioPago")]
    public class PromocionTipoMedioPago
    {
        public int PromocionId { get; set; }
        public int TipoMedioPagoId { get; set; }
    }
}