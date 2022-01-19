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
    public class RepositorioTatuajeCita : IRepositorioTatuajeCita
    {
        public IUnidadDeTrabajo UnidadDeTrabajo { get; }
        public RepositorioTatuajeCita(IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.UnidadDeTrabajo = unidadDeTrabajo;
        }
        public void Agregar(TatuajeCita agregado)
        {
            //@idTatuajeCita uniqueidentifier, @idCatalogo int, @idCita uniqueidentifier
            try
            {
                DynamicParameters parameters = new();
                parameters.Add("@idTatuajeCita", agregado.Id, System.Data.DbType.Guid);
                parameters.Add("@idCatalogo", agregado.TatuajeCita_IdCatalogo, System.Data.DbType.Int32);
                parameters.Add("@idCita", agregado.TatuajeCita_IdCita, System.Data.DbType.Guid);
                CommandDefinition command = new("CrearTatuajeCita", parameters,commandTimeout:0,commandType: System.Data.CommandType.StoredProcedure);
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

        public void Update(TatuajeCita agregado)
        {
            throw new NotImplementedException();
        }
    }
}
