using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG_ADMINPRO.DOMAIN.DTO
{
    public class CitaDTO
    {
        [Key]
        [Display(Name = "Id")]
        public int CitaId { get; set; }
        [Display(Name = "Cédula")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string CedulaCliente { get; set; }
        [Display(Name = "Cliente")]
        public string NombreCliente { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Display(Name = "Fecha Cita")]
        public DateTime FechaCita { get; set; }
        [Display(Name = "Fecha Registro")]
        public DateTime FechaCreacionCita { get; set; }
        [Display(Name = "Fecha Actualización")]
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
        public string NombreEstado { get; set; }
    }
}
