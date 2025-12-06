using ExamenHexagonal.Domain.Entities;
using ExamenHexagonal.Domain.Ports.In;
using Microsoft.AspNetCore.Mvc;

namespace ExamenHexagonal.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioUseCase _usuarioUseCase;

    public UsuariosController(IUsuarioUseCase usuarioUseCase)
    {
        _usuarioUseCase = usuarioUseCase;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Usuario>>> Get()
    {
        var usuarios = await _usuarioUseCase.ListarUsuariosAsync();
        return Ok(usuarios);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<Usuario>> Get(long id)
    {
        var usuario = await _usuarioUseCase.ObtenerUsuarioAsync(id);
        return Ok(usuario);
    }

    [HttpPost]
    public async Task<ActionResult<Usuario>> Post([FromBody] Usuario usuario)
    {
        var creado = await _usuarioUseCase.CrearUsuarioAsync(usuario);
        return CreatedAtAction(nameof(Get), new { id = creado.Id }, creado);
    }

    [HttpPut("{id:long}")]
    public async Task<ActionResult<Usuario>> Put(long id, [FromBody] Usuario usuario)
    {
        var actualizado = await _usuarioUseCase.ActualizarUsuarioAsync(id, usuario);
        return Ok(actualizado);
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        await _usuarioUseCase.EliminarUsuarioAsync(id);
        return NoContent();
    }
}
