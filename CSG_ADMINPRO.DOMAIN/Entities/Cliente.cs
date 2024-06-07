using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSG_ADMINPRO.DOMAIN.Entities;

public partial class Cliente
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten numeros")]
    [StringLength(10, ErrorMessage = "La longitud de este campo es de 10 caracteres", MinimumLength = 10)]
    [Display(Name = "Cédula")]
    public string Cedula { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    [StringLength(40, ErrorMessage = "La longitud permitida es de 2 a 40 caracteres", MinimumLength = 3)]
    [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Solo se permiten letras.")]
    [Display(Name = "Nombre Cliente")]
    public string NombreCliente { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten numeros")]
    [StringLength(10, ErrorMessage = "La longitud de este campo es de 4 numeros", MinimumLength = 10)]
    [Display(Name = "Teléfono")]
    public string Telefono { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    [Range(18, 80, ErrorMessage = "La edad permitida debe ser de 18 a 80 años")]
    [Display(Name = "Edad")]
    public int Edad { get; set; }

    public virtual ICollection<Asegurado> Asegurados { get; set; } = new List<Asegurado>();

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
