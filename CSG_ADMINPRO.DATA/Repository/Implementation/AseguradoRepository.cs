using CSG_ADMINPRO.DATA.Configuration;
using CSG_ADMINPRO.DATA.Repository.Interfaces;
using CSG_ADMINPRO.DOMAIN.DTO;
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
    public class AseguradoRepository : IAseguradoRepository
    {
        private readonly IDbConnection _connection;
        private readonly SP_Bitacora _bitacora;

        public AseguradoRepository(IDbConnection connecion,
                                        IOptions<SP_Bitacora> bitacora)
        {
            _connection = connecion;
            _bitacora = bitacora.Value;
        }

        public IEnumerable<AseguradosDTO> GetAll()
        {
            try
            {
                return _connection.Query<AseguradosDTO>(_bitacora.GetAllAsegurada, commandType: CommandType.StoredProcedure);
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

        public Asegurado GetById(int id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, DbType.Int32);
                return _connection.QueryFirst<Asegurado>(_bitacora.GetByIdAsegurada, parameters, commandType: CommandType.StoredProcedure);
            }
            catch (SqlException ex)
            {
                throw new Exception("Ha ocurrido un error al ejecutar el Store Procedure", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error", ex);
            }
        }

        public void Insert(Asegurado asegurado)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ClienteId", asegurado.ClienteId, DbType.Int32);
                parameters.Add("@SeguroId", asegurado.SeguroId, DbType.Int32);
                _connection.Execute(_bitacora.AddAsegurada, parameters, commandType: CommandType.StoredProcedure);
            }
            catch (SqlException ex)
            {
                throw new Exception("Error: El cliente ya esta asegurado.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error", ex);
            }
        }

        public void Update(int id, Asegurado asegurado)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, DbType.Int32);
                parameters.Add("@ClienteId", asegurado.ClienteId, DbType.Int32);
                parameters.Add("@SeguroId", asegurado.SeguroId, DbType.Int32);
                _connection.Execute(_bitacora.EditAsegurada, parameters, commandType: CommandType.StoredProcedure);
            }
            catch (SqlException ex)
            {
                throw new Exception("Error: El cliente ya tiene este seguro.", ex);
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
                _connection.Execute(_bitacora.DeleteAsegurada, parameters, commandType: CommandType.StoredProcedure);
            }
            catch (SqlException ex)
            {
                throw new Exception("Ha ocurrido un error al ejecutar el Store Procedure", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error", ex);
            }
        }
    }
}
