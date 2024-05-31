using CSG_ADMINPRO.DATA.Configuration;
using CSG_ADMINPRO.DATA.Repository.Interfaces;
using CSG_ADMINPRO.DOMAIN.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG_ADMINPRO.DATA.Repository.Implementation
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IDbConnection _connection;
        private readonly SP_Bitacora _bitacora;

        public UsuarioRepository(IDbConnection connection,
                IOptions<SP_Bitacora> bitacora)
        {
            _connection = connection;
            _bitacora = bitacora.Value;
        }

        public IEnumerable<Usuario> GetAll()
        {
            try
            {
                return _connection.Query<Usuario>(_bitacora.GetAllUsuario, commandType: CommandType.StoredProcedure);
            }
            catch (SqlException ex)
            {
                throw new Exception("Ha ocurrido un error al ejecutar el Store Procedure", ex);
            }

            catch (Exception ex)
            {
                throw new Exception("Hubo un error", ex);
            }
        }

        public Usuario GetById(int id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, DbType.Int32);
                return _connection.QueryFirst<Usuario>(_bitacora.GetByIdUsuario, parameters, commandType: CommandType.StoredProcedure);
            }
            catch (SqlException ex)
            {
                throw new Exception("Ha ocurrido un error al ejecutar el Store Procedure", ex);
            }

            catch (Exception ex)
            {
                throw new Exception("Hubo un error", ex);
            }
        }

        public void Insert(Usuario usuario)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@NombreUsuario", usuario.NombreUsuario, DbType.String);
                parameters.Add("@CorreoUsuario", usuario.CorreoUsuario, DbType.String);
                parameters.Add("@ClaveUsuario", usuario.ClaveUsuario, DbType.String);
                parameters.Add("@Estado", usuario.EstadoId, DbType.Int32);
                _connection.Execute(_bitacora.AddUsuario, parameters, commandType: CommandType.StoredProcedure);
            }
            catch (SqlException ex)
            {
                throw new Exception("Ha ocurrido un error al ejecutar el Store Procedure", ex);
            }

            catch (Exception ex)
            {
                throw new Exception("Hubo un error", ex);
            }
        }

        public void Update(int id, Usuario usuario)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, DbType.Int32);
                parameters.Add("@NombreUsuario", usuario.NombreUsuario, DbType.String);
                parameters.Add("@CorreoUsuario", usuario.CorreoUsuario, DbType.String);
                parameters.Add("@Estado", usuario.EstadoId, DbType.Int32);
                _connection.Execute(_bitacora.EditUsuario, parameters, commandType: CommandType.StoredProcedure);
            }
            catch (SqlException ex)
            {
                throw new Exception("Ha ocurrido un error al ejecutar el Store Procedure", ex);
            }

            catch (Exception ex)
            {
                throw new Exception("Hubo un error", ex);
            }
        }
        public void Delete(int id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, DbType.Int32);
                _connection.Execute(_bitacora.DeleteUsuario, parameters, commandType: CommandType.StoredProcedure);
            }
            catch (SqlException ex)
            {
                throw new Exception("Ha ocurrido un error al ejecutar el Store Procedure", ex);
            }

            catch (Exception ex)
            {
                throw new Exception("Hubo un error", ex);
            }
        }
    }
}
