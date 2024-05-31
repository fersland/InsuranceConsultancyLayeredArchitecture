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
    public class EstadoService : IEstadoService
    {
        private readonly IEstadoRepository _repository;

        public EstadoService(IEstadoRepository repository)
        {
            _repository = repository;    
        }

        public async Task<IEnumerable<Estado>> GetAllEstadoAsync()
        {
            return await Task.Run(() => _repository.GetAll());
        }
    }
}
