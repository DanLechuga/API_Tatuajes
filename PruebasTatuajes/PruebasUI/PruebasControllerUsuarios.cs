using API_Aplicacion.Implementacion;
using API_Aplicacion.Interfaces;
using API_Infraestructura.Interfaces;
using API_Tatuajes.Controllers.usuarios;
using API_Tatuajes.Modelos;
using Microsoft.AspNetCore.Mvc;
using PruebasTatuajes.PruebasInfraestructura;
using System;
using Xunit;
using AutoMapper;
using API_Aplicacion.AutoMap;
using API_Tatuajes.AutoMap;

namespace PruebasTatuajes.PruebasUI
{
    public class PruebasControllerUsuarios
    {
        public IRepositorioUsuario RepositorioUsuario { get;  }
        public IServicioValidacionUsuarios ServicioValidacionUsuarios { get;  }
        public IRepositorioCliente RepositorioCliente { get;  }
        public IServicioError ServicioError { get;  }
        public IRepositorioError RepositorioError { get;  }
        public UsuarioController UsuarioController { get; }
        public IMapper Mapper { get;  }
        public PruebasControllerUsuarios()
        {
            if(Mapper is null)
            {
                var mapperConfig = new MapperConfiguration(mc => { mc.AddProfile(new ModelToDto());mc.AddProfile(new DomainToDto()); });
                IMapper mapper = mapperConfig.CreateMapper();
                this.Mapper = mapper;
            }
            RepositorioCliente = new MockRepositorioCliente();
            RepositorioUsuario = new MockRepositorioUsuario();
            ServicioValidacionUsuarios = new ServicioValidacionUsuarios(RepositorioUsuario,RepositorioCliente,Mapper);
            RepositorioError = new MockRepositorioError();
            ServicioError = new ServicioError(RepositorioError);
            UsuarioController = new(ServicioValidacionUsuarios,ServicioError,Mapper);
        }
        [Fact]
        public void UsuarioController_ValidarUsuario_ValidarUsuarioConModeloNulo()
        {
                        
            ModeloUsuario modeloUsuario = null;
            var response = UsuarioController.ValidarUsuario(modeloUsuario);
            Assert.Equal(409,response.StatusCode);
        }
        [Fact]
        public void UsuarioController_ValidarUsuario_ValidarUsuarioConModeloVacio()
        {            
            ModeloUsuario modeloUsuario = new();
            var response = UsuarioController.ValidarUsuario(modeloUsuario);
            Assert.Equal(409, response.StatusCode);
        }
        [Fact]
        public void UsuarioController_ValidarUsuario_ValidarUsuarioConModeloConSoloCorreo()
        {
            
            ModeloUsuario modeloUsuario = new();
            modeloUsuario.Username = "tester";
            var response = UsuarioController.ValidarUsuario(modeloUsuario);
            Assert.Equal(409, response.StatusCode);
        }
        [Fact]
        public void UsuarioController_ValidarUsuario_ValidarUsuarioConModeloCompleto()
        {
            ModeloUsuario modeloUsuario = new();
            modeloUsuario.Username = "tester@mail.com";
            modeloUsuario.Password = "Contraseña123";
            ObjectResult result =  UsuarioController.ValidarUsuario(modeloUsuario);
            Assert.NotNull(result);
            Assert.Equal(200,result.StatusCode); 
        }
        [Fact]
        public void UsuarioController_ConsultaInfoCliente_ConsultarCorreoVacio()
        {            
            Assert.Throws<ArgumentNullException>(() => { ObjectResult result = UsuarioController.ConsultaInfoCliente(""); }); 
        }
        [Fact]
        public void UsuarioController_ConsultaInfoCliente_ConsultarCorreoInexistente()
        {
            ObjectResult result = UsuarioController.ConsultaInfoCliente("danlechuga10@live.com");
            Assert.NotNull(result);
            Assert.Equal(409, result.StatusCode);
        }
        [Fact]
        public void UsuarioController_ConsultaInfoCliente_ConsultarCorreoExistente()
        {
            ObjectResult result = UsuarioController.ConsultaInfoCliente("tester@mail.com");
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);

        }
    }
}
