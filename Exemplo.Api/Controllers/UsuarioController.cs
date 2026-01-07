using Exemplo.Application.Services;
using Exemplo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Exemplo.Api.Controllers;

public class UsuarioController : BaseApiController
{
    private readonly UsuarioService _service;

    public UsuarioController(UsuarioService service)
    {
        _service = service;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] Usuario usuario)
    {
        var result = await _service.CriarAsync(usuario);
        return Ok(result);
    }
}
