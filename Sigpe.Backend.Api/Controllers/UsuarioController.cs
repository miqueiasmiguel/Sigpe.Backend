using Microsoft.AspNetCore.Mvc;
using Sigpe.Backend.Application.Dtos;
using Sigpe.Backend.Application.Interfaces.Services;

namespace Sigpe.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var usuariosDto = await _usuarioService.GetAsync();

            return Ok(usuariosDto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var usuariosDto = await _usuarioService.GetByIdAsync(id);

            return Ok(usuariosDto);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] UsuarioDto dto)
        {
            var usuarioDto = await _usuarioService.CreateAsync(dto);

            return Ok(usuarioDto);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _usuarioService.DeleteAsync(id);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] UsuarioDto dto)
        {
            var usuarioDto = await _usuarioService.UpdateAsync(dto);

            return Ok(usuarioDto);
        }
    }
}
