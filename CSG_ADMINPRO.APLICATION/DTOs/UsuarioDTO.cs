using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG_ADMINPRO.APLICATION.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }

        public string NombreUsuario { get; set; } = null!;

        public string CorreoUsuario { get; set; } = null!;

        public int EstadoId { get; set; }
    }
}
