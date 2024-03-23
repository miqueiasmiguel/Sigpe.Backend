using Microsoft.AspNetCore.Mvc;
using Sigpe.Backend.Application.Dtos;
using Sigpe.Backend.Application.Interfaces.Services;

namespace Sigpe.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;

        public PacienteController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {

                var pacientesDto = await _pacienteService.GetAsync();

                return Ok(pacientesDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var pacientesDto = await _pacienteService.GetByIdAsync(id);

                return Ok(pacientesDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] PacienteDto dto)
        {
            try
            {
                var pacienteDto = await _pacienteService.CreateAsync(dto);

                return Ok(pacienteDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _pacienteService.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] PacienteDto dto)
        {
            try
            {
                var pacienteDto = await _pacienteService.UpdateAsync(dto);

                return Ok(pacienteDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
        }
    }
}
