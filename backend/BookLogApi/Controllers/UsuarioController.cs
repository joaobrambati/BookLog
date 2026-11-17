using Application.DTOs.Usuario;
using Application.Services.Interfaces;
using BookLogApi.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookLogApi.Controllers;

// Sem id na rota: o usuário só acessa o próprio perfil (id vem do token)
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _service;

    public UsuarioController(IUsuarioService service)
    {
        _service = service;
    }

    [HttpGet("obterUsuario")]
    public async Task<IActionResult> GetById()
    {
        var response = await _service.GetById(User.ObterUsuarioId());

        if (!response.Status) return NotFound(response);

        return Ok(response);
    }

    [HttpPut("editarUsuario")]
    public async Task<IActionResult> Update([FromBody] UpdateUsuarioDto dto)
    {
        var response = await _service.Update(User.ObterUsuarioId(), dto);

        if (!response.Status) return NotFound(response);

        return Ok(response);
    }

    [HttpPut("atualizarFoto")]
    public async Task<IActionResult> AtualizarFoto(IFormFile arquivo)
    {
        var response = await _service.AtualizarFoto(User.ObterUsuarioId(), arquivo);

        if (!response.Status) return BadRequest(response);

        return Ok(response);
    }

}
