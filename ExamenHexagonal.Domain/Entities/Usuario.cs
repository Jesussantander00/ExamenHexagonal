namespace ExamenHexagonal.Domain.Entities;

public class Usuario
{
    public long Id { get; set; }
    public string NombreCompleto { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Rol { get; set; } = default!;
    public bool Activo { get; private set; } = true;
    public DateTime FechaRegistro { get; private set; } = DateTime.UtcNow;

    public void Activar() => Activo = true;

    public void Desactivar() => Activo = false;
}
