using API_Comun;
using API_DominioTatuajes.Agregados;
using API_Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace API_Infraestructura.Repositorios
{
    class DTOSession {
        public Guid SessionId { get; set; }
        public Guid SessionIdUsuario { get; set; }
        public Guid SessionIdCliente { get; set; }
        public Guid SessionIdTatuador { get; set; }
        public bool SessionActiva { get; set; }
        

    }
    public class RepositorioSession : IRepositorioSession
    {

        public IUnidadDeTrabajo UnidadDeTrabajo { get; }
        public RepositorioSession(IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.UnidadDeTrabajo = unidadDeTrabajo;
        }
        public void Agregar(Session agregado)
        {
            try
            {
                DynamicParameters parameters = new();
                parameters.Add("@idSession", agregado.Id, System.Data.DbType.Guid);
                parameters.Add("@idSessionUsuario", agregado.SessionIdUsuario, System.Data.DbType.Guid);
                parameters.Add("@idSessionCliente", agregado.SessionIdCliente, System.Data.DbType.Guid);
                parameters.Add("@idSessionTatuador", agregado.SessionIdTatuador, System.Data.DbType.Guid);
                parameters.Add("@SessionActiva", agregado.SessionActiva, System.Data.DbType.Boolean);
                CommandDefinition command = new("CrearSession", parameters, commandType: System.Data.CommandType.StoredProcedure, commandTimeout: 0);
                UnidadDeTrabajo.SqlConnection.Execute(command);
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

        public Session GetSessionPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Session GetSessionPorUsuario(Guid idUsuario)
        {
            Session SessionConsultada = null;
            try
            {
                DynamicParameters parameters = new();
                parameters.Add("@idCliente",idUsuario,System.Data.DbType.Guid);
                CommandDefinition command = new("ConsultaSessionPorCliente",parameters,commandTimeout:0,commandType:System.Data.CommandType.StoredProcedure);
                DTOSession Dtosession = UnidadDeTrabajo.SqlConnection.QueryFirstOrDefault<DTOSession>(command);
                if (Dtosession == null) throw new ArgumentNullException("No se encontro el usuario para el id ingresado ");
                SessionConsultada = Session.Crear(Dtosession.SessionId,Dtosession.SessionIdUsuario,Dtosession.SessionIdCliente,Dtosession.SessionIdTatuador,Dtosession.SessionActiva);

            }
            catch (Exception)
            {

                throw;
            }
            return SessionConsultada;
        }

        public IEnumerable<Session> GetSessions()
        {
            throw new NotImplementedException();
        }

        public void Update(Session agregado)
        {
            throw new NotImplementedException();
        }
    }
}
