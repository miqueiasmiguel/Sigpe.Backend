using Microsoft.AspNetCore.Mvc;
using Sigpe.Backend.Application.Dtos;
using Sigpe.Backend.Application.Interfaces.Services;

namespace Sigpe.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanoSaudeController : ControllerBase
    {
        private readonly IPlanoSaudeService _planoSaudeService;

        public PlanoSaudeController(IPlanoSaudeService planoSaudeService)
        {
            _planoSaudeService = planoSaudeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var planosSaudeDto = await _planoSaudeService.GetAsync();

            return Ok(planosSaudeDto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var planosSaudeDto = await _planoSaudeService.GetByIdAsync(id);

            return Ok(planosSaudeDto);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] PlanoSaudeDto dto)
        {
            var especialidadeDto = await _planoSaudeService.CreateAsync(dto);

            return Ok(especialidadeDto);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _planoSaudeService.DeleteAsync(id);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] PlanoSaudeDto dto)
        {
            var especialidadeDto = await _planoSaudeService.UpdateAsync(dto);

            return Ok(especialidadeDto);
        }
    }
}
