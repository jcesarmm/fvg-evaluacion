using MongoDB.Bson.Serialization.Attributes;
using Promociones.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Promociones.Domain.Entities
{
    public class Promocion : EntidadAuditable
    {
        public Promocion(int[] tipoMedioPagoId, int[] entidadFinancieraId, int[] medioPagoId, int? maxCantidadDeCuotas, int[] productoCategoriaIds, decimal? porcentajeDescuento,
            DateTime fechaInicio, DateTime fechaFin, bool activo)
        {
            TipoMedioPagoId = tipoMedioPagoId;
            EntidadFinancieraId = entidadFinancieraId;
            MedioPagoId = medioPagoId;
            MaxCantidadDeCuotas = maxCantidadDeCuotas;
            ProductoCategoriaIds = productoCategoriaIds;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            Activo = activo;
        }


        [BsonElement("TipoMedioPagoId")]
        public int[] TipoMedioPagoId { get; private set; } //Representa el Id del Tipo de Medio de pago en la que aplica la promoción. Ejemplo: Visa , Amex, Efectivo (esta información esta guardada en el microservicio de Medio de Pago)

        [BsonElement("EntidadFinancieraId")]
        public int[] EntidadFinancieraId { get; private set; } // Representa el Id de la entidad Finaciera en la que aplica la promoción. Ejemplo: Banco Galicia, Banco Rio  (esta información esta guardada en el microservicio de Medio de Pago)

        [BsonElement("MedioPagoId")]
        public int[] MedioPagoId { get; private set; } //Representa el Id del Medio de pago en la que aplica la promoción. Ejemplo: Tarjeta Visa Galicia Gold, Tarjeta Amex Frances Platinium, Efectivo Pesos, Efectivo Dollar (esta información esta guardada en el microservicio de Medio de Pago)

        [BsonElement("MaxCantidadDeCuotas")]
        public int? MaxCantidadDeCuotas { get; private set; } //Representa la cantidad maxima de cuotas en la que aplica la promoción.

        [BsonElement("ProductoCategoriaIds")]
        public int[] ProductoCategoriaIds { get; private set; } //Representa los Ids de las Categorias de los Items en la cual aplica la promoción (Estas categorias estan en el Microservicio de Productos)

        [BsonElement("PorcentajeDecuento")]
        public decimal? PorcentajeDescuento { get; private set; } //Representa el porcentaje de descuento a Aplicar en el Producto

        [BsonElement("FechaInicio")]
        public DateTime FechaInicio { get; private set; }

        [BsonElement("FechaFin")]
        public DateTime FechaFin { get; private set; }

        [BsonElement("Activo")]
        public bool Activo { get; private set; }
    }
}
