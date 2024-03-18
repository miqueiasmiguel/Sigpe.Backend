using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sigpe.Backend.Application.Dtos;
using Sigpe.Backend.Application.Interfaces;

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
            var prescricoesDto = await _prescricaoService.GetAsync();

            return Ok(prescricoesDto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var prescricoesDto = await _prescricaoService.GetByIdAsync(id);

            return Ok(prescricoesDto);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] PrescricaoDto dto)
        {
            var prescricaoDto = await _prescricaoService.CreateAsync(dto);

            return Ok(prescricaoDto);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _prescricaoService.DeleteAsync(id);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] PrescricaoDto dto)
        {
            var prescricaoDto = await _prescricaoService.UpdateAsync(dto);

            return Ok(prescricaoDto);
        }
    }
}
