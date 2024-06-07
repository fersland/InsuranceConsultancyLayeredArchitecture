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
    public class SeguroRepository : ISeguroRepository
    {
        private readonly IDbConnection _connection;
        private readonly SP_Bitacora _bitacora;

        public SeguroRepository(IDbConnection connection,
                                    IOptions<SP_Bitacora> bitacora)
        {
            _connection = connection;
            _bitacora = bitacora.Value;
        }
        public IEnumerable<Seguro> GetAll()
        {
            try
            {
                return _connection.Query<Seguro>(_bitacora.GetAllSeguro, commandType: CommandType.StoredProcedure);
            }
            catch (SqlException ex)
            {
                throw new Exception("Ha ocurrido un error al ejecutar el Store Procedure", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error.", ex);
            }
        }

        public Seguro GetById(int id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, DbType.Int32);
                return _connection.QueryFirst<Seguro>(_bitacora.GetByIdSeguro, parameters, commandType: CommandType.StoredProcedure);
            }
            catch (SqlException ex)
            {
                throw new Exception("Ha ocurrido un error al ejecutar el Store Procedure", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error.", ex);
            }
        }

        public void Insert(Seguro seguro)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Codigo", seguro.Codigo, DbType.String);
                parameters.Add("@NombreSeguro", seguro.NombreSeguro, DbType.String);
                parameters.Add("@Asegurada", seguro.Asegurada, DbType.String);
                parameters.Add("@Prima", seguro.Prima, DbType.String);
                _connection.Execute(_bitacora.AddSeguro, parameters, commandType: CommandType.StoredProcedure);
            }
            catch (SqlException ex)
            {
                throw new Exception("Ya existe este codigo o nombre de seguro", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error", ex);
            }
        }

        public void Update(int id, Seguro seguro)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, DbType.Int32);
                parameters.Add("@Codigo", seguro.Codigo, DbType.String);
                parameters.Add("@NombreSeguro", seguro.NombreSeguro, DbType.String);
                parameters.Add("@Asegurada", seguro.Asegurada, DbType.String);
                parameters.Add("@Prima", seguro.Prima, DbType.String);
                _connection.Execute(_bitacora.EditSeguro, parameters, commandType: CommandType.StoredProcedure);
            }
            catch (SqlException ex)
            {
                throw new Exception("Ya existe este codigo o nombre de seguro", ex);
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
                _connection.Execute(_bitacora.DeleteSeguro, parameters, commandType: CommandType.StoredProcedure);
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
