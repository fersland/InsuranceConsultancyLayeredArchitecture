using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG_ADMINPRO.APLICATION.ViewModel
{
    public class CitaViewModel
    {
        public int CitaId { get; set; }
        public string NombreDelSeguro { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Motivo { get; set; }
        public string Notas { get; set; }
        public string Ubicacion { get; set; }
        public int EstadoId { get; set; }
    }
}
