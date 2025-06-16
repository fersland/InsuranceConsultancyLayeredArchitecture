using CSG_ADMINPRO.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSG_ADMINPRO.DOMAIN.Entities;

public partial class Cliente
{
    public int Id { get; set; }

    [Required]
    [StringLength(10, MinimumLength = 10, ErrorMessage = "La cédula debe tener 10 dígitos.")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "La cédula debe contener solo números.")]
    [CedulaEcuatorianaValidation(ErrorMessage = "La cédula ecuatoriana no es válida.")]
    public string Cedula { get; set; } = null!;

    [Required]
    [RegularExpression(@"^[A-Za-zÁÉÍÓÚáéíóúÑñ\s]+$", ErrorMessage = "Solo se permiten letras y espacios.")]
    public string NombreCliente { get; set; } = null!;

    [Required]
    [RegularExpression(@"^\d{1,13}$", ErrorMessage = "El teléfono debe contener hasta 13 dígitos sin espacios.")]
    public string? Telefono { get; set; }

    [Required]
    [Range(18, 120, ErrorMessage = "La edad debe ser mayor o igual a 18.")]
    public int? Edad { get; set; }

    public virtual ICollection<Asegurado> Asegurados { get; set; } = new List<Asegurado>();

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual ICollection<Poliza>? Polizas { get; set; }
}
