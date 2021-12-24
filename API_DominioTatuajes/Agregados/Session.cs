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
        public bool SessionActiva { get; set; }

        
        private Session(Guid sessionId,Guid sessionIdUsuario,Guid sessionIdCliente,Guid sessionIdTatuador, bool sessionActiva)
        {
            if (sessionId == Guid.Empty) throw new ArgumentNullException("No se puede crear una session con id vacio");
            this.Id = sessionId;
            if (sessionIdUsuario == Guid.Empty) throw new ArgumentNullException("No se puede crear session sin un usuario");
            this.SessionIdUsuario = sessionIdUsuario;
            this.SessionIdCliente = sessionIdCliente;
            this.SessionIdTatuador = sessionIdTatuador;
            this.SessionActiva = sessionActiva;
        }

        public static Session Crear(Guid sessionId, Guid sessionIdUsuario, Guid sessionIdCliente, Guid sessionIdTatuador, bool sessionActiva)
        {
            return new Session(sessionId,sessionIdUsuario,sessionIdCliente,sessionIdTatuador,sessionActiva);
        }
    }
}
