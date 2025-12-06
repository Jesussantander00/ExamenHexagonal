using ExamenHexagonal.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExamenHexagonal.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<UsuarioEntity> Usuarios => Set<UsuarioEntity>();
    public DbSet<ProyectoEntity> Proyectos => Set<ProyectoEntity>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}
