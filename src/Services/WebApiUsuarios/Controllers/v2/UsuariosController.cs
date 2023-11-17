using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Usuarios.Application.DTO;
using Usuarios.Application.Interface.UseCases;

namespace WebApiUsuarios.Controllers.v2
{
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class UsuariosController : ControllerBase
    {

        private readonly IUsuariosApplication _usuariosApplication;

        public UsuariosController(IUsuariosApplication usuariosApplication)
        {
            _usuariosApplication = usuariosApplication;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] UsuarioDto usuarioDto)
        {
            if (usuarioDto == null)
                return BadRequest();
            var response = await _usuariosApplication.Create(usuarioDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UsuarioDto usuarioDto)
        {
            var customerDtoExists = await _usuariosApplication.Get(id);
            if (customerDtoExists.Data == null)
                return NotFound(customerDtoExists);

            if (usuarioDto == null)
                return BadRequest();
            var response = await _usuariosApplication.Update(usuarioDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _usuariosApplication.Delete(id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _usuariosApplication.Get(id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _usuariosApplication.GetAll();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

    }
}
