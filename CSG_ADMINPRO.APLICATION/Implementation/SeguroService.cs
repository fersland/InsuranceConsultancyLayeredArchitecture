using CSG_ADMINPRO.DATA.Repository.Interfaces;
using CSG_ADMINPRO.DOMAIN.Entities;
using CSG_ADMINPRO.APLICATION.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG_ADMINPRO.APLICATION.Implementation
{
    public class SeguroService : ISeguroService
    {
        private readonly ISeguroRepository _repository;

        public SeguroService(ISeguroRepository seguroRepository)
        {
            _repository = seguroRepository;    
        }

        public async Task<IEnumerable<Seguro>> GetAllSegurosAsync()
        {
            return await Task.Run(() => _repository.GetAll());
        }

        public async Task<Seguro> GetSeguroByIdAsync(int id)
        {
            return await Task.Run(() => _repository.GetById(id)); 
        }
        public async Task CreateSeguroAsync(Seguro seguro)
        {
            await Task.Run(() => _repository.Insert(seguro));
        }

        public async Task UpdateSeguroAsync(int id, Seguro seguro)
        {
            await Task.Run(() => _repository.Update(id, seguro));
        }

        public async Task DeleteSeguroAsync(int id)
        {
            await Task.Run(() => _repository.Delete(id));
        }
    }
}
