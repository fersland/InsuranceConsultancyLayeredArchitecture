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
    public class ClienteRepository : IClienteRepository
    {
        private readonly IDbConnection _connection;
        private readonly SP_Bitacora _bitacora;

        public ClienteRepository(IDbConnection dbConnection,
                                    IOptions<SP_Bitacora> bitacora)
        {
            this._connection = dbConnection;
            _bitacora = bitacora.Value;
        }

        public IEnumerable<Cliente> GetAll()
        {
            try
            {
                return _connection.Query<Cliente>(_bitacora.GetAllCliente, commandType: CommandType.StoredProcedure);
            }
            catch (SqlException ex)
            {
                throw new Exception("Ha ocurrido un error al ejecutar el Store Procedure", ex);
            }

            catch(Exception ex)
            {
                throw new Exception("Hubo un error", ex);
            }
        }

        public Cliente GetById(int id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, DbType.Int32);
                return _connection.QueryFirst<Cliente>(_bitacora.GetByIdCliente, parameters, commandType: CommandType.StoredProcedure);
            }
            catch(SqlException ex)
            {
                throw new Exception("Ha ocurrido un error al ejecutar el Store Procedure", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error", ex);
            }
        }

        public void Insert(Cliente cliente)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Cedula", cliente.Cedula, DbType.String);
                parameters.Add("@NombreCliente", cliente.NombreCliente, DbType.String);
                parameters.Add("@Telefono", cliente.Telefono, DbType.String);
                parameters.Add("@Edad", cliente.Edad, DbType.Int32);
                _connection.Execute(_bitacora.AddCliente, parameters, commandType: CommandType.StoredProcedure);
            }
            catch (SqlException ex)
            {
                throw new Exception("La cedula ya existe en la base de datos.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error", ex);
            }
        }

        public void Update(int id, Cliente cliente)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, DbType.Int32);
                parameters.Add("@Cedula", cliente.Cedula, DbType.String);
                parameters.Add("@NombreCliente", cliente.NombreCliente, DbType.String);
                parameters.Add("@Telefono", cliente.Telefono, DbType.String);
                parameters.Add("@Edad", cliente.Edad, DbType.Int32);
                _connection.Execute(_bitacora.EditCliente, parameters, commandType: CommandType.StoredProcedure);
            }
            catch (SqlException ex)
            {
                throw new Exception("Error: verifique los datos, puede que la cedula ya exista.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, DbType.Int32);
                _connection.Execute(_bitacora.DeleteCliente, parameters, commandType: CommandType.StoredProcedure);
            }
            catch (SqlException ex)
            {
                throw new Exception("Ha ocurrido un error en la ejecucion del Store Procedure", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error", ex);
            }
        }
    }
}
