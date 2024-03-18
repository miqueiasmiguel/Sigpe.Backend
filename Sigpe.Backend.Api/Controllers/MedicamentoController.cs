using Microsoft.AspNetCore.Mvc;
using Sigpe.Backend.Application.Dtos;
using Sigpe.Backend.Application.Interfaces;

namespace Sigpe.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicamentoController : ControllerBase
    {
        private readonly IMedicamentoService _medicamentoService;

        public MedicamentoController(IMedicamentoService medicamentoService)
        {
            _medicamentoService = medicamentoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var medicamentosDto = await _medicamentoService.GetAsync();

            return Ok(medicamentosDto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var medicamentosDto = await _medicamentoService.GetByIdAsync(id);

            return Ok(medicamentosDto);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] MedicamentoDto dto)
        {
            var medicamentoDto = await _medicamentoService.CreateAsync(dto);

            return Ok(medicamentoDto);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _medicamentoService.DeleteAsync(id);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] MedicamentoDto dto)
        {
            var medicamentoDto = await _medicamentoService.UpdateAsync(dto);

            return Ok(medicamentoDto);
        }
    }
}
