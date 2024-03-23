using Microsoft.AspNetCore.Mvc;
using Sigpe.Backend.Application.Dtos;
using Sigpe.Backend.Application.Interfaces.Services;

namespace Sigpe.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescricaoController : ControllerBase
    {
        private readonly IPrescricaoService _prescricaoService;

        public PrescricaoController(IPrescricaoService prescricaoService)
        {
            _prescricaoService = prescricaoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var prescricoesDto = await _prescricaoService.GetAsync();

                return Ok(prescricoesDto);
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
                var prescricoesDto = await _prescricaoService.GetByIdAsync(id);

                return Ok(prescricoesDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] PrescricaoDto dto)
        {
            try
            {
                var prescricaoDto = await _prescricaoService.CreateAsync(dto);

                return Ok(prescricaoDto);
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
                await _prescricaoService.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] PrescricaoDto dto)
        {
            try
            {
                var prescricaoDto = await _prescricaoService.UpdateAsync(dto);

                return Ok(prescricaoDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
        }
    }
}
