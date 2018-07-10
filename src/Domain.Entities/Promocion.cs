using Promociones.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Promociones.Domain.Entities
{
    public class Promocion : EntidadAuditable
    {
        public Promocion()
        {
            PromocionEntidadesFinancieras = new List<PromocionEntidadFinanciera>();
            PromocionMediosPago = new List<PromocionMedioPago>();
            PromocionTiposMedioPago = new List<PromocionTipoMedioPago>();
            PromocionProductoCategorias = new List<PromocionProductoCategoria>();
        }
        public Promocion(int id, int? maxCantidadDeCuotas,decimal? porcentajeDecuento, bool activo, List<PromocionEntidadFinanciera>  promocionEntidadesFinancieras,
            List<PromocionMedioPago> promocionMediosPago, List<PromocionTipoMedioPago> promocionTiposMedioPago, List<PromocionProductoCategoria> promocionProductoCategorias)
        {
            PromocionTiposMedioPago = promocionTiposMedioPago;
            PromocionEntidadesFinancieras = promocionEntidadesFinancieras;
            PromocionMediosPago = promocionMediosPago;
            PromocionProductoCategorias = promocionProductoCategorias;
            MaxCantidadDeCuotas = maxCantidadDeCuotas;
            PorcentajeDecuento = porcentajeDecuento;
            Activo = activo;
        }

        public List<PromocionTipoMedioPago> PromocionTiposMedioPago { private set; get; } //Representa el Id del Tipo de Medio de pago en la que aplica la promoción. Ejemplo: Visa , Amex, Efectivo (esta información esta guardada en el microservicio de Medio de Pago)

        public List<PromocionEntidadFinanciera> PromocionEntidadesFinancieras { private set; get; }// Representa el Id de la entidad Finaciera en la que aplica la promoción. Ejemplo: Banco Galicia, Banco Rio  (esta información esta guardada en el microservicio de Medio de Pago)

        public List<PromocionMedioPago> PromocionMediosPago { private set; get; } //Representa el Id del Medio de pago en la que aplica la promoción. Ejemplo: Tarjeta Visa Galicia Gold, Tarjeta Amex Frances Platinium, Efectivo Pesos, Efectivo Dollar (esta información esta guardada en el microservicio de Medio de Pago)

        public int? MaxCantidadDeCuotas { private set; get; } //Representa la cantidad maxima de cuotas en la que aplica la promoción.

        public List<PromocionProductoCategoria> PromocionProductoCategorias { private set; get; } //Representa los Ids de las Categorias de los Items en la cual aplica la promoción (Estas categorias estan en el Microservicio de Productos)

        public decimal? PorcentajeDecuento { private set; get; } //Representa el porcentaje de descuento a Aplicar en el Producto

        public DateTime FechaInicio { private set; get; }

        public DateTime FechaFin { private set; get; }

        public bool Activo { private set; get; }

        public List<int> ObtenerTipoMediosPagoId()
        {
            return PromocionTiposMedioPago.Select(med => med.TipoMedioPagoId).ToList();
        }
        public List<int> ObtenerMediosPagoId()
        {
            return PromocionMediosPago.Select(med => med.MedioPagoId).ToList();
        }
        public List<int> ObtenerCategoriaIds()
        {
            return PromocionProductoCategorias.Select(cat => cat.CategoriaId).ToList();
        }

    }
}
