using Promociones.Domain.Core.Common;
using Promociones.Domain.Entities;
using Promociones.Infrastructure;
using Promociones.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace Promociones.Domain.Core
{
    public class ServicioPromocion : Servicio<Promocion>, IServicioPromocion
    {
        IRepositorioPromocion repositorioPromocion;
        public ServicioPromocion(IRepositorioPromocion repositorioPromocion)
            : base(repositorioPromocion)
        {
            this.repositorioPromocion = repositorioPromocion;
        }

        public override async void Insertar(Promocion entidad)
        {
            if (ExisteDuplicidad(entidad.ObtenerTipoMediosPagoId(), entidad.FechaInicio, entidad.FechaFin))
                throw new Exception("Existe otra promoción dentro de las mismas fechas");
            if (!await MedioPagoValido(entidad.ObtenerMediosPagoId()))
                throw new Exception("El medio de pago no es válido");
            if (!await CategoriaProductoValido(entidad.ObtenerCategoriaIds()))
                throw new Exception("Categoria de producto no válida");
            base.Insertar(entidad);
        }

        private async Task<bool> CategoriaProductoValido(List<int> list)
        {
            foreach (var idCatProducto in list)
            {
                HttpResponseMessage response = null;
                using (var httpClient = new HttpClient())
                {
                    response = await httpClient.GetAsync(string.Format("http://xxx.xxx.xx/producto/categorias/", idCatProducto));
                    if (!response.IsSuccessStatusCode)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private async Task<bool> MedioPagoValido(List<int> list)
        {
            foreach (var idMedioPago in list)
            {
                HttpResponseMessage response = null;
                using (var httpClient = new HttpClient())
                {
                    response = await httpClient.GetAsync(string.Format("http://xxx.xxx.xx/mediodepago/", idMedioPago));
                    if (!response.IsSuccessStatusCode)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool ExisteDuplicidad(List<int> idTipoMediosPago, DateTime fechaInicio, DateTime fechaFin)
        {
            return repositorioPromocion.Buscar(promo => (promo.FechaInicio <= fechaInicio && promo.FechaFin >= fechaFin) ||
            promo.FechaInicio >= fechaInicio && promo.FechaFin >= fechaFin ||
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

        public IEnumerable<Promocion> ObtenerTodosVigentesVenta(int idMedioPago, int idTipoMedioPago, int idEntidadFinanciera, int cantCuotas, int idCatProd)
        {
            return repositorioPromocion.Buscar(promo => promo.PromocionMediosPago.Select(mediopago => mediopago.MedioPagoId).Contains(idMedioPago) &&
            promo.PromocionTiposMedioPago.Select(tipomediopago => tipomediopago.TipoMedioPagoId).Contains(idTipoMedioPago) &&
            promo.PromocionEntidadesFinancieras.Select(entidadfinanciera => entidadfinanciera.EntidadFinancieraId).Contains(idEntidadFinanciera) &&
            promo.PromocionProductoCategorias.Select(productocategoria => productocategoria.CategoriaId).Contains(idCatProd) &&
            promo.MaxCantidadDeCuotas == cantCuotas &&
            promo.FechaInicio <= DateTime.Now.Date && promo.FechaFin >= DateTime.Now.Date.AddDays(1));
        }

        public bool ValidarPromocionVigente(int id)
        {
            Promocion promocion = repositorioPromocion.Buscar(promo => promo.Id == id).FirstOrDefault();
            if (promocion != null)
                return promocion.FechaInicio <= DateTime.Now.Date && promocion.FechaFin >= DateTime.Now.Date.AddDays(1);
            return false;
        }
    }
}
