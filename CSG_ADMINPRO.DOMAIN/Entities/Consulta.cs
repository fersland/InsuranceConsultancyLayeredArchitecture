using System;
using System.Collections.Generic;

namespace CSG_ADMINPRO.DOMAIN.Entities;

public partial class Consulta
{
    public int ConsultaId { get; set; }

    public int CitaId { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly Hora { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaActualizcion { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Resolucion { get; set; } = null!;

    public string? Notas { get; set; }

    public int EstadoId { get; set; }

    public virtual Cita Cita { get; set; } = null!;

    public virtual Estado Estado { get; set; } = null!;
}
