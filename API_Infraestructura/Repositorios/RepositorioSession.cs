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
    public class RepositorioSession : IRepositorioSession
    {
        public IUnidadDeTrabajo UnidadDeTrabajo { get; }
        public RepositorioSession(IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.UnidadDeTrabajo = unidadDeTrabajo;
        }
        public void Agregar(Session agregado)
        {
            DynamicParameters parameters = new();
            parameters.Add("@idSession", agregado.Id,System.Data.DbType.Guid);
            parameters.Add("@idSessionUsuario", agregado.SessionIdUsuario,System.Data.DbType.Guid);
            parameters.Add("@idSessionCliente", agregado.SessionIdCliente,System.Data.DbType.Guid);
            parameters.Add("@idSessionTatuador",agregado.SessionIdTatuador,System.Data.DbType.Guid);
            parameters.Add("@SessionActiva",agregado.SessionActiva,System.Data.DbType.Boolean);
            CommandDefinition command = new("CrearSession",parameters,commandType:System.Data.CommandType.StoredProcedure,commandTimeout: 0);
            UnidadDeTrabajo.SqlConnection.Execute(command);
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
            throw new NotImplementedException();
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
