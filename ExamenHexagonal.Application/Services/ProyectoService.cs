using ExamenHexagonal.Domain.Entities;
using ExamenHexagonal.Domain.Ports.In;
using ExamenHexagonal.Domain.Ports.Out;

namespace ExamenHexagonal.Application.Services;

public class ProyectoService : IProyectoUseCase
{
    private readonly IProyectoRepositoryPort _proyectoRepository;

    public ProyectoService(IProyectoRepositoryPort proyectoRepository)
    {
        _proyectoRepository = proyectoRepository;
    }

    public async Task<Proyecto> CrearProyectoAsync(Proyecto proyecto)
    {
        return await _proyectoRepository.GuardarAsync(proyecto);
    }

    public async Task<Proyecto> ActualizarProyectoAsync(long id, Proyecto proyecto)
    {
        var existente = await _proyectoRepository.BuscarPorIdAsync(id)
                        ?? throw new KeyNotFoundException("Proyecto no encontrado");

        existente.Nombre = proyecto.Nombre;
        existente.Descripcion = proyecto.Descripcion;
        existente.FechaInicio = proyecto.FechaInicio;
        existente.FechaFin = proyecto.FechaFin;
        existente.Estado = proyecto.Estado;
        existente.IdResponsable = proyecto.IdResponsable;

        return await _proyectoRepository.GuardarAsync(existente);
    }

    public async Task<Proyecto> ObtenerProyectoAsync(long id)
    {
        return await _proyectoRepository.BuscarPorIdAsync(id)
               ?? throw new KeyNotFoundException("Proyecto no encontrado");
    }

    public async Task<IReadOnlyList<Proyecto>> ListarProyectosAsync()
    {
        return await _proyectoRepository.ListarAsync();
    }

    public async Task EliminarProyectoAsync(long id)
    {
        await _proyectoRepository.EliminarAsync(id);
    }
}
