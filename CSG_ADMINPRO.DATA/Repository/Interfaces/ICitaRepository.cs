using CSG_ADMINPRO.DOMAIN.DTO;
using CSG_ADMINPRO.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG_ADMINPRO.DATA.Repository.Interfaces
{
    public interface ICitaRepository
    {
        IEnumerable<CitaDTO> GetAll();
        Cita GetById(int id);
        void Insert(CitaCreateDTO cita);
        void Update(int id, CitaUpdateDTO cita);
        void Delete(int id);
    }
}
