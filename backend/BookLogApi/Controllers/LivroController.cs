using Application.DTOs.Livro;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookLogApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LivroController : ControllerBase
{
    private readonly ILivroService _service;

    public LivroController(ILivroService service)
    {
        _service = service;
    }

    [HttpGet("obterTodosLivros")]
    public async Task<IActionResult> GetAll()
    {
        var response = await _service.GetAll();

        if (!response.Status) return NotFound(response);

        return Ok(response);
    }

    [HttpGet("obterLivroPorId/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var response = await _service.GetById(id);

        if (!response.Status) return NotFound(response);

        return Ok(response);
    }

    [HttpPost("criarLivro")]
    public async Task<IActionResult> Create([FromBody] CreateLivroDto dto)
    {
        var response = await _service.Create(dto);

        if (!response.Status) return BadRequest(response);

        return Ok(response);
    }

    [HttpPut("editarLivro/{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateLivroDto dto)
    {
        var response = await _service.Update(id, dto);

        if (!response.Status) return NotFound(response);

        return Ok(response);
    }

    [HttpDelete("excluirLivro/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _service.Delete(id);

        if (!response.Status) return NotFound(response);

        return Ok(response);
    }

}
