using Compartido.DTOs.Inmueble;
using LogicaAplicacion.Inmuebles;
using LogicaNegocio.Entidades;
using LogicaNegocio.EntidadesExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/inmuebles")]
    [ApiController]
    public class InmueblesController : ControllerBase
    {
        private readonly IServiciosInmueble _serviciosInmueble;
        public InmueblesController(IServiciosInmueble serviciosInmueble)
        {
            _serviciosInmueble = serviciosInmueble;
        }

        [HttpGet]
        public async Task<IActionResult> GetInmueblesPorFiltro([FromQuery] FiltroInmueble filtroInmueble)
        {
            try
            {
                var res = await _serviciosInmueble.SelectInmueblesByFilter(filtroInmueble);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpGet("{inmuebleId}")]
        public async Task<IActionResult> GetInmuebleById(string inmuebleId)
        {
            try
            {
                var res = await _serviciosInmueble.SelectInmuebleById(inmuebleId);
                return Ok(res);
            }
            catch(InmuebleException iex)
            {
                return NotFound(new { iex.Message });
            }
            catch(Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostInmueble([FromBody] InmuebleInsertDTO inmuebleInsertDTO)
        {
            try
            {
                // Si lo inserta, devuelve un InmuebleDTO
                var res = await _serviciosInmueble.InsertInmueble(inmuebleInsertDTO);
                return CreatedAtAction(nameof(PostInmueble), res.InmuebleId, res);
            }
            catch (InmuebleException iex)
            {
                return BadRequest(new { iex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateInmueble([FromBody] InmuebleUpdateDTO inmuebleUpdateDTO)
        {
            try
            {
                var res = await _serviciosInmueble.UpdateInmueble(inmuebleUpdateDTO);
                return Ok(res);
            }
            catch(InmuebleException iex)
            {
                return NotFound(new {  iex.Message });
            }
            catch(Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpDelete("{inmuebleId}")]
        public async Task<IActionResult> EliminarInmueble(string inmuebleId)
        {
            try
            {
                await _serviciosInmueble.DeleteInmueble(inmuebleId);
                return NoContent();
            }
            catch(InmuebleException iex)
            {
                return NotFound( new { iex.Message });
            }
            catch(Exception ex)
            {
                return BadRequest( new { ex.Message });
            }
        }
    }
}
