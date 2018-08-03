using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Promociones.Domain.Core;
using Promociones.Domain.Core.DTO;
using Promociones.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Promociones.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
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
        public IEnumerable<Promocion> Get([FromRoute]bool vigentes = false)
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
        public IEnumerable<Promocion> Get([FromRoute]DateTime fecha)
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
        public IEnumerable<Promocion> Get([FromRoute]int idMedioPago, [FromRoute]int idTipoMedioPago, [FromRoute]int idEntidadFinanciera, [FromRoute]int cantCuotas, [FromRoute]int idCatProd)
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
        public bool Get([FromRoute]int id)
        {
            return servicioPromocion.ValidarPromocionVigente(id);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Promocion promocion)
        {
            try
            {
                await servicioPromocion.Insertar(promocion);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch(ValidationException ve)
            {
                return StatusCode(406, ve.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(406, ex.Message);
            }

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put([FromRoute]int id, [FromBody]Promocion promocion)
        {
            servicioPromocion.Actualizar(promocion);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete([FromRoute]int id)
        {
            servicioPromocion.Eliminar(id);
        }
    }
}
