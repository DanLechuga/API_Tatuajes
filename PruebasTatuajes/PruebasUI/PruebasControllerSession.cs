using API_Aplicacion.Implementacion;
using API_Aplicacion.Interfaces;
using API_Infraestructura.Interfaces;
using API_Tatuajes.Controllers;
using API_Tatuajes.Modelos;
using Microsoft.AspNetCore.Mvc;
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
            ModeloSession modelo = new() { idSession = Guid.Empty};
            Assert.Throws<ArgumentNullException>(() => { SessionController.CrearSession(modelo); });
        }
        [Fact]
        public void SessionController_CrearSession_CrearSessionConIdUsuarioVacio()
        {
            ModeloSession modelo = new() { idSession = Guid.NewGuid(), idSessionUsuario = Guid.Empty };
            Assert.Throws<ArgumentNullException>(() => { SessionController.CrearSession(modelo); });
        }
        [Fact]
        public void SessionController_CrearSession_CrearSessionCorrecto()
        {
            ModeloSession modelo = new() { idSession = Guid.NewGuid(),idSessionUsuario = Guid.NewGuid(),idSessionTatuador = Guid.NewGuid(),idSessionCliente = Guid.Empty,sessionActiva = true};
            SessionController.CrearSession(modelo);
            Assert.Equal(6,RepositorioSession.GetSessions().ToList().Count);

        }
        [Fact]
        public void SessionController_ConsultaSession_ConsultarSessionConIdVacio()
        {
            Guid FakeIdVacio = Guid.Empty;
            Assert.Throws<ArgumentNullException>(() => { SessionController.ConsultaSession(FakeIdVacio); });

        }
        [Fact]
        public void SessionController_ConsultaSession_ConsultarSessionConInexistente()
        {
            Guid FakeIdAleatorio = Guid.NewGuid();
            
           JsonResult result = SessionController.ConsultaSession(FakeIdAleatorio);
            Assert.NotNull(result);
            Assert.Equal(500, result.StatusCode);
        }
        [Fact]
        public void SessionController_ConsultaSession_ConsultarSessionConIdExistente()
        {
            Guid FakeIdExistente = Guid.Parse("00000000-0000-0000-0000-000000000001");
            JsonResult result = SessionController.ConsultaSession(FakeIdExistente);
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }
    }
}
