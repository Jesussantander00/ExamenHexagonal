using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenHexagonal.Infrastructure.Persistence.Entities;

[Table("proyectos")]
public class ProyectoEntity
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Required]
    [Column("nombre")]
    public string Nombre { get; set; } = default!;

    [Column("descripcion")]
    public string? Descripcion { get; set; }

    [Column("fecha_inicio")]
    public DateTime? FechaInicio { get; set; }

    [Column("fecha_fin")]
    public DateTime? FechaFin { get; set; }

    [Required]
    [Column("estado")]
    public string Estado { get; set; } = "PLANEADO";

    [Column("id_responsable")]
    public long? IdResponsable { get; set; }
}
