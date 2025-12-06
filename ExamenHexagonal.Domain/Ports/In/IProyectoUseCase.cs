using ExamenHexagonal.Domain.Entities;

namespace ExamenHexagonal.Domain.Ports.In;

public interface IProyectoUseCase
{
    Task<Proyecto> CrearProyectoAsync(Proyecto proyecto);
    Task<Proyecto> ActualizarProyectoAsync(long id, Proyecto proyecto);
    Task<Proyecto> ObtenerProyectoAsync(long id);
    Task<IReadOnlyList<Proyecto>> ListarProyectosAsync();
    Task EliminarProyectoAsync(long id);
}
