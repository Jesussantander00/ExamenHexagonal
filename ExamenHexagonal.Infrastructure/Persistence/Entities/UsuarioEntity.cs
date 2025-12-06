using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenHexagonal.Infrastructure.Persistence.Entities;

[Table("usuarios")]
public class UsuarioEntity
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Required]
    [Column("nombre_completo")]
    public string NombreCompleto { get; set; } = default!;

    [Required]
    [Column("email")]
    public string Email { get; set; } = default!;

    [Required]
    [Column("rol")]
    public string Rol { get; set; } = default!;

    [Required]
    [Column("estado")]
    public byte Estado { get; set; } = 1; // 1 = activo, 0 = inactivo

    [Required]
    [Column("fecha_registro")]
    public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
}
