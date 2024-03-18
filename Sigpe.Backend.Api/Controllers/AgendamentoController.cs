using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sigpe.Backend.Application.Dtos;
using Sigpe.Backend.Application.Interfaces;

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
            var agendamentosDto = await _agendamentoService.GetAsync();

            return Ok(agendamentosDto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var agendamentosDto = await _agendamentoService.GetByIdAsync(id);

            return Ok(agendamentosDto);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AgendamentoDto dto)
        {
            var agendamentoDto = await _agendamentoService.CreateAsync(dto);

            return Ok(agendamentoDto);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _agendamentoService.DeleteAsync(id);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] AgendamentoDto dto)
        {
            var agendamentoDto = await _agendamentoService.UpdateAsync(dto);

            return Ok(agendamentoDto);
        }
    }
}
