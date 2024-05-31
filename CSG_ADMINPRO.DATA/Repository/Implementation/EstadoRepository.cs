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
    public class EstadoRepository : IEstadoRepository
    {
        private readonly IDbConnection _connection;
        private readonly SP_Bitacora _bitacora;

        public EstadoRepository(IDbConnection connection,
                                    IOptions<SP_Bitacora> bitacora)
        {
            _connection = connection;
            _bitacora = bitacora.Value;
        }

        public IEnumerable<Estado> GetAll()
        {
            try
            {
                return _connection.Query<Estado>(_bitacora.GetAllEstado, commandType: CommandType.StoredProcedure);
            }
            catch (SqlException ex)
            {
                throw new Exception("Ha ocurrido un error al ejecutar el Store Procedure", ex);
            }

            catch(Exception ex)
            {
                throw new Exception("Ha ocurrido un error", ex);
            }
        }
    }
}
