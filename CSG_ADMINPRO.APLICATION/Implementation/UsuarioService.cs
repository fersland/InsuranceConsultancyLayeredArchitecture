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
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuarioAsync()
        {
            return await Task.Run(() => _repository.GetAll());
        }

        public async Task<Usuario> GetByIdUsuarioAsync(int id)
        {
            return await Task.Run(() => _repository.GetById(id));
        }
        public async Task CreateUsuarioAsync(Usuario usuario)
        {
            await Task.Run(() => _repository.Insert(usuario));
        }

        public async Task UpdateUsuarioAsync(int id, Usuario usuario)
        {
            await Task.Run(() => _repository.Update(id, usuario));
        }

        public async Task DeleteUsuarioAsync(int id)
        {
            await Task.Run(() => _repository.Delete(id));
        }
    }
}
