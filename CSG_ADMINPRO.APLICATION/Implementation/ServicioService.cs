using CSG_ADMINPRO.APLICATION.Interfaces;
using CSG_ADMINPRO.DATA.Repository.Interfaces;
using CSG_ADMINPRO.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG_ADMINPRO.APLICATION.Implementation
{
    public class ServicioService : IServicioService
    {

        private IServicioRepository _repository;

        public ServicioService(IServicioRepository repository)
        {
            this._repository = repository;
        }

        public async Task<IEnumerable<Servicio>> GetAllServicioAsync()
        {
            return await Task.Run(() => _repository.GetAll());
        }

        public async Task<Servicio> GetByIdAsync(int id)
        {
            return await Task.Run(() => _repository.GetById(id) );
        }

        public async Task CreateServicioAsync(Servicio servicio)
        {
            await Task.Run(() => _repository.Insert(servicio));
        }

        public async Task DeleteServicioAsync(int id)
        {
            await Task.Run(() => _repository.Delete(id) );
        }


        public async Task UpdateServicioAsync(int id, Servicio servicio)
        {
            await Task.Run(() => _repository.Update(id, servicio));
        }
    }
}
