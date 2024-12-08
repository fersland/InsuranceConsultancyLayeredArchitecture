using System;
using System.Collections.Generic;

namespace CSG_ADMINPRO.DOMAIN;

public partial class Estado
{
    public int Id { get; set; }

    public string? NombreEstado { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual ICollection<Consulta> Consulta { get; set; } = new List<Consulta>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual ICollection<TicketsComentario> TicketsComentarios { get; set; } = new List<TicketsComentario>();

    public virtual ICollection<TicketsTipo> TicketsTipos { get; set; } = new List<TicketsTipo>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
