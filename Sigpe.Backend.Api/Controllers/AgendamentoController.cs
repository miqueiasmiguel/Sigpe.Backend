using Microsoft.AspNetCore.Mvc;
using Sigpe.Backend.Application.Dtos;
using Sigpe.Backend.Application.Interfaces.Services;
using Sigpe.Backend.Application.Services;

namespace Sigpe.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly IAgendamentoService _agendamentoService;

        public AgendamentoController(IAgendamentoService especialidadeService)
        {
            _agendamentoService = especialidadeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var agendamentosDto = await _agendamentoService.GetAsync();

                return Ok(agendamentosDto);
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
                var agendamentosDto = await _agendamentoService.GetByIdAsync(id);

                return Ok(agendamentosDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
        }

        [HttpGet]
        [Route("Medico/{id}")]
        public async Task<IActionResult> GetByMedicoIdAsync(int id)
        {
            try
            {
                var agendamentosDto = await _agendamentoService.GetByMedicoIdAsync(id);

                return Ok(agendamentosDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
        }

        [HttpGet]
        [Route("Paciente/{id}")]
        public async Task<IActionResult> GetByPacienteIdAsync(int id)
        {
            try
            {
                var agendamentosDto = await _agendamentoService.GetByPacienteIdAsync(id);

                return Ok(agendamentosDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AgendamentoDto dto)
        {
            try
            {
                var agendamentoDto = await _agendamentoService.CreateAsync(dto);

                return Ok(agendamentoDto);
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
                await _agendamentoService.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] AgendamentoDto dto)
        {
            try
            {
                var agendamentoDto = await _agendamentoService.UpdateAsync(dto);

                return Ok(agendamentoDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
        }
    }
}
