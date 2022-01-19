using API_DominioTatuajes.Agregados;
using API_Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Comun;
using Dapper;

namespace API_Infraestructura.Repositorios
{
   public  class RepositorioTatuadorCita : IRepositorioTatuadorCita
    {
        public IUnidadDeTrabajo UnidadDeTrabajo { get;  }
        public RepositorioTatuadorCita(IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.UnidadDeTrabajo = unidadDeTrabajo;
        }
        public void Agregar(TatuadorCita agregado)
        {
            //@idTatuadorCita uniqueidentifier, @idTatuador uniqueidentifier, @idCita uniqueidentifier
            try
            {
                DynamicParameters parameters = new();
                parameters.Add("@idTatuadorCita",agregado.Id,System.Data.DbType.Guid);
                parameters.Add("@idTatuador", agregado.IdTatuador, System.Data.DbType.Guid);
                parameters.Add("@idCita", agregado.IdCita, System.Data.DbType.Guid);
                CommandDefinition command = new("CrearTatuadorCita",parameters,commandTimeout: 0, commandType:System.Data.CommandType.StoredProcedure);
                if (UnidadDeTrabajo.SqlConnection.State == 0) UnidadDeTrabajo.SqlConnection.Open();
                UnidadDeTrabajo.SqlConnection.Execute(command);
                UnidadDeTrabajo.Dispose();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void EliminarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(TatuadorCita agregado)
        {
            throw new NotImplementedException();
        }
    }
}
