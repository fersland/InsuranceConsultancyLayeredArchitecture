using CSG_ADMINPRO.DATA.Repository.Interfaces;
using CSG_ADMINPRO.DOMAIN.DTO;
using CSG_ADMINPRO.DOMAIN.Entities;
using CSG_ADMINPRO.APLICATION.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG_ADMINPRO.APLICATION.Implementation
{
    public class AseguradoService : IAseguradoService
    {
        private readonly IAseguradoRepository _repository;

        public AseguradoService(IAseguradoRepository repository)
        {
            _repository = repository;    
        }

        public async Task<IEnumerable<AseguradosDTO>> GetAllAseguradosAsync()
        {
            return await Task.Run(() => _repository.GetAll());
        }

        public async Task<Asegurado> GetByIdAseguradoAsync(int id)
        {
            return await Task.Run(() => _repository.GetById(id));
        }
        public async Task CreateAseguradoAsync(Asegurado asegurado)
        {
            await Task.Run(() => _repository.Insert(asegurado));
        }

        public async Task UpdateAseguradoAsync(int id, Asegurado asegurado)
        {
            await Task.Run(() => _repository.Update(id, asegurado));
        }

        public async Task DeleteAseguradoAsync(int id)
        {
            await Task.Run(() => _repository.Delete(id));
        }
    }
}
