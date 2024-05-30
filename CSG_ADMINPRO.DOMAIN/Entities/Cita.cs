using System;
using System.Collections.Generic;

namespace CSG_ADMINPRO.DOMAIN.Entities;

public partial class Cita
{
    public int CitaId { get; set; }

    public int ClienteId { get; set; }

    public int UsuarioId { get; set; }

    public int AseguradoId { get; set; }

    public int SeguroId { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly Hora { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaActualizcion { get; set; }

    public string? Motivo { get; set; }

    public string? Notas { get; set; }

    public string? Ubicacion { get; set; }

    public int EstadoId { get; set; }

    public virtual Asegurado Asegurado { get; set; } = null!;

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual ICollection<Consulta> Consulta { get; set; } = new List<Consulta>();

    public virtual Estado Estado { get; set; } = null!;

    public virtual Seguro Seguro { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
