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
    }
}
