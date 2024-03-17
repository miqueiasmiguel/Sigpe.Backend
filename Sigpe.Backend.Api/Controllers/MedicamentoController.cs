using Microsoft.AspNetCore.Http;
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

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] MedicamentoDto dto)
        {
            var medicamentoDto = _medicamentoService.CreateAsync(dto);

            return Ok(medicamentoDto);
        }
    }
}
