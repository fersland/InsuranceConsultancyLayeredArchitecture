using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG_ADMINPRO.DATA.Configuration
{
    public class SP_Bitacora
    {
        public string AddSeguro { get; set; }
        public string EditSeguro { get; set; }
        public string DeleteSeguro { get; set; }
        public string GetByIdSeguro { get; set; }
        public string GetAllSeguro { get; set; }

        public string AddCliente { get; set; }
        public string EditCliente { get; set; }
        public string DeleteCliente { get; set; }
        public string GetByIdCliente { get; set; }
        public string GetAllCliente { get; set; }

        public string AddAsegurada { get; set; }
        public string EditAsegurada { get; set; }
        public string DeleteAsegurada { get; set; }
        public string GetByIdAsegurada { get; set; }
        public string GetAllAsegurada { get; set; }

        public string GetAllUsuario { get; set; }
        public string GetByIdUsuario { get; set; }
        public string AddUsuario { get; set; }
        public string EditUsuario { get; set; }
        public string DeleteUsuario { get; set; }

        public string GetAllEstado { get; set; }

        public string GetAllCita { get; set; }
        public string AddCita { get; set; }
        public string EditCita { get; set; }
        public string DeleteCita { get; set; }

        public string GetByIdCita { get; set; }
    }
}
