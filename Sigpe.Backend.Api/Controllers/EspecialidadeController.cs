using Microsoft.AspNetCore.Mvc;
using Sigpe.Backend.Application.Dtos;
using Sigpe.Backend.Application.Interfaces.Services;

namespace Sigpe.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadeController : ControllerBase
    {
        private readonly IEspecialidadeService _especialidadeService;

        public EspecialidadeController(IEspecialidadeService especialidadeService)
        {
            _especialidadeService = especialidadeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var especialidadesDto = await _especialidadeService.GetAsync();

            return Ok(especialidadesDto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var especialidadesDto = await _especialidadeService.GetByIdAsync(id);

            return Ok(especialidadesDto);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] EspecialidadeDto dto)
        {
            var especialidadeDto = await _especialidadeService.CreateAsync(dto);

            return Ok(especialidadeDto);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _especialidadeService.DeleteAsync(id);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] EspecialidadeDto dto)
        {
            var especialidadeDto = await _especialidadeService.UpdateAsync(dto);

            return Ok(especialidadeDto);
        }
    }
}
