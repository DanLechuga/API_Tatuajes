using API_DominioTatuajes.Agregados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PruebasTatuajes.PruebasInfraestructura
{
   public class PruebasRepositorioUsuarioMock
    {
        public MockRepositorioUsuario MockRepositorio { get; set; }
        public PruebasRepositorioUsuarioMock()
        {
            this.MockRepositorio = new();
        }
        [Fact]
        public void MockRepositorioUsuario_GetUsuarioPorCorreo_ConsultaCorreoInexistente()
        {
            Usuario usuarioPrueba = this.MockRepositorio.GetUsuarioPorCorreo("dasaasd@mail.com");
            Assert.Null(usuarioPrueba);
        }
        [Fact]
        public void MockRepositorioUsuario_GetUsuarioPorCorreo_ConsultaCorreoExistente()
        {
            Usuario usuarioPrueba = this.MockRepositorio.GetUsuarioPorCorreo("tester@mail.com");
            Assert.NotNull(usuarioPrueba);
        }
        [Fact]
        public void MockRepositorioUsuario_GetUsuarioPorCorreo_ConsultaCorreoConCorreoVacio()
        {
            Usuario usuarioPrueba = this.MockRepositorio.GetUsuarioPorCorreo("");
            Assert.Null(usuarioPrueba);
        }
    }
}
