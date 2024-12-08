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
    public class ServicioRepository : IServicioRepository
    {
        private readonly IDbConnection _connection;
        private readonly SP_Bitacora _bitacora;

        public ServicioRepository(IDbConnection connection,
            IOptions<SP_Bitacora> bitacora)
        {
            _connection = connection;
            _bitacora = bitacora.Value;
        }


        public IEnumerable<Servicio> GetAll()
        {
            try
            {
                return _connection.Query<Servicio>(_bitacora.GetAllServicio, commandType: CommandType.StoredProcedure);
            }
            catch (SqlException ex)
            {

                throw new Exception("Ha ocurrido un error con Store Procedure", ex);
            }

            catch(Exception ex)
            {
                throw new Exception("Hubo un error. ", ex);
            }
        }

        public Servicio GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Servicio servicio)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Servicio servicio)
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
