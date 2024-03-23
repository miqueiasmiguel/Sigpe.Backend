using Microsoft.AspNetCore.Mvc;
using Sigpe.Backend.Application.Dtos;
using Sigpe.Backend.Application.Interfaces.Services;

namespace Sigpe.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoService _medicoService;

        public MedicoController(IMedicoService medicoService)
        {
            _medicoService = medicoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var medicosDto = await _medicoService.GetAsync();

            return Ok(medicosDto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var medicosDto = await _medicoService.GetByIdAsync(id);

            return Ok(medicosDto);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] MedicoDto dto)
        {
            var medicoDto = await _medicoService.CreateAsync(dto);

            return Ok(medicoDto);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _medicoService.DeleteAsync(id);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] MedicoDto dto)
        {
            var medicoDto = await _medicoService.UpdateAsync(dto);

            return Ok(medicoDto);
        }
    }
}
