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
   public class PruebasControllerUsuarios
    {
        public IRepositorioUsuario RepositorioUsuario { get;  }
        public IServicioValidacionUsuarios ServicioValidacionUsuarios { get;  }
        public PruebasControllerUsuarios()
        {
            RepositorioUsuario = new MockRepositorioUsuario();
            ServicioValidacionUsuarios = new ServicioValidacionUsuarios(RepositorioUsuario);
        }
        [Fact]
        public void UsuarioController_ValidarUsuario_ValidarUsuarioConModeloNulo()
        {
            
            UsuarioController usuarioController = new(ServicioValidacionUsuarios);
            ModeloUsuario modeloUsuario = null;
            Assert.Throws<ArgumentNullException>(() => { usuarioController.ValidarUsuario(modeloUsuario); });   
        }
        [Fact]
        public void UsuarioController_ValidarUsuario_ValidarUsuarioConModeloVacio()
        {

            UsuarioController usuarioController = new(ServicioValidacionUsuarios);
            ModeloUsuario modeloUsuario = new();
            Assert.Throws<ArgumentNullException>(() => { usuarioController.ValidarUsuario(modeloUsuario); });
        }
        [Fact]
        public void UsuarioController_ValidarUsuario_ValidarUsuarioConModeloConSoloCorreo()
        {

            UsuarioController usuarioController = new(ServicioValidacionUsuarios);
            ModeloUsuario modeloUsuario = new();
            modeloUsuario.Username = "tester";
            Assert.Throws<ArgumentNullException>(() => { usuarioController.ValidarUsuario(modeloUsuario); });
        }
        [Fact]
        public void UsuarioController_ValidarUsuario_ValidarUsuarioConModeloCompleto()
        {

            UsuarioController usuarioController = new(ServicioValidacionUsuarios);
            ModeloUsuario modeloUsuario = new();
            modeloUsuario.Username = "tester@mail.com";
            modeloUsuario.Password = "Contraseña123";
            JsonResult result =  usuarioController.ValidarUsuario(modeloUsuario);
            Assert.NotNull(result);
            Assert.Equal(200,result.StatusCode); 
        }
    }
}
