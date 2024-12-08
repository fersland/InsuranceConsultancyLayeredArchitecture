using System;
using System.Collections.Generic;

namespace CSG_ADMINPRO.DOMAIN;

public partial class Cliente
{
    public int Id { get; set; }

    public string Cedula { get; set; } = null!;

    public string NombreCliente { get; set; } = null!;

    public string? Telefono { get; set; }

    public int? Edad { get; set; }

    public virtual ICollection<Asegurado> Asegurados { get; set; } = new List<Asegurado>();

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
