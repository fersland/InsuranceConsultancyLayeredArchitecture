using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CSG_ADMINPRO.DOMAIN.DTO
{
    public class CitaCreateDTO
    {

        public int ClienteId { get; set; }

        public int UsuarioId { get; set; }

        public int AseguradoId { get; set; }

        public DateTime Fecha { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string? Motivo { get; set; }

        public string? Notas { get; set; }

        public string? Ubicacion { get; set; }
        
    }
}
