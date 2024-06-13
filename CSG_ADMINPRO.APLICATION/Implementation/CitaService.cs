using CSG_ADMINPRO.APLICATION.Interfaces;
using CSG_ADMINPRO.APLICATION.ViewModel;
using CSG_ADMINPRO.DATA.Repository.Interfaces;
using CSG_ADMINPRO.DOMAIN.DTO;
using CSG_ADMINPRO.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG_ADMINPRO.APLICATION.Implementation
{
    public class CitaService : ICitaService
    {
        private ICitaRepository _repository;

        public CitaService(ICitaRepository citaRepository)
        {
            _repository = citaRepository;
        }

        public async Task<IEnumerable<CitaDTO>> GetAllCitaAsync()
        {
            return await Task.Run(() => _repository.GetAll());
        }

        public async Task<Cita> GetByIdAsync(int id)
        {
            return await Task.Run(() => _repository.GetById(id));
        }
        public async Task CreateCitaAsync(CitaCreateDTO cita)
        {
            await Task.Run(() => _repository.Insert(cita));
        }

        public async Task UpdateCitaAsync(int id, CitaUpdateDTO cita)
        {
            await Task.Run(() => _repository.Update(id, cita));
        }

        public async Task DeleteCitaAsync(int id)
        {
            await Task.Run(() => _repository.Delete(id));
        }
    }
}
