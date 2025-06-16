using CSG_ADMINPRO.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG_ADMINPRO.APLICATION.DTOs
{
    public class ClienteDTO
    {
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
        public string Telefono { get; set; }

        [Required]
        [Range(18, 120, ErrorMessage = "La edad debe ser mayor o igual a 18.")]
        public int Edad { get; set; }
    }

}
