using ExamenHexagonal.Domain.Entities;

namespace ExamenHexagonal.Domain.Ports.In;

public interface IUsuarioUseCase
{
    Task<Usuario> CrearUsuarioAsync(Usuario usuario);
    Task<Usuario> ActualizarUsuarioAsync(long id, Usuario usuario);
    Task<Usuario> ObtenerUsuarioAsync(long id);
    Task<IReadOnlyList<Usuario>> ListarUsuariosAsync();
    Task EliminarUsuarioAsync(long id);
}
