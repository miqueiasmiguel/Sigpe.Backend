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
            try
            {
                var planosSaudeDto = await _planoSaudeService.GetAsync();

                return Ok(planosSaudeDto);
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
                var planosSaudeDto = await _planoSaudeService.GetByIdAsync(id);

                return Ok(planosSaudeDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] PlanoSaudeDto dto)
        {
            try
            {
                var especialidadeDto = await _planoSaudeService.CreateAsync(dto);

                return Ok(especialidadeDto);
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
                await _planoSaudeService.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] PlanoSaudeDto dto)
        {
            try
            {
                var especialidadeDto = await _planoSaudeService.UpdateAsync(dto);

                return Ok(especialidadeDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
        }
    }
}
