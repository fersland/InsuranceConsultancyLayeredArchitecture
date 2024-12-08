using System;
using System.Collections.Generic;

namespace CSG_ADMINPRO.DOMAIN;

public partial class Seguro
{
    public int Id { get; set; }

    public string Codigo { get; set; } = null!;

    public string NombreSeguro { get; set; } = null!;

    public decimal? Asegurada { get; set; }

    public decimal? Prima { get; set; }

    public virtual ICollection<Asegurado> Asegurados { get; set; } = new List<Asegurado>();
}
