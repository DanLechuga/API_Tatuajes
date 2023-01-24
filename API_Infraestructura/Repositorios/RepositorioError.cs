using API_Comun;
using API_Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace API_Infraestructura.Repositorios
{
    public class RepositorioError : IRepositorioError
    {
        public IUnidadDeTrabajo UnidadDeTrabajo { get;  }
        public RepositorioError(IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.UnidadDeTrabajo = unidadDeTrabajo;
        }

        public string RegistrarError(string ExceptionMessage, string InnerException, string StackTrace)
        {
            Guid idException = Guid.NewGuid();
            try
            {
                DynamicParameters parameters = new();
                parameters.Add("@ExceptionId", idException, System.Data.DbType.Guid);
                parameters.Add("@ExceptionMessage", ExceptionMessage, System.Data.DbType.String);
                parameters.Add("@ExceptionInnerMessage", InnerException, System.Data.DbType.String);
                parameters.Add("@ExceptionStackTrace", StackTrace, System.Data.DbType.String);
                CommandDefinition command = new("AgregarException", parameters, commandTimeout: 0, commandType: System.Data.CommandType.StoredProcedure);
                if(UnidadDeTrabajo.SqlConnection.State == 0) UnidadDeTrabajo.SqlConnection.Open();
                UnidadDeTrabajo.SqlConnection.Execute(command);
                UnidadDeTrabajo.SaveChanges();
                UnidadDeTrabajo.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return idException.ToString();
        }
    }
}
