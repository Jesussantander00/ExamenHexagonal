using ExamenHexagonal.Domain.Entities;

namespace ExamenHexagonal.Domain.Ports.Out;

public interface IProyectoRepositoryPort
{
    Task<Proyecto> GuardarAsync(Proyecto proyecto);
    Task<Proyecto?> BuscarPorIdAsync(long id);
    Task<IReadOnlyList<Proyecto>> ListarAsync();
    Task EliminarAsync(long id);
    Task<IReadOnlyList<Proyecto>> BuscarPorEstadoAsync(string estado);
}
