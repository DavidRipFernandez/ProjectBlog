using BlogTecorp.Application.DTO;
using BlogTecorp.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogTecorp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteService _clienteService;
        public ClientesController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var clientes = await _clienteService.GetAllAsync();
            return Ok(clientes);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClienteDTO dto)
        {
            await _clienteService.AddAsync(dto);
            return StatusCode(StatusCodes.Status201Created, "Cliente creado exitosamente");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ClienteDTO dto)
        {
            var actualizado = await _clienteService.UpdateAsync(id, dto);

            if (!actualizado)
                return NotFound("Cliente no encontrado");

            return Ok("Cliente actualizado correctamente");
        }
    }
}