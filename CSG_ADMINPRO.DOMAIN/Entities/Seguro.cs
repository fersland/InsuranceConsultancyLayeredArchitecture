using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSG_ADMINPRO.DOMAIN.Entities;

public partial class Seguro
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    [StringLength(50)]
    [Display(Name = "Código del Seguro")]
    public string Codigo { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    [StringLength(150)]
    [Display(Name = "Nombre del Seguro")]
    public string NombreSeguro { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    [RegularExpression("^(([1-9]{1}|[\\d]{2,})(\\.[\\d]+)?)$", ErrorMessage = "Solo se permiten numeros.")]
    [Display(Name = "Valor Asegurado")]
    public string Asegurada { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    [RegularExpression("^(([1-9]{1}|[\\d]{2,})(\\.[\\d]+)?)$", ErrorMessage = "Solo se permiten numeros.")]
    [Display(Name = "Valor de Prima")]
    public string Prima { get; set; }

    public virtual ICollection<Asegurado> Asegurados { get; set; } = new List<Asegurado>();

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();
}
