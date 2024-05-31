using CSG_ADMINPRO.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG_ADMINPRO.DATA.Repository.Interfaces
{
    public interface IEstadoRepository
    {
        IEnumerable<Estado> GetAll();
    }
}
