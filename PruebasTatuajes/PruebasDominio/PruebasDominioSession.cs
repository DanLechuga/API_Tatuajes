using API_DominioTatuajes.Agregados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PruebasTatuajes.PruebasDominio
{
   public class PruebasDominioSession
    {
        [Fact]
        public void Session_CrearSession_SessionVacia()
        {
            Guid SessionId = Guid.Empty;
            Guid SessionIdUsuario = Guid.Empty;
            Guid SessionIdCliente = Guid.Empty;
            Guid SessionIdTatuador = Guid.Empty;
            bool SessionActiva = true;
            Assert.Throws<ArgumentNullException>(() => { Session FakeSession = Session.Crear(SessionId,SessionIdUsuario,SessionIdCliente,SessionIdTatuador,SessionActiva); });
            
        }
        [Fact]
        public void Session_CrearSession_SessionConIdUsuarioVacio()
        {
            Guid SessionId = Guid.NewGuid();
            Guid SessionIdUsuario = Guid.Empty;
            Guid SessionIdCliente = Guid.Empty;
            Guid SessionIdTatuador = Guid.Empty;
            bool SessionActiva = true;
            Assert.Throws<ArgumentNullException>(() => { Session FakeSession = Session.Crear(SessionId, SessionIdUsuario, SessionIdCliente, SessionIdTatuador, SessionActiva); });

        }
        [Fact]
        public void Session_CrearSession_SessionCompleta()
        {
            Guid SessionId = Guid.NewGuid();
            Guid SessionIdUsuario = Guid.NewGuid();
            Guid SessionIdCliente = Guid.Empty;
            Guid SessionIdTatuador = Guid.Empty;
            bool SessionActiva = true;
            Session FakeSession = Session.Crear(SessionId, SessionIdUsuario, SessionIdCliente, SessionIdTatuador, SessionActiva);
            Assert.NotNull(FakeSession);
        }
    }
}
