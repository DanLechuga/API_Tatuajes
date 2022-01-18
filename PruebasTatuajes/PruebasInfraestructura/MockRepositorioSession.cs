using API_DominioTatuajes.Agregados;
using API_Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasTatuajes.PruebasInfraestructura
{
    public class MockRepositorioSession : IRepositorioSession
    {
        public List<Session> ListaDeSessions { get; set; }
        public MockRepositorioSession()
        {
            ListaDeSessions = new();
            ListaDeSessions.Add(Session.Crear(Guid.Parse("00000000-0000-0000-0000-000000000001"), Guid.Parse("00000000-0000-0000-0000-000000000001"), Guid.Parse("00000000-0000-0000-0000-000000000001"), Guid.Empty,true));
            ListaDeSessions.Add(Session.Crear(Guid.Parse("00000000-0000-0000-0000-000000000002"), Guid.Parse("00000000-0000-0000-0000-000000000002"),Guid.Empty, Guid.Parse("00000000-0000-0000-0000-000000000002"),true));
            ListaDeSessions.Add(Session.Crear(Guid.Parse("00000000-0000-0000-0000-000000000003"), Guid.Parse("00000000-0000-0000-0000-000000000003"), Guid.Parse("00000000-0000-0000-0000-000000000003"),Guid.Empty,false));
            ListaDeSessions.Add(Session.Crear(Guid.Parse("00000000-0000-0000-0000-000000000004"), Guid.Parse("00000000-0000-0000-0000-000000000004"),Guid.Empty, Guid.Parse("00000000-0000-0000-0000-000000000004"),true));
            ListaDeSessions.Add(Session.Crear(Guid.Parse("00000000-0000-0000-0000-000000000005"), Guid.Parse("00000000-0000-0000-0000-000000000005"), Guid.Parse("00000000-0000-0000-0000-000000000005"), Guid.Empty,false));
        }
        public void Agregar(Session agregado)
        {
            Session sessioConsultada = ListaDeSessions.FirstOrDefault(x => x.Id == agregado.Id);
            if (sessioConsultada != null) ListaDeSessions.Remove(agregado);
            ListaDeSessions.Add(agregado);
        }

        public void EliminarPorId(Guid id)
        {
            Session sessionConsultada = ListaDeSessions.FirstOrDefault(x => x.Id == id);
            if (sessionConsultada != null) ListaDeSessions.Remove(sessionConsultada);
        }

        public Session GetSessionPorId(Guid id)
        {
            return ListaDeSessions.FirstOrDefault(x => x.Id == id);
        }

        public Session GetSessionPorUsuario(Guid idUsuario)
        {
            return ListaDeSessions.FirstOrDefault(x => x.SessionIdUsuario == idUsuario);
        }

        public IEnumerable<Session> GetSessions()
        {
            return ListaDeSessions;
        }

        public void Update(Session agregado)
        {
            Session sessionConsultada = ListaDeSessions.FirstOrDefault(x => x.Id == agregado.Id);
            if (sessionConsultada != null) ListaDeSessions.Remove(agregado);
            ListaDeSessions.Add(agregado);
        }

        public void CerrarSession(Session session)
        {
            Session sessionConsultada = ListaDeSessions.FirstOrDefault(x => x.Id == session.Id);
            if (sessionConsultada != null) ListaDeSessions.Remove(session);
            sessionConsultada.SessionActiva = false;
            ListaDeSessions.Add(sessionConsultada);
        }
    }
}
