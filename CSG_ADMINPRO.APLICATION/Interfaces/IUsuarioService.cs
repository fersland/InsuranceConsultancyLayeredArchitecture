using CSG_ADMINPRO.APLICATION.DTOs;
using CSG_ADMINPRO.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG_ADMINPRO.APLICATION.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> GetAllUsuarioAsync();
        Task<Usuario> GetByIdUsuarioAsync(int id);
        Task CreateUsuarioAsync(Usuario usuario);
        Task UpdateUsuarioAsync(int id, Usuario usuario);
        Task DeleteUsuarioAsync(int id);
    }
}
