using Promociones.Domain.Core.Common;
using Promociones.Domain.Entities;
using Promociones.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Moq;
using Promociones.Domain.Core.DTO;
using Promociones.Domain.Core;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Promociones.Presentation.Api.Services
{
    public class ServicioPromocion : ServicioBase<Promocion>, IServicioPromocion
    {
        private IRepositorioPromocion repositorioPromocion;
        private IServicioMedioPago servicioMedioPago;
        private IServicioProductoCategoria servicioProductoCategoria;

        public ServicioPromocion(IRepositorioPromocion repositorioPromocion, IServicioMedioPago servicioMedioPago, IServicioProductoCategoria servicioProductoCategoria)
            : base(repositorioPromocion)
        {
            this.repositorioPromocion = repositorioPromocion;
            this.servicioMedioPago = servicioMedioPago;
            this.servicioProductoCategoria = servicioProductoCategoria;
        }

        public override async Task<string> Insertar(Promocion entidad)
        {
            if (ExisteDuplicidad(entidad.MedioPagoId, entidad.FechaInicio, entidad.FechaFin))
                throw new Exception("Existe otra promoción dentro de las mismas fechas");
            if (!await MedioPagoValido(entidad.MedioPagoId))
                throw new ValidationException("El medio de pago no es válido");
            if (!await CategoriaProductoValido(entidad.ProductoCategoriaIds))
                throw new ValidationException("Categoria de producto no válida");
            await base.Insertar(entidad);
            return "Ok";
        }

        private async Task<bool> CategoriaProductoValido(int[] list)
        {
            return await servicioProductoCategoria.ValidarCategoriasProducto(list);
        }

        private async Task<bool> MedioPagoValido(int[] list)
        {
            return await servicioMedioPago.ValidarMediosPago(list);
        }

        private bool ExisteDuplicidad(int[] idTipoMediosPago, DateTime fechaInicio, DateTime fechaFin)
        {
            return repositorioPromocion.Buscar(promo => (promo.FechaInicio <= fechaInicio && promo.FechaFin >= fechaFin) ||
            promo.FechaInicio <= fechaInicio && promo.FechaFin >= fechaInicio ||
            promo.FechaInicio >= fechaInicio && promo.FechaFin <= fechaFin).Any();
        }

        public IEnumerable<Promocion> ObtenerTodosVigentes()
        {
            return repositorioPromocion.Buscar(promo => promo.Activo == true);
        }

        public IEnumerable<Promocion> ObtenerTodosVigentesFecha(DateTime fecha)
        {
            return repositorioPromocion.Buscar(promo => promo.FechaInicio >= fecha && promo.FechaFin <= fecha.Date.AddDays(1));
        }

        public IEnumerable<Promocion> ObtenerTodosVigentesVenta(PromocionDTO promocionDTO)
        {
            return repositorioPromocion.Buscar(promo => promo.MedioPagoId.Contains(promocionDTO.IdMedioPago) &&
            promo.TipoMedioPagoId.Contains(promocionDTO.IdTipoMedioPago) &&
            promo.EntidadFinancieraId.Contains(promocionDTO.IdEntidadFinanciera) &&
            promo.ProductoCategoriaIds.Contains(promocionDTO.IdCatProd) &&
            promo.MaxCantidadDeCuotas == promocionDTO.CantCuotas &&
            promo.FechaInicio <= DateTime.Now.Date && promo.FechaFin >= DateTime.Now.Date.AddDays(1));
        }

        public bool ValidarPromocionVigente(object id)
        {
            Promocion promocion = repositorioPromocion.Buscar(promo => promo.Id == id).FirstOrDefault();
            if (promocion != null)
                return promocion.FechaInicio <= DateTime.Now.Date && promocion.FechaFin >= DateTime.Now.Date.AddDays(1);
            return false;
        }
    }
}
