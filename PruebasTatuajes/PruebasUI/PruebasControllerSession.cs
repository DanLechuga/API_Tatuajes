using API_Aplicacion.Implementacion;
using API_Aplicacion.Interfaces;
using API_Infraestructura.Interfaces;
using API_Tatuajes.Controllers.sessiones;
using API_Tatuajes.Modelos;
using Microsoft.AspNetCore.Mvc;
using PruebasTatuajes.PruebasInfraestructura;
using System;
using System.Linq;
using Xunit;
using AutoMapper;
using API_Aplicacion.AutoMap;
using API_Tatuajes.AutoMap;

namespace PruebasTatuajes.PruebasUI
{
    public class PruebasControllerSession
    {
        public IRepositorioSession RepositorioSession { get;  }
        public IRepositorioUsuario RepositorioUsuario { get;  }
        public IServicioSession ServicioSession { get;  }
        public IRepositorioError RepositorioError { get;  }
        public IServicioError ServicioError { get;  }
        public SessionController SessionController { get;  }
        public IMapper Mapper { get;  }
        public PruebasControllerSession()
        {
            if(Mapper is null)
            {
                var mapperConfig = new MapperConfiguration(mc => { mc.AddProfile(new ModelToDto());mc.AddProfile(new DomainToDto()); });
                IMapper mapper = mapperConfig.CreateMapper();
                this.Mapper = mapper;
            }
            this.RepositorioSession = new MockRepositorioSession();
        this.RepositorioUsuario = new MockRepositorioUsuario();
            this.ServicioSession = new ServicioSession(RepositorioSession,RepositorioUsuario,Mapper);
            this.RepositorioError = new MockRepositorioError();
            this.ServicioError = new ServicioError(RepositorioError);
            this.SessionController = new(ServicioSession,ServicioError,Mapper);
        }
        [Fact]
        public void SessionController_CrearSession_CrearSessionConModeloNulo()
        {
            ModeloSession modelo = null;
            var response = SessionController.CrearSession(modelo);
            Assert.Equal(500,response.StatusCode);

        }
        [Fact]
        public void SessionController_CrearSession_CrearSessionConIdSessionVacio()
        {
            ModeloSession modelo = new() { idSession = Guid.Empty};
            var response = SessionController.CrearSession(modelo);
            Assert.Equal(500, response.StatusCode);
        }
        [Fact]
        public void SessionController_CrearSession_CrearSessionConIdUsuarioVacio()
        {
            ModeloSession modelo = new() { idSession = Guid.NewGuid(), idSessionUsuario = Guid.Empty };
            var response = SessionController.CrearSession(modelo);
            Assert.Equal(500, response.StatusCode);
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
            
           ObjectResult result = SessionController.ConsultaSession(FakeIdAleatorio);
            Assert.NotNull(result);
            Assert.Equal(409, result.StatusCode);
        }
        [Fact]
        public void SessionController_ConsultaSession_ConsultarSessionConIdExistente()
        {
            Guid FakeIdExistente = Guid.Parse("00000000-0000-0000-0000-000000000001");
            ObjectResult result = SessionController.ConsultaSession(FakeIdExistente);
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }
    }
}
