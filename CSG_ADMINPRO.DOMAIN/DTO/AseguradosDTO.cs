using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG_ADMINPRO.DOMAIN.DTO
{
    public class AseguradosDTO
    {
        public int Id { get; set; }
        public string Cedula { get; set; } = null!;
        public string NombreCliente { get; set; } = null!;
        public string Codigo { get; set; } = null!;
        public string NombreSeguro { get; set; } = null!;
        public decimal? Asegurada { get; set; }
        public decimal? Prima { get; set; }
    }
}
