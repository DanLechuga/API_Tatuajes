using API_DominioTatuajes.Agregados;
using API_Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using API_Comun;
using Dapper;

namespace API_Infraestructura.Repositorios
{
    class DTOTatuadorCita{
        public Guid TatuadorCita_Id  { get; set; }
        public Guid TatuadorCita_IdTatuador  { get; set; }
        public Guid TatuadorCita_IdCita { get; set; }
    }
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
            try
            {
                DynamicParameters parameters = new();
                parameters.Add("@idCita", id, DbType.Guid);
                CommandDefinition command = new("EliminarTatuadorCitaPorIdCita", parameters, commandType: CommandType.StoredProcedure);
                this.UnidadDeTrabajo.SqlConnection.Execute(command);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(TatuadorCita agregado)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TatuadorCita> ConsultarCitasPorTatuador(Tatuador tatuador)
        {
            List<TatuadorCita> ListaCitasCliente = new();
            DynamicParameters parameters = new();
            parameters.Add("@idTatuador", tatuador.Id, DbType.Guid);
            CommandDefinition command = new("ConsultarCitaPorTatuador", parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);
            IEnumerable<DTOTatuadorCita> ListaDTOS = UnidadDeTrabajo.SqlConnection.Query<DTOTatuadorCita>(command);
            foreach (var item in ListaDTOS)
            {
                ListaCitasCliente.Add(TatuadorCita.Crear(item.TatuadorCita_Id,item.TatuadorCita_IdTatuador,item.TatuadorCita_IdCita));
            }
            return ListaCitasCliente;
        }

        public TatuadorCita ConsultarCitaPorId(Guid idCita)
        {
            TatuadorCita tatuadorCita;
            try
            {
                DynamicParameters parameters = new();
                parameters.Add("@idCita",idCita,DbType.Guid);
                CommandDefinition command = new("ConsultarCitaTatuadorPorIdCita",parameters,commandType:CommandType.StoredProcedure);
                DTOTatuadorCita dTOTatuadorCita = this.UnidadDeTrabajo.SqlConnection.QueryFirstOrDefault<DTOTatuadorCita>(command);
                if (dTOTatuadorCita is null) return null;
                tatuadorCita = TatuadorCita.Crear(dTOTatuadorCita.TatuadorCita_Id, dTOTatuadorCita.TatuadorCita_IdTatuador, dTOTatuadorCita.TatuadorCita_IdCita);
            }
            catch (Exception)
            {

                throw;
            }
            return tatuadorCita;
        }
    }
}
