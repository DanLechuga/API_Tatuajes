using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Aplicacion.DTOs;
using API_Aplicacion.Interfaces;
using API_DominioTatuajes.Agregados;
using API_Infraestructura.Interfaces;

namespace API_Aplicacion.Implementacion
{
    public class ServicioSession : IServicioSession
    {
        public IRepositorioSession RepositorioSession { get; }
        public IRepositorioUsuario RepositorioUsuario { get;  }

        public ServicioSession(IRepositorioSession repositorioSession,IRepositorioUsuario repositorioUsuario)
        {
            this.RepositorioSession = repositorioSession;
            this.RepositorioUsuario = repositorioUsuario;
            
        }
        public void CrearSession(DTOSession dTOSession)
        {
            if (dTOSession == null) throw new Exception("No se puede usar valores nulos");
            if (dTOSession.IdSession == Guid.Empty) throw new Exception("No se puede usar un id en 0");
            if (dTOSession.IdSessionUsuario == Guid.Empty) throw new Exception("No se puede usar id en 0");
            Session sessionAgregar = null;
            if (dTOSession.IdSessionCliente!= Guid.Empty)
            {
                sessionAgregar = Session.CrearSessionCliente(dTOSession.IdSession, dTOSession.IdSessionUsuario, dTOSession.IdSessionCliente,dTOSession.SessionActiva);
            }
            if(dTOSession.IdSessionTatuador!= Guid.Empty)
            {
                sessionAgregar = Session.CrearSessionTatuador(dTOSession.IdSession, dTOSession.IdSessionUsuario, dTOSession.IdSessionTatuador, dTOSession.SessionActiva);
            }
            if(dTOSession.IdSessionCreador != Guid.Empty)
            {
                sessionAgregar = Session.CrearSessionCreadorContenido(dTOSession.IdSession,dTOSession.IdSessionUsuario,dTOSession.IdSessionCreador,dTOSession.SessionActiva);
            }
            if (sessionAgregar is null) throw new Exception($"No se puede agregar una session vacia para el id del usuario: {dTOSession.IdSessionUsuario}"); 
            RepositorioSession.Agregar(sessionAgregar);
            
        }

        public DTOSession ConsultaSessionCliente(DTOCliente cliente)
        {
            if (cliente == null) throw new Exception("No se pueden usar elementos nulos");
            if (cliente.IdCliente == Guid.Empty) throw new Exception("No se puede usar valores con 0");
            Usuario usuario = RepositorioUsuario.GetUsuarioCliente(cliente.IdCliente);
            Session SessionConsultada = RepositorioSession.GetSessionPorUsuario(usuario.Id);
            if (SessionConsultada == null) throw new Exception("No se encontro usuario para el id ingresado");
            return new DTOSession()
            {
                IdSession = SessionConsultada.Id,
                IdSessionUsuario = SessionConsultada.SessionIdUsuario,
                IdSessionCliente = SessionConsultada.SessionIdCliente,
                IdSessionTatuador = SessionConsultada.SessionIdTatuador,
                SessionActiva = SessionConsultada.SessionActiva
            };
            
        }

        public void CerrarSession(DTOUsuario dTOUsuario)
        {
            if (dTOUsuario == null) throw new Exception("No se puede realizar accion falta objeto para trabajar");
            if (dTOUsuario.IdUsaurio == Guid.Empty) throw new Exception("No se puede realizar operacion falta de argumentos validos");
            
            Session session = RepositorioSession.GetSessionPorUsuario(dTOUsuario.IdUsaurio);
            RepositorioSession.CerrarSession(session);
            
        }

        public void CerrarSessionTatuador(DTOTatuador dTOTatuador)
        {
            if (dTOTatuador is null) throw new Exception("No se puede realizar accion falta objeto para trabajar");
            if (dTOTatuador.idTatuador == Guid.Empty) throw new Exception("Falta ingresar el id del tatuador");
            Session session = RepositorioSession.GetSessionPorUsuario(dTOTatuador.idTatuador);
            RepositorioSession.CerrarSession(session);
        }

        public DTOSession ConsultaSessionTatuador(DTOTatuador dTOTatuador)
        {
            if (dTOTatuador is null) throw new Exception("No se puede consultar valores vacios");
            if (dTOTatuador.idTatuador == Guid.Empty) throw new Exception("No se puede usar id vacios");
            Session SessionConsultada = RepositorioSession.GetSessionPorUsuario(dTOTatuador.idTatuador);
            if (SessionConsultada == null) throw new Exception("No se encontro usuario para el id ingresado");
            return new DTOSession()
            {
                IdSession = SessionConsultada.Id,
                IdSessionUsuario = SessionConsultada.SessionIdUsuario,
                IdSessionCliente = SessionConsultada.SessionIdCliente,
                IdSessionTatuador = SessionConsultada.SessionIdTatuador,
                SessionActiva = SessionConsultada.SessionActiva
            };
        }

        public void CerrarSessionCreaddor(DTOCreador dTOCreador)
        {
            if (dTOCreador is null) throw new Exception("No se puede realizar accion falta objeto para trabajar");
            if (dTOCreador.IdCreador == Guid.Empty) throw new Exception("Falta ingresar el id del credor");
            Session session = RepositorioSession.GetSessionPorUsuario(dTOCreador.IdCreador);
            RepositorioSession.CerrarSession(session);
        }

        public DTOSession ConsultaSessionCreador(DTOCreador dTOCreador)
        {
            if (dTOCreador is null) throw new Exception("No se puede consultar valores vacios");
            if (dTOCreador.IdCreador == Guid.Empty) throw new Exception("No se puede usar id vacios");
            Session SessionConsultada = RepositorioSession.GetSessionPorUsuario(dTOCreador.IdCreador);
            if (SessionConsultada == null) throw new Exception($"No se encontro usuario para el id ingresado: {dTOCreador.IdCreador}");
            return new DTOSession()
            {
                IdSession = SessionConsultada.Id,
                IdSessionUsuario = SessionConsultada.SessionIdUsuario,
                IdSessionCliente = SessionConsultada.SessionIdCliente,
                IdSessionTatuador = SessionConsultada.SessionIdTatuador,
                IdSessionCreador = SessionConsultada.SessionIdCreador,
                SessionActiva = SessionConsultada.SessionActiva
            };
        }
    }
}
