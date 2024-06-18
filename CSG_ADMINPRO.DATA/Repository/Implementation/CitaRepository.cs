using CSG_ADMINPRO.DATA.Configuration;
using CSG_ADMINPRO.DATA.Repository.Interfaces;
using CSG_ADMINPRO.DOMAIN.DTO;
using CSG_ADMINPRO.DOMAIN.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG_ADMINPRO.DATA.Repository.Implementation
{
    public class CitaRepository : ICitaRepository
    {
        private readonly IDbConnection _connection;
        private readonly SP_Bitacora _bitacora;

        public CitaRepository(IDbConnection dbConnection,
                                    IOptions<SP_Bitacora> bitacora)
        {
            _connection = dbConnection;
            _bitacora = bitacora.Value;
        }

        public IEnumerable<CitaDTO> GetAll()
        {
            try
            {
                return _connection.Query<CitaDTO>(_bitacora.GetAllCita, commandType: CommandType.StoredProcedure);
            }
            catch (SqlException ex)
            {
                throw new Exception("Ha ocurrido un error con el Store Procedure", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error.", ex);
            }
        }

        public Cita GetById(int id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CitaId", id, DbType.Int32);
                return _connection.QueryFirst<Cita>(_bitacora.GetByIdCita, parameters, commandType: CommandType.StoredProcedure);
            }
            catch (SqlException ex)
            {
                throw new Exception("Ha ocurrido un error con el Store Procedure", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error.", ex);
            }
        }

        public void Insert(CitaCreateDTO cita)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ClienteId", cita.ClienteId, DbType.Int32);
                parameters.Add("@Fecha", cita.Fecha, DbType.Date); // Fecha dia de cita
                parameters.Add("@Motivo", cita.Motivo, DbType.String);
                parameters.Add("@Notas", cita.Notas, DbType.String);
                parameters.Add("@Ubicacion", cita.Ubicacion, DbType.String);

                _connection.Execute(_bitacora.AddCita, parameters, commandType: CommandType.StoredProcedure);
            }
            catch (SqlException ex)
            {
                throw new Exception("Ha ocurrido un error con el Store Procedure", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error.", ex);
            }
        }

        public void Update(int id, CitaUpdateDTO cita)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CitaId", id, DbType.Int32);
                parameters.Add("@ClienteId", cita.ClienteId, DbType.Int32);
                parameters.Add("@Fecha", cita.Fecha, DbType.Date); // Fecha dia de cita
                parameters.Add("@Motivo", cita.Motivo, DbType.String);
                parameters.Add("@Notas", cita.Notas, DbType.String);
                parameters.Add("@Ubicacion", cita.Ubicacion, DbType.String);

                _connection.Execute(_bitacora.EditCita, parameters, commandType: CommandType.StoredProcedure);
            }
            catch (SqlException ex)
            {
                throw new Exception("Ha ocurrido un error con el Store Procedure", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error.", ex);
            }
        }
        public void Delete(int id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CitaId", id, DbType.Int32);

                _connection.Execute(_bitacora.DeleteCita, parameters, commandType: CommandType.StoredProcedure);
            }
            catch (SqlException ex)
            {
                throw new Exception("Ha ocurrido un error con el Store Procedure", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error.", ex);
            }
        }
    }
}
