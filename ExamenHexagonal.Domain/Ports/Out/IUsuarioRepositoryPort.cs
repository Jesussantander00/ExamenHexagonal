using ExamenHexagonal.Domain.Entities;

namespace ExamenHexagonal.Domain.Ports.Out;

public interface IUsuarioRepositoryPort
{
    Task<Usuario> GuardarAsync(Usuario usuario);
    Task<Usuario?> BuscarPorIdAsync(long id);
    Task<IReadOnlyList<Usuario>> ListarAsync();
    Task EliminarAsync(long id);
    Task<IReadOnlyList<Usuario>> BuscarPorNombreAsync(string nombreParcial);
}
