using CSG_ADMINPRO.DOMAIN.Entities.CSG_ADMINPRO.DOMAIN.Entities.CSG_ADMINPRO.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG_ADMINPRO.DOMAIN.Entities
{
    public class Reclamacion
    {
        public int Id { get; set; }

        // Relaciones
        public int PolizaId { get; set; }
        public Poliza Poliza { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        // Detalles de la reclamación
        public DateTime FechaReclamacion { get; set; } = DateTime.Now;

        public decimal MontoReclamado { get; set; }

        public string Descripcion { get; set; } = string.Empty;

        public string Estado { get; set; } = "Pendiente"; // Pendiente, Aprobada, Rechazada

        public string? Resolucion { get; set; } // Comentario/respuesta si fue procesada

        public DateTime? FechaResolucion { get; set; }

        // Auditoría
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime? FechaModificacion { get; set; }
    }
}
