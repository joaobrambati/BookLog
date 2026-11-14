using Application.DTOs.Usuario;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookLogApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _service;

    public UsuarioController(IUsuarioService service)
    {
        _service = service;
    }

    [HttpPost("criarUsuario")]
    public async Task<IActionResult> Create([FromBody] CreateUsuarioDto dto)
    {
        var response = await _service.Create(dto);

        if (!response.Status) return BadRequest(response);

        return Ok(response);
    }

    [HttpGet("obterUsuarioPorId/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var response = await _service.GetById(id);

        if (!response.Status) return NotFound(response);

        return Ok(response);
    }

    [HttpPut("editarUsuario/{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateUsuarioDto dto)
    {
        var response = await _service.Update(id, dto);

        if (!response.Status) return NotFound(response);

        return Ok(response);
    }

}
