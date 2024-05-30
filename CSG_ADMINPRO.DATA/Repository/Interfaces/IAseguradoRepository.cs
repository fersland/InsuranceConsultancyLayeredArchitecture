using CSG_ADMINPRO.DOMAIN.DTO;
using CSG_ADMINPRO.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG_ADMINPRO.DATA.Repository.Interfaces
{
    public interface IAseguradoRepository
    {
        IEnumerable<AseguradosDTO> GetAll();
        Asegurado GetById(int id);
        void Insert(Asegurado asegurado);
        void Update(int id, Asegurado asegurado);
        void Delete(int id);
    }
}
