using API_Aplicacion.Implementacion;
using API_Aplicacion.Interfaces;
using API_Infraestructura.Interfaces;
using API_Tatuajes.Controllers;
using API_Tatuajes.Modelos;
using PruebasTatuajes.PruebasInfraestructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PruebasTatuajes.PruebasUI
{
   public class PruebasControllerSession
    {
        public IRepositorioSession RepositorioSession { get;  }
        public IServicioSession ServicioSession { get;  }
        public SessionController SessionController { get;  }
        public PruebasControllerSession()
        {
            this.RepositorioSession = new MockRepositorioSession();
            this.ServicioSession = new ServicioSession(RepositorioSession);
            this.SessionController = new(ServicioSession);
        }
        [Fact]
        public void SessionController_CrearSession_CrearSessionConModeloNulo()
        {
            ModeloSession modelo = null;
            Assert.Throws<ArgumentNullException>(() => { SessionController.CrearSession(modelo); });
            
        }
        [Fact]
        public void SessionController_CrearSession_CrearSessionConIdSessionVacio()
        {
            ModeloSession modelo = new() { IdSession = Guid.Empty};
            Assert.Throws<ArgumentNullException>(() => { SessionController.CrearSession(modelo); });
        }
        [Fact]
        public void SessionController_CrearSession_CrearSessionConIdUsuarioVacio()
        {
            ModeloSession modelo = new() { IdSession = Guid.NewGuid(), IdSessionUsuario = Guid.Empty };
            Assert.Throws<ArgumentNullException>(() => { SessionController.CrearSession(modelo); });
        }
        [Fact]
        public void SessionController_CrearSession_CrearSessionCorrecto()
        {
            ModeloSession modelo = new() { IdSession = Guid.NewGuid(),IdSessionUsuario = Guid.NewGuid(),IdSessionTatuador = Guid.NewGuid(),IdSessionCliente = Guid.Empty,SessionActiva = true};
            SessionController.CrearSession(modelo);
            Assert.Equal(6,RepositorioSession.GetSessions().ToList().Count);

        }
    }
}
