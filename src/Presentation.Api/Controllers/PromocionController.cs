using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Promociones.Domain.Core;
using Promociones.Domain.Core.DTO;
using Promociones.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Promociones.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    public class PromocionController : Controller
    {
        private IServicioPromocion servicioPromocion;

        public PromocionController(IServicioPromocion servicioPromocion)
        {
            this.servicioPromocion = servicioPromocion;
        }

        /// <summary>
        /// Obtiene todas las promociones vigentes o no.
        /// </summary>
        /// <param name="vigentes">True: unicamente promociones vigentes, False: todas las promociones.</param>
        /// <returns>Listado de promociones</returns>
        [HttpGet("{vigentes:bool}")]
        public IEnumerable<Promocion> Get(bool vigentes = false)
        {
            if (vigentes)
                return servicioPromocion.ObtenerTodosVigentes();
            return servicioPromocion.ObtenerTodos();
        }

        /// <summary>
        /// Obtiene promociones vigentes a X Fecha
        /// </summary>
        /// <param name="fecha">fecha</param>
        /// <returns>Lista Promciones</returns>
        [HttpGet("{fecha:datetime}")]
        public IEnumerable<Promocion> Get(DateTime fecha)
        {
            return servicioPromocion.ObtenerTodosVigentesFecha(fecha);
        }
        /// <summary>
        /// Obtiene todas las promociones vigentes para una venta
        /// </summary>
        /// <param name="idMedioPago">Id medio de pago</param>
        /// <param name="idTipoMedioPago">Id tipo medio de pago</param>
        /// <param name="idEntidadFinanciera">Id entidad financiera</param>
        /// <param name="cantCuotas">Cantidad de cuotas</param>
        /// <param name="idCatProd">Id categoria producto</param>
        /// <returns></returns>
        [HttpGet("{idMedioPago:int}/{idTipoMedioPago:int}/{idEntidadFinanciera:int}/{cantCuotas:int}/{idCatProd:int}")]
        public IEnumerable<Promocion> Get(int idMedioPago, int idTipoMedioPago, int idEntidadFinanciera, int cantCuotas, int idCatProd)
        {
            PromocionDTO promocionDTO = new PromocionDTO(idMedioPago, idTipoMedioPago, idEntidadFinanciera, cantCuotas, idCatProd);

            return servicioPromocion.ObtenerTodosVigentesVenta(promocionDTO);
        }


        /// <summary>
        /// Retorna si una promocion esta vigente a la fecha
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public bool Get(int id)
        {
            return servicioPromocion.ValidarPromocionVigente(id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post(Promocion promocion)
        {
            servicioPromocion.Insertar(promocion);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, Promocion promocion)
        {
            servicioPromocion.Actualizar(promocion);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            servicioPromocion.Eliminar(id);
        }
    }
}
