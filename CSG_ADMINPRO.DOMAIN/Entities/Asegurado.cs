using System;
using System.Collections.Generic;

namespace CSG_ADMINPRO.DOMAIN.Entities;

public partial class Asegurado
{
    public int Id { get; set; }

    public int ClienteId { get; set; }

    public int SeguroId { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Seguro Seguro { get; set; } = null!;
}
