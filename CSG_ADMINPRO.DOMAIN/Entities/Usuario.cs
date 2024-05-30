using System;
using System.Collections.Generic;

namespace CSG_ADMINPRO.DOMAIN.Entities;

public partial class Usuario
{
    public int Id { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string CorreoUsuario { get; set; } = null!;

    public string ClaveUsuario { get; set; } = null!;

    public DateTime FechaCrecion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int EstadoId { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual Estado Estado { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual ICollection<TicketsComentario> TicketsComentarios { get; set; } = new List<TicketsComentario>();
}
