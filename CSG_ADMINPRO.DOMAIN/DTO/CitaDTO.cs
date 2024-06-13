using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG_ADMINPRO.DOMAIN.DTO
{
    public class CitaDTO
    {
        public int CitaId { get; set; }
        public string CedulaCliente { get; set; }
        public string NombreCliente { get; set; }
        public string CodigoSeguro { get; set; }
        public string NombreDelSeguro { get; set; }        
        public DateTime FechaCita { get; set; }
        public TimeSpan HoraCita { get; set; }
        public DateTime FechaCreacionCita { get; set; }
        public string Motivo { get; set; }
        public string Notas { get; set; }
        public string Ubicacion { get; set; }
        public int EstadoId { get; set; }
    }
}
