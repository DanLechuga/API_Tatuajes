using API_Aplicacion.Implementacion;
using API_Aplicacion.Interfaces;
using API_Infraestructura.Interfaces;
using API_Tatuajes.Controllers.usuarios;
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
   public class PruebasControllerUsuarios
    {
        public IRepositorioUsuario RepositorioUsuario { get;  }
        public IServicioValidacionUsuarios ServicioValidacionUsuarios { get;  }
        public IRepositorioCliente RepositorioCliente { get;  }
        public IServicioError ServicioError { get;  }
        public IRepositorioError RepositorioError { get;  }
        public UsuarioController UsuarioController { get; }
        public PruebasControllerUsuarios()
        {
            RepositorioCliente = new MockRepositorioCliente();
            RepositorioUsuario = new MockRepositorioUsuario();
            ServicioValidacionUsuarios = new ServicioValidacionUsuarios(RepositorioUsuario,RepositorioCliente);
            RepositorioError = new MockRepositorioError();
            ServicioError = new ServicioError(RepositorioError);
            UsuarioController = new(ServicioValidacionUsuarios,ServicioError);
        }
        [Fact]
        public void UsuarioController_ValidarUsuario_ValidarUsuarioConModeloNulo()
        {
                        
            ModeloUsuario modeloUsuario = null;
            Assert.Throws<ArgumentNullException>(() => { UsuarioController.ValidarUsuario(modeloUsuario); });   
        }
        [Fact]
        public void UsuarioController_ValidarUsuario_ValidarUsuarioConModeloVacio()
        {            
            ModeloUsuario modeloUsuario = new();
            Assert.Throws<ArgumentNullException>(() => { UsuarioController.ValidarUsuario(modeloUsuario); });
        }
        [Fact]
        public void UsuarioController_ValidarUsuario_ValidarUsuarioConModeloConSoloCorreo()
        {
            
            ModeloUsuario modeloUsuario = new();
            modeloUsuario.Username = "tester";
            Assert.Throws<ArgumentNullException>(() => { UsuarioController.ValidarUsuario(modeloUsuario); });
        }
        [Fact]
        public void UsuarioController_ValidarUsuario_ValidarUsuarioConModeloCompleto()
        {
            ModeloUsuario modeloUsuario = new();
            modeloUsuario.Username = "tester@mail.com";
            modeloUsuario.Password = "Contraseña123";
            JsonResult result =  UsuarioController.ValidarUsuario(modeloUsuario);
            Assert.NotNull(result);
            Assert.Equal(200,result.StatusCode); 
        }
        [Fact]
        public void UsuarioController_ConsultaInfoCliente_ConsultarCorreoVacio()
        {            
            Assert.Throws<ArgumentNullException>(() => { JsonResult result = UsuarioController.ConsultaInfoCliente(""); }); 
        }
        [Fact]
        public void UsuarioController_ConsultaInfoCliente_ConsultarCorreoInexistente()
        {
            JsonResult result = UsuarioController.ConsultaInfoCliente("danlechuga@live.com");
            Assert.NotNull(result);
            Assert.Equal(500, result.StatusCode);
        }
        [Fact]
        public void UsuarioController_ConsultaInfoCliente_ConsultarCorreoExistente()
        {
            JsonResult result = UsuarioController.ConsultaInfoCliente("tester@mail.com");
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);

        }
    }
}
