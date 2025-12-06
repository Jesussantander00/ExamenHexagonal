using ExamenHexagonal.Domain.Entities;
using ExamenHexagonal.Domain.Ports.Out;
using ExamenHexagonal.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExamenHexagonal.Infrastructure.Persistence.Repositories;

public class ProyectoRepositoryAdapter : IProyectoRepositoryPort
{
    private readonly AppDbContext _context;

    public ProyectoRepositoryAdapter(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Proyecto> GuardarAsync(Proyecto proyecto)
    {
        var entity = ToEntity(proyecto);

        if (entity.Id == 0)
            _context.Proyectos.Add(entity);
        else
            _context.Proyectos.Update(entity);

        await _context.SaveChangesAsync();

        return ToDomain(entity);
    }

    public async Task<Proyecto?> BuscarPorIdAsync(long id)
    {
        var entity = await _context.Proyectos.FindAsync(id);
        return entity is null ? null : ToDomain(entity);
    }

    public async Task<IReadOnlyList<Proyecto>> ListarAsync()
    {
        var entities = await _context.Proyectos.AsNoTracking().ToListAsync();
        return entities.Select(ToDomain).ToList();
    }

    public async Task EliminarAsync(long id)
    {
        var entity = await _context.Proyectos.FindAsync(id);
        if (entity is null) return;

        _context.Proyectos.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<Proyecto>> BuscarPorEstadoAsync(string estado)
    {
        var entities = await _context.Proyectos
            .AsNoTracking()
            .Where(p => p.Estado == estado)
            .ToListAsync();

        return entities.Select(ToDomain).ToList();
    }

    private static ProyectoEntity ToEntity(Proyecto proyecto)
    {
        return new ProyectoEntity
        {
            Id = proyecto.Id,
            Nombre = proyecto.Nombre,
            Descripcion = proyecto.Descripcion,
            FechaInicio = proyecto.FechaInicio,
            FechaFin = proyecto.FechaFin,
            Estado = proyecto.Estado,
            IdResponsable = proyecto.IdResponsable
        };
    }

    private static Proyecto ToDomain(ProyectoEntity entity)
    {
        return new Proyecto
        {
            Id = entity.Id,
            Nombre = entity.Nombre,
            Descripcion = entity.Descripcion,
            FechaInicio = entity.FechaInicio,
            FechaFin = entity.FechaFin,
            Estado = entity.Estado,
            IdResponsable = entity.IdResponsable
        };
    }
}
