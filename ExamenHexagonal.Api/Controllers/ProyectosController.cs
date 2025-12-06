using ExamenHexagonal.Domain.Entities;
using ExamenHexagonal.Domain.Ports.In;
using Microsoft.AspNetCore.Mvc;

namespace ExamenHexagonal.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProyectosController : ControllerBase
{
    private readonly IProyectoUseCase _proyectoUseCase;

    public ProyectosController(IProyectoUseCase proyectoUseCase)
    {
        _proyectoUseCase = proyectoUseCase;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Proyecto>>> Get()
    {
        var proyectos = await _proyectoUseCase.ListarProyectosAsync();
        return Ok(proyectos);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<Proyecto>> Get(long id)
    {
        var proyecto = await _proyectoUseCase.ObtenerProyectoAsync(id);
        return Ok(proyecto);
    }

    [HttpPost]
    public async Task<ActionResult<Proyecto>> Post([FromBody] Proyecto proyecto)
    {
        var creado = await _proyectoUseCase.CrearProyectoAsync(proyecto);
        return CreatedAtAction(nameof(Get), new { id = creado.Id }, creado);
    }

    [HttpPut("{id:long}")]
    public async Task<ActionResult<Proyecto>> Put(long id, [FromBody] Proyecto proyecto)
    {
        var actualizado = await _proyectoUseCase.ActualizarProyectoAsync(id, proyecto);
        return Ok(actualizado);
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        await _proyectoUseCase.EliminarProyectoAsync(id);
        return NoContent();
    }
}
