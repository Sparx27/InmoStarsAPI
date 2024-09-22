using Compartido.DTOs.Propietario;
using LogicaAplicacion.Propietarios;
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
                if (res == null)
                {
                    return NotFound("Usuario no encontrado por id");
                }
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpPost("registro-propietario")]
        public async Task<IActionResult> RegistrarPropietario([FromBody] PropietarioInsertDTO propietarioInsertDTO)
        {
            try
            {
                var res = await _serviciosPropietario.InsertPropietario(propietarioInsertDTO);
                return CreatedAtAction(nameof(RegistrarPropietario), res.PropietarioId, res);
            }
            catch(Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
    }
}
