using Compartido.DTOs.Propietario;
using LogicaAplicacion.Propietarios;
using LogicaNegocio.EntidadesExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/propietarios")]
    [ApiController]
    public class PropietariosController : ControllerBase
    {
        private readonly IServiciosPropietario _serviciosPropietario;
        public PropietariosController(IServiciosPropietario serviciosPropietario)
        {
            _serviciosPropietario = serviciosPropietario;
        }

        [HttpGet]
        public async Task<IActionResult> GetPropietarios()
        {
            try
            {
                var res = await _serviciosPropietario.GetPropietarios();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
            

        [HttpGet("{propietarioId}")]
        public async Task<IActionResult> GetPropietarioById(string propietarioId)
        {
            try
            {
                var res = await _serviciosPropietario.GetPropietarioById(propietarioId);
                return Ok(res);
            }
            catch(PropietarioException pex)
            {
                return NotFound(new { pex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpGet("publicaciones-propietario/{propietarioId}")]
        public async Task<IActionResult> GetInmueblesPropietario(string propietarioId)
        {
            try
            {
                var listaRes = await _serviciosPropietario.SelectInmueblesPropietario(propietarioId);
                return Ok(listaRes);
            }
            catch (PropietarioException pex)
            {
                return NotFound(new { pex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarPropietario([FromBody] PropietarioInsertDTO propietarioInsertDTO)
        {
            try
            {
                var res = await _serviciosPropietario.InsertPropietario(propietarioInsertDTO);
                return CreatedAtAction(nameof(RegistrarPropietario), res.PropietarioId, res);
            }
            catch(PropietarioException pex)
            {
                return NotFound(new { pex.Message });
            }
            catch(Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarPropietario([FromBody] PropietarioUpdateDTO propietarioUpdateDTO)
        {
            try
            {
                var res = await _serviciosPropietario.UpdatePropietario(propietarioUpdateDTO);
                return Ok(res);
            }
            catch (PropietarioException pex)
            {
                return NotFound(new { pex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpDelete("propietarioId")]
        public async Task<IActionResult> EliminarPropietario(string propietarioId)
        {
            try
            {
                await _serviciosPropietario.DeletePropietario(propietarioId);
                return NoContent();
            }
            catch(PropietarioException pex)
            {
                return NotFound(new { pex.Message });
            }
            catch(Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
    }
}
