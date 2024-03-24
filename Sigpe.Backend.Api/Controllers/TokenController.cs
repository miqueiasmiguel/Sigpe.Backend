using Microsoft.AspNetCore.Mvc;
using Sigpe.Backend.Application.Dtos;
using Sigpe.Backend.Application.Interfaces.Services;

namespace Sigpe.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public TokenController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> PostTokenAsync([FromBody] LoginDto dto)
        {
            try
            {
                var result = await _usuarioService.GenerateTokenAsync(dto);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, ex.Message });
            }
        }
    }
}
