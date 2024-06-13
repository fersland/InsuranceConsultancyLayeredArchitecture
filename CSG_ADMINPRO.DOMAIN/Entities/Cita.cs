using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CSG_ADMINPRO.DOMAIN.Entities;

public partial class Cita
{
    public int CitaId { get; set; }

    public int ClienteId { get; set; }

    public int UsuarioId { get; set; }

    public int AseguradoId { get; set; }
    public DateTime Fecha { get; set; }
    //[JsonIgnore]
    //public DateOnly Fecha { get; set; }
    //[JsonIgnore]
    //public TimeOnly Hora { get; set; }
    //// Propiedades auxiliares para la serialización
    //[JsonPropertyName("fecha")]
    //public string FechaString
    //{
    //    get => Fecha.ToString("yyyy-MM-dd");
    //    set => Fecha = DateOnly.Parse(value);
    //}

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
