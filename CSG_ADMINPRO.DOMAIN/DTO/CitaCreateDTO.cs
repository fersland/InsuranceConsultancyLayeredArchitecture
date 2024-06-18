using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CSG_ADMINPRO.DOMAIN.DTO
{
    public class CitaCreateDTO
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Display(Name = "Fecha Cita")]
        public DateTime Fecha { get; set; }

        public DateTime FechaCreacion { get; set; }

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

    }
}
