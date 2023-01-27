using API_Comun;
using API_DominioTatuajes.Agregados;
using API_Infraestructura.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;

namespace API_Infraestructura.Repositorios
{
    class DTOCita {
        public Guid Cita_id { get; set; }
        public DateTime Cita_fechacreacion { get; set; }
        public DateTime Cita_fechamodificacion { get; set; }
        public DateTime Cita_fechatermino { get; set; }
        

    }
    public class RepositorioCita : IRepositorioCita
    {
        public IUnidadDeTrabajo UnidadDeTrabajo { get; }
        public RepositorioCita(IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.UnidadDeTrabajo = unidadDeTrabajo;
        }
        public void Agregar(Cita agregado)
        {
            //@idCita uniqueidentifier, @fechaCreacion date,@fechaModificacion date,@fechaTermino date
            try
            {
                DynamicParameters parameters = new();
                parameters.Add("@idCita",agregado.Id,DbType.Guid);
                parameters.Add("@fechaCreacion",agregado.FechaCreacion,DbType.DateTime);
                parameters.Add("@fechaModificacion", agregado.FechaModificacion,DbType.DateTime);
                parameters.Add("@fechaTermino",agregado.FechaEliminacion,DbType.DateTime);
                CommandDefinition command = new("CrearCita", parameters, commandTimeout: 0, commandType: CommandType.StoredProcedure);
                if (UnidadDeTrabajo.SqlConnection.State == 0) UnidadDeTrabajo.SqlConnection.Open();
                UnidadDeTrabajo.SqlConnection.Execute(command);
                UnidadDeTrabajo.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Cita> ConsultaCita(Usuario usuario)
        {
            List<Cita> ListaCitas = null;
            try
            {
                DynamicParameters parameters = new();
                parameters.Add("@idUsuario",usuario.Id,DbType.Guid);
                CommandDefinition command = new("ConsultaDeCitas", parameters,commandTimeout: 0, commandType:CommandType.StoredProcedure  );
                IEnumerable<DTOCita> ListaDTOS = UnidadDeTrabajo.SqlConnection.Query<DTOCita>(command);
                foreach (DTOCita item in ListaDTOS)
                {
                    ListaCitas.Add(Cita.Crear(item.Cita_id,item.Cita_fechacreacion,item.Cita_fechamodificacion,item.Cita_fechatermino));
                }
                return ListaCitas??new();
            
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

        public void Update(Cita agregado)
        {
            try
            {
                DynamicParameters parameters = new();
                parameters.Add("@fechaActualizada", agregado.FechaModificacion, DbType.DateTime);
                parameters.Add("@idCita", agregado.Id, DbType.Guid);
                CommandDefinition command = new("ActualizarCitaPorId", parameters, commandType: CommandType.StoredProcedure);
                if (UnidadDeTrabajo.SqlConnection.State == ConnectionState.Closed) UnidadDeTrabajo.SqlConnection.Open();
                /*int result =*/
                UnidadDeTrabajo.SqlConnection.Execute(command);
                //if (result == 1) throw new Exception("Error al actualizar el campo");
                UnidadDeTrabajo.SqlConnection.Close();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Cita ConsultaCitaPorId(Guid idCita)
        {
            Cita cita;
            try
            {
                DynamicParameters parameters = new();
                parameters.Add("@idCita", idCita, DbType.Guid);
                CommandDefinition command = new("ConsultarCitaPorId", parameters, commandType: CommandType.StoredProcedure);
                DTOCita dTOCita = UnidadDeTrabajo.SqlConnection.QueryFirstOrDefault<DTOCita>(command);
                if (dTOCita is null) return null;
                cita = Cita.Crear(dTOCita.Cita_id, dTOCita.Cita_fechacreacion, dTOCita.Cita_fechamodificacion, dTOCita.Cita_fechatermino);
            }
            catch (Exception)
            {

                throw;
            }
            return cita;
        }
    }
}
