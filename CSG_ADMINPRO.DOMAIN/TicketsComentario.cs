using System;
using System.Collections.Generic;

namespace CSG_ADMINPRO.DOMAIN;

public partial class TicketsComentario
{
    public int Id { get; set; }

    public int TicketId { get; set; }

    public int UsuarioId { get; set; }

    public DateTime FechaComentario { get; set; }

    public string Comentario { get; set; } = null!;

    public int TicketComentarioEstado { get; set; }

    public virtual Ticket Ticket { get; set; } = null!;

    public virtual Estado TicketComentarioEstadoNavigation { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
