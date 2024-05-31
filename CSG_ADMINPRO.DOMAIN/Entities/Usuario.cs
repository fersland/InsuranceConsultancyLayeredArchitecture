using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSG_ADMINPRO.DOMAIN.Entities;

public partial class Usuario
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio")]
    [StringLength(24, ErrorMessage = "Solo se permiten un mínimo de 4 a 24 caracteres", MinimumLength = 4)]
    [Display(Name = "Nombre de Usuario")]
    public string NombreUsuario { get; set; } = null!;

    [Required(ErrorMessage = "Este campo es obligatorio")]
    [Display(Name = "Correo Electrónico")]
    public string CorreoUsuario { get; set; } = null!;

    [Required(ErrorMessage = "Este campo es obligatorio")]
    [Display(Name = "Clave de Usuario")]
    public string ClaveUsuario { get; set; } = null!;

    
    public DateTime FechaCrecion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio")]
    [Display(Name = "Estado de Usuario")]
    public int EstadoId { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual Estado Estado { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual ICollection<TicketsComentario> TicketsComentarios { get; set; } = new List<TicketsComentario>();
}
