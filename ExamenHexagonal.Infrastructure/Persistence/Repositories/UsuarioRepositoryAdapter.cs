using ExamenHexagonal.Domain.Entities;
using ExamenHexagonal.Domain.Ports.Out;
using ExamenHexagonal.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExamenHexagonal.Infrastructure.Persistence.Repositories;

public class UsuarioRepositoryAdapter : IUsuarioRepositoryPort
{
    private readonly AppDbContext _context;

    public UsuarioRepositoryAdapter(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Usuario> GuardarAsync(Usuario usuario)
    {
        var entity = ToEntity(usuario);

        if (entity.Id == 0)
            _context.Usuarios.Add(entity);
        else
            _context.Usuarios.Update(entity);

        await _context.SaveChangesAsync();

        return ToDomain(entity);
    }

    public async Task<Usuario?> BuscarPorIdAsync(long id)
    {
        var entity = await _context.Usuarios.FindAsync(id);
        return entity is null ? null : ToDomain(entity);
    }

    public async Task<IReadOnlyList<Usuario>> ListarAsync()
    {
        var entities = await _context.Usuarios.AsNoTracking().ToListAsync();
        return entities.Select(ToDomain).ToList();
    }

    public async Task EliminarAsync(long id)
    {
        var entity = await _context.Usuarios.FindAsync(id);
        if (entity is null) return;

        _context.Usuarios.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<Usuario>> BuscarPorNombreAsync(string nombreParcial)
    {
        var entities = await _context.Usuarios
            .AsNoTracking()
            .Where(u => u.NombreCompleto.Contains(nombreParcial))
            .ToListAsync();

        return entities.Select(ToDomain).ToList();
    }

    private static UsuarioEntity ToEntity(Usuario usuario)
    {
        return new UsuarioEntity
        {
            Id = usuario.Id,
            NombreCompleto = usuario.NombreCompleto,
            Email = usuario.Email,
            Rol = usuario.Rol,
            Estado = usuario.Activo ? (byte)1 : (byte)0,
            FechaRegistro = usuario.FechaRegistro
        };
    }

    private static Usuario ToDomain(UsuarioEntity entity)
    {
        var usuario = new Usuario
        {
            Id = entity.Id,
            NombreCompleto = entity.NombreCompleto,
            Email = entity.Email,
            Rol = entity.Rol
        };

        if (entity.Estado == 1)
            usuario.Activar();
        else
            usuario.Desactivar();

        return usuario;
    }
}
