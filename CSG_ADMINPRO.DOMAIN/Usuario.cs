using System;
using System.Collections.Generic;

namespace CSG_ADMINPRO.DOMAIN;

public partial class Usuario
{
    public int Id { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string CorreoUsuario { get; set; } = null!;

    public string ClaveUsuario { get; set; } = null!;

    public DateTime FechaCrecion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int EstadoId { get; set; }

    public int? ClienteId { get; set; }

    public virtual Estado Estado { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual ICollection<TicketsComentario> TicketsComentarios { get; set; } = new List<TicketsComentario>();
}
