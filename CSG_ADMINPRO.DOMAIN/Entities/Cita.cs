using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CSG_ADMINPRO.DOMAIN.Entities;

public partial class Cita
{
    [Key]
    public int CitaId { get; set; }
    [Required(ErrorMessage = "Este campo es obligatorio")]
    [Display(Name = "Cliente")]
    public int ClienteId { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio")]
    [Display(Name = "Fecha Cita")]
    public DateTime Fecha { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaActualizcion { get; set; }
    
    [Required(ErrorMessage = "Este campo es obligatorio")]
    [StringLength(120, ErrorMessage = "Solo se permiten entre 20 a 120 caracteres.", MinimumLength = 20)]
    [Display(Name = "MOTIVO DE CITA")]
    public string? Motivo { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio")]
    [StringLength(120, ErrorMessage = "Solo se permiten entre 20 a 250 caracteres.", MinimumLength = 20)]
    [Display(Name = "NOTA")]
    public string? Notas { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio")]
    [StringLength(120, ErrorMessage = "Solo se permiten entre 20 a 120 caracteres.", MinimumLength = 20)]
    [Display(Name = "Ubicación")]
    public string? Ubicacion { get; set; }

    [Required]
    public int EstadoId { get; set; }

    public virtual Asegurado Asegurado { get; set; } = null!;

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual ICollection<Consulta> Consulta { get; set; } = new List<Consulta>();

    public virtual Estado Estado { get; set; } = null!;

    public virtual Seguro Seguro { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
