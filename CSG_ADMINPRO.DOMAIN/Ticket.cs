using System;
using System.Collections.Generic;

namespace CSG_ADMINPRO.DOMAIN;

public partial class Ticket
{
    public int Id { get; set; }

    public int ClienteId { get; set; }

    public int UsuarioId { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public DateTime? FechaResolucion { get; set; }

    public int TipoTicketId { get; set; }

    public int EstadoId { get; set; }

    public string? Prioridad { get; set; }

    public string? Asunto { get; set; }

    public string? Descripcion { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Estado Estado { get; set; } = null!;

    public virtual ICollection<TicketsComentario> TicketsComentarios { get; set; } = new List<TicketsComentario>();

    public virtual Usuario Usuario { get; set; } = null!;
}
