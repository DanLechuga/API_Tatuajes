using API_DominioTatuajes.Agregados;
using API_Infraestructura.Interfaces;
using System;
using System.Data;
using API_Comun;
using Dapper;
namespace API_Infraestructura.Repositorios
{
    class DTOTatuajeCita{
        public Guid TatuajeCita_Id { get; set; }
        public int TatuajeCita_IdCatalogo { get; set; }
        public Guid TatuajeCita_IdCita { get; set; }
        public string TatuajeCita_NombreTatuajeCustom { get; set; }

    }
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
                parameters.Add("@idTatuajeCita", agregado.Id, DbType.Guid);
                parameters.Add("@idCatalogo", agregado.TatuajeCita_IdCatalogo, DbType.Int32);
                parameters.Add("@idCita", agregado.TatuajeCita_IdCita, DbType.Guid);
                parameters.Add("@nombreTatuajeCustom",agregado.TatuajeCita_NombreTatuajeCustom, DbType.String);
                CommandDefinition command = new("CrearTatuajeCita", parameters,commandTimeout:0,commandType: CommandType.StoredProcedure);
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
            try
            {
                DynamicParameters parameters = new();
                parameters.Add("@idCita", id, DbType.Guid);
                CommandDefinition command = new("EliminarTatuajeCitaPorIdCita", parameters, commandType: CommandType.StoredProcedure);
                this.UnidadDeTrabajo.SqlConnection.Execute(command);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(TatuajeCita agregado)
        {
            throw new NotImplementedException();
        }

        public TatuajeCita ConsultarPorIdCita(Guid idCita)
        {
            TatuajeCita tatuajeCita;
            DynamicParameters parameters = new();
            parameters.Add("@idCita", idCita, DbType.Guid);
            CommandDefinition command = new("ConsultarTatuajeCitaPorId", parameters, commandType: CommandType.StoredProcedure);
            DTOTatuajeCita dTOTatuajeCita = UnidadDeTrabajo.SqlConnection.QueryFirstOrDefault<DTOTatuajeCita>(command);
            if (dTOTatuajeCita is null) return null;
            tatuajeCita = TatuajeCita.Crear(dTOTatuajeCita.TatuajeCita_Id, dTOTatuajeCita.TatuajeCita_IdCita, dTOTatuajeCita.TatuajeCita_IdCatalogo,dTOTatuajeCita.TatuajeCita_NombreTatuajeCustom);
            return tatuajeCita;
        }
    }
}
