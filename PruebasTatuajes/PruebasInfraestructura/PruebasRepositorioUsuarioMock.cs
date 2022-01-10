using API_DominioTatuajes.Agregados;
using API_DominioTatuajes.ObjetosDeValor;
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
        public MockRepositorioUsuario MockRepositorio { get; }
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
        [Fact]
        public void MockRepositorioUsuario_GetUsuarioPorId_ConsultaIdInexistente()
        {
            Usuario FakeUsuario = this.MockRepositorio.GetUsuarioCliente(Guid.Parse("00000000-0000-0000-0000-000000000009"));
            Assert.Null(FakeUsuario);
        }
        [Fact]
        public void MockRepositorioUsuario_GetUsuarioPorId_ConsultaIdExistente()
        {
            Usuario FakeUsuario = this.MockRepositorio.GetUsuarioCliente(Guid.Parse("00000000-0000-0000-0000-000000000002"));
            Assert.NotNull(FakeUsuario);
        }
        [Fact]
        public void MockRepositorioUsuario_GetUsuarioPorId_ConsultaIdVacio()
        {
            Usuario FakeUsuario = this.MockRepositorio.GetUsuarioCliente(Guid.Empty);
            Assert.Null(FakeUsuario);
        }
        [Fact]
        public void MockRepositorioUsuario_Agregar_AgregarUnNuevoUsuario()
        {
            Guid FakeIdUsuario = Guid.Parse("00000000-0000-0000-0000-000000000005");
            CorreoElectronico FakeEmail = CorreoElectronico.Crear("tester4@mail.com");
            Password FakePassword = Password.Crear("Contaseña123");
            Usuario FakeUsuario = Usuario.CrearUsuarioCliente(FakeIdUsuario,FakeEmail,FakePassword);
            this.MockRepositorio.Agregar(FakeUsuario);
            Usuario usuarioConsultado = this.MockRepositorio.GetUsuarioCliente(FakeIdUsuario);
            Assert.Equal(FakeEmail,usuarioConsultado.UsuarioCorreo);
        }
        [Fact]
        public void MockRepositorioUsuario_Agregar_AgregarUsuarioNulo()
        {
            Usuario FakeUsuario = null;
            Assert.Throws<ArgumentNullException>(() => { this.MockRepositorio.Agregar(FakeUsuario); });   
        }
        [Fact]
        public void MockRepositorioUsuario_EliminarPorId_EliminarUsuarioInexistente()
        {
            Guid FakeIdUsuario = Guid.Parse("00000000-0000-0000-0000-000000000005");
            Assert.Throws<ArgumentNullException>(() => { this.MockRepositorio.EliminarPorId(FakeIdUsuario); });
            
        }
        [Fact]
        public void MockRepositorioUsuario_EliminarPorId_EliminarUsuarioExistente()
        {
            Guid FakeIdUsuario = Guid.Parse("00000000-0000-0000-0000-000000000004");
            this.MockRepositorio.EliminarPorId(FakeIdUsuario);
            Assert.Equal(3,MockRepositorio.GetUsuarios().Count());
        }
        [Fact]
        public void MockRepositorioUsuario_EliminarPorId_EliminarIdVacio()
        {
            Guid FakeIdUsaario = Guid.Empty;
            Assert.Throws<ArgumentNullException>(() => { this.MockRepositorio.EliminarPorId(FakeIdUsaario); });
            
        }
        [Fact]
        public void MockRepositorio_GetUsuarios_ConsultaTodosLosUsuarios()
        {
            List<Usuario> listaUsuarios = MockRepositorio.GetUsuarios().ToList();
            CorreoElectronico correEsperado = CorreoElectronico.Crear("tester@mail.com");
            Assert.Equal(4, listaUsuarios.Count);
            Assert.Equal(correEsperado.Cadenavalida,listaUsuarios.First().UsuarioCorreo.Cadenavalida);
        }
        [Fact]
        public void MockRepositorio_Update_ActualizarUnUsuarioExistente()
        {
         Usuario FakeUsuarioActualizar = Usuario.CrearUsuarioCliente(Guid.Parse("00000000-0000-0000-0000-000000000001")
                                , CorreoElectronico.Crear("tester@mail.com")
                                , Password.Crear("Contaseña123456"));
            MockRepositorio.Update(FakeUsuarioActualizar);
            Usuario usuarioConsultado = MockRepositorio.GetUsuarioCliente(Guid.Parse("00000000-0000-0000-0000-000000000001"));
            Assert.Equal(FakeUsuarioActualizar.UsuarioPassword.ContraseniaValida,usuarioConsultado.UsuarioPassword.ContraseniaValida);
        }
        [Fact]
        public void MockRepositorio_Update_ActualizarUnUsuarioNulo()
        {
            Usuario FakeUsuario = null;
            Assert.Throws<ArgumentNullException>(() => { MockRepositorio.Update(FakeUsuario); });
        }
    }
}
