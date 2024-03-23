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
            var pacientesDto = await _pacienteService.GetAsync();

            return Ok(pacientesDto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var pacientesDto = await _pacienteService.GetByIdAsync(id);

            return Ok(pacientesDto);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] PacienteDto dto)
        {
            var pacienteDto = await _pacienteService.CreateAsync(dto);

            return Ok(pacienteDto);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _pacienteService.DeleteAsync(id);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] PacienteDto dto)
        {
            var pacienteDto = await _pacienteService.UpdateAsync(dto);

            return Ok(pacienteDto);
        }
    }
}
