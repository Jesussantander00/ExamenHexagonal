using ExamenHexagonal.Domain.Entities;
using ExamenHexagonal.Domain.Ports.In;
using ExamenHexagonal.Domain.Ports.Out;

namespace ExamenHexagonal.Application.Services;

public class UsuarioService : IUsuarioUseCase
{
    private readonly IUsuarioRepositoryPort _usuarioRepository;

    public UsuarioService(IUsuarioRepositoryPort usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<Usuario> CrearUsuarioAsync(Usuario usuario)
    {
        // Validaciones simples se pueden hacer aquí
        return await _usuarioRepository.GuardarAsync(usuario);
    }

    public async Task<Usuario> ActualizarUsuarioAsync(long id, Usuario usuario)
    {
        var existente = await _usuarioRepository.BuscarPorIdAsync(id)
                       ?? throw new KeyNotFoundException("Usuario no encontrado");

        existente.NombreCompleto = usuario.NombreCompleto;
        existente.Email = usuario.Email;
        existente.Rol = usuario.Rol;

        if (usuario.Activo)
            existente.Activar();
        else
            existente.Desactivar();

        return await _usuarioRepository.GuardarAsync(existente);
    }

    public async Task<Usuario> ObtenerUsuarioAsync(long id)
    {
        return await _usuarioRepository.BuscarPorIdAsync(id)
               ?? throw new KeyNotFoundException("Usuario no encontrado");
    }

    public async Task<IReadOnlyList<Usuario>> ListarUsuariosAsync()
    {
        return await _usuarioRepository.ListarAsync();
    }

    public async Task EliminarUsuarioAsync(long id)
    {
        await _usuarioRepository.EliminarAsync(id);
    }
}
