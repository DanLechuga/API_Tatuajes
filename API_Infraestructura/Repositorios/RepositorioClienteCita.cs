using API_Comun;
using API_DominioTatuajes.Agregados;
using API_Infraestructura.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Infraestructura.Repositorios
{
    class DTOCitaCliente
    {
        public Guid ClienteCita_id { get; set; }
        public DateTime ClienteCita_Fecha { get; set; }
        public Guid ClienteCita_ClienteId { get; set; }
        public bool ClienteCita_Anticipo { get; set; }
        public double ClienteCita_MontoAnticipa { get; set; }
        public Guid ClienteCita_TatuadorId { get; set; }
        public string Tatuador_Nombre { get; set; }
        public Guid ClienteCita_CitaId { get; set; }

    }
    public class RepositorioClienteCita : IRepositorioClienteCita
    {
        public IUnidadDeTrabajo UnidadDeTrabajo { get; set; }
        public RepositorioClienteCita(IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.UnidadDeTrabajo = unidadDeTrabajo;
        }
        public void Agregar(CitaCliente agregado)
        {
            //@idCitaCliente uniqueidentifier, @fechacita datetime, @idCliente uniqueidentifier, @anticipo bit, @montoanticipo numeric(18, 4),@idTatuador uniqueidentifier
            try
            {
                DynamicParameters parameters = new();
                parameters.Add("@idCitaCliente",agregado.Id,System.Data.DbType.Guid);
                parameters.Add("@fechacita", agregado.FechaCitaRegistrada, System.Data.DbType.DateTime);
                parameters.Add("@idCliente", agregado.IdCliente, System.Data.DbType.Guid);
                parameters.Add("@anticipo", agregado.EsConAnticipo, System.Data.DbType.Boolean);
                parameters.Add("@montoanticipo", agregado.CantidadDeposito, System.Data.DbType.Double);
                parameters.Add("@idTatuador", agregado.IdTatuador, System.Data.DbType.Guid);
                parameters.Add("@idCita",agregado.IdCita,System.Data.DbType.Guid);
                CommandDefinition command = new("CrearClienteCita",parameters,commandTimeout:0,commandType: System.Data.CommandType.StoredProcedure);
                if (UnidadDeTrabajo.SqlConnection.State == 0) UnidadDeTrabajo.SqlConnection.Open();
                UnidadDeTrabajo.SqlConnection.Execute(command);
                UnidadDeTrabajo.Dispose();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<CitaCliente> ConsultaCitaCliente(Usuario usuario)
        {
            List<CitaCliente> ListaCitasCliente = new();
            DynamicParameters parameters = new();
            parameters.Add("@idUsuario",usuario.Id,System.Data.DbType.Guid);
            CommandDefinition command = new("ConsultarCitaPorUsuario",parameters,commandTimeout: 0, commandType: System.Data.CommandType.StoredProcedure);
            IEnumerable<DTOCitaCliente> ListaDTOS = UnidadDeTrabajo.SqlConnection.Query<DTOCitaCliente>(command);
            foreach (var item in ListaDTOS)
            {
                ListaCitasCliente.Add(CitaCliente.Crear(item.ClienteCita_id,item.ClienteCita_CitaId,item.ClienteCita_ClienteId,item.ClienteCita_Fecha,item.ClienteCita_Anticipo,item.ClienteCita_MontoAnticipa,item.ClienteCita_TatuadorId,item.Tatuador_Nombre));
            }
            return ListaCitasCliente;
            
        }

        public void EliminarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(CitaCliente agregado)
        {
            throw new NotImplementedException();
        }

        public CitaCliente ConsultarCitaClientePorId(Guid idCita)
        {
            CitaCliente citaCliente = null;
            DynamicParameters parameters = new();
            parameters.Add("@idCita", idCita,System.Data.DbType.Guid);
            CommandDefinition command = new("ConsultarCitaPorId", parameters, commandType: System.Data.CommandType.StoredProcedure);
            DTOCitaCliente dTOCitaCliente = UnidadDeTrabajo.SqlConnection.QueryFirstOrDefault<DTOCitaCliente>(command);
            if (dTOCitaCliente is null) throw new ArgumentNullException("No se encontro cita para el id ingresado");
            citaCliente = CitaCliente.Crear(dTOCitaCliente.ClienteCita_id, dTOCitaCliente.ClienteCita_id, dTOCitaCliente.ClienteCita_ClienteId, dTOCitaCliente.ClienteCita_Fecha, dTOCitaCliente.ClienteCita_Anticipo, dTOCitaCliente.ClienteCita_MontoAnticipa, dTOCitaCliente.ClienteCita_TatuadorId,dTOCitaCliente.Tatuador_Nombre);
            return citaCliente;
        }
    }
}
