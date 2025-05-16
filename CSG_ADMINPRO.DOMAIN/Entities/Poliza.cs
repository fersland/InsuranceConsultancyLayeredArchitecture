using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG_ADMINPRO.DOMAIN.Entities
{
    using System;

    namespace CSG_ADMINPRO.DOMAIN.Entities
    {
        using System;
        using System.Collections.Generic;

        namespace CSG_ADMINPRO.DOMAIN.Entities
        {
            public class Poliza
            {
                public int Id { get; set; }

                // Relaciones
                public int ClienteId { get; set; }
                public Cliente Cliente { get; set; }

                public int SeguroId { get; set; }
                public Seguro Seguro { get; set; }

                // Detalles de la póliza
                public string NumeroPoliza { get; set; } = string.Empty; // Código o número asignado

                public DateTime FechaEmision { get; set; }
                public DateTime FechaVencimiento { get; set; }

                public decimal MontoAsegurado { get; set; }
                public decimal Prima { get; set; }

                public string Estado { get; set; } = "Activa"; // Activa, Cancelada, Vencida, etc.

                public string? Notas { get; set; }

                // Auditoría
                public DateTime FechaCreacion { get; set; } = DateTime.Now;
                public DateTime? FechaModificacion { get; set; }

                // Opcional: si una póliza puede tener reclamaciones, relación 1 a muchos
                public ICollection<Reclamacion>? Reclamaciones { get; set; }

            }
        }

    }

}
