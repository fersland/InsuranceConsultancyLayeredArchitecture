using System;
using System.Collections.Generic;

namespace CSG_ADMINPRO.DOMAIN.Entities;

public partial class TicketsTipo
{
    public int TicketTpoId { get; set; }

    public string NombreTicketTipo { get; set; } = null!;

    public int TicketTipoEstado { get; set; }

    public virtual Estado TicketTipoEstadoNavigation { get; set; } = null!;
}
