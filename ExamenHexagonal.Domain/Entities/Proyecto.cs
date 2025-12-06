namespace ExamenHexagonal.Domain.Entities;

public class Proyecto
{
    public long Id { get; set; }
    public string Nombre { get; set; } = default!;
    public string? Descripcion { get; set; }
    public DateTime? FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }
    public string Estado { get; set; } = "PLANEADO"; // PLANEADO, EN_CURSO, FINALIZADO
    public long? IdResponsable { get; set; }

    public bool EstaEnCurso() => Estado == "EN_CURSO";
}
