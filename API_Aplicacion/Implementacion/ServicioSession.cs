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
        public ServicioSession(IRepositorioSession repositorioSession)
        {
            this.RepositorioSession = repositorioSession;
        }
        public void CrearSession(DTOSession dTOSession)
        {
            if (dTOSession == null) throw new ArgumentNullException("No se puede usar valores nulos");
            if (dTOSession.IdSession == Guid.Empty) throw new ArgumentNullException("No se puede usar un id en 0");
            if (dTOSession.IdSessionUsuario == Guid.Empty) throw new ArgumentNullException("No se puede usar id en 0");
            Session sessionAgregar = Session.Crear(dTOSession.IdSession,dTOSession.IdSessionUsuario,dTOSession.IdSessionCliente,dTOSession.IdSessionTatuador,dTOSession.SessionActiva);
            RepositorioSession.Agregar(sessionAgregar);
            
        }

        public DTOSession ConsultaSessionCliente(DTOCliente cliente)
        {
            if (cliente == null) throw new ArgumentNullException("No se pueden usar elementos nulos");
            if (cliente.IdCliente == Guid.Empty) throw new ArgumentNullException("No se puede usar valores con 0");
            Session SessionConsultada = RepositorioSession.GetSessionPorUsuario(cliente.IdCliente);
            if (SessionConsultada == null) throw new ArgumentNullException("No se encontro usuario para el id ingresado");
            return new DTOSession()
            {
                IdSession = SessionConsultada.Id,
                IdSessionUsuario = SessionConsultada.SessionIdUsuario,
                IdSessionCliente = SessionConsultada.SessionIdCliente,
                IdSessionTatuador = SessionConsultada.SessionIdTatuador,
                SessionActiva = SessionConsultada.SessionActiva
            };
            
        }
    }
}
