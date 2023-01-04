using API_Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_DominioTatuajes.Agregados
{
   public class Session : Agregado
    {
        public Guid SessionIdUsuario { get; set; }
        public Guid SessionIdCliente { get; set; }
        public Guid SessionIdTatuador { get; set; }
        public Guid SessionIdCreador { get; set; }
        public bool SessionActiva { get; set; }


        
        private Session(Guid sessionId,Guid sessionIdUsuario,Guid sessionIdCliente,Guid sessionIdTatuador,Guid sessionIdCreador, bool sessionActiva)
        {
            if (sessionId == Guid.Empty) throw new ArgumentNullException("No se puede crear una session con id vacio");
            this.Id = sessionId;
            if (sessionIdUsuario == Guid.Empty) throw new ArgumentNullException("No se puede crear session sin un usuario");
            this.SessionIdUsuario = sessionIdUsuario;
            this.SessionIdCliente = sessionIdCliente;
            this.SessionIdTatuador = sessionIdTatuador;
            this.SessionActiva = sessionActiva;
            this.SessionIdCreador = sessionIdCreador;
        }

        public static Session CrearSessionCliente(Guid sessionId, Guid sessionIdUsuario, Guid sessionIdCliente,bool sessionActiva)
        {
            return new Session(sessionId,sessionIdUsuario,sessionIdCliente,Guid.Empty,Guid.Empty,sessionActiva);
        }
        public static Session CrearSessionTatuador(Guid sessionId, Guid sessionIdUsuario, Guid sessionIdTatuador, bool sessionActiva)
        {
            return new Session(sessionId, sessionIdUsuario, Guid.Empty, sessionIdTatuador, Guid.Empty, sessionActiva);
        }
        public static Session CrearSessionCreadorContenido(Guid sessionId, Guid sessionIdUsuario, Guid sessionIdCreador, bool sessionActiva)
        {
            return new Session(sessionId,sessionIdUsuario,Guid.Empty,Guid.Empty,sessionIdCreador,sessionActiva);
        }
    }
}
