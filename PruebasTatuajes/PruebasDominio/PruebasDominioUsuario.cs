using API_DominioTatuajes.Agregados;
using API_DominioTatuajes.ObjetosDeValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PruebasTatuajes.PruebasDominio
{
   public class PruebasDominioUsuario
    {
        [Fact]
        public void Usuario_CrearUsuarioCliente_CrearUnUsuarioConCorreoNulo()
        {
            string password = "MiContrasena123";
            CorreoElectronico fakeEmail = null;
            Password FakePassword = Password.Crear(password);            
            Guid FakeIdCliente = Guid.NewGuid();
            Assert.Throws<ArgumentNullException>(() => { Usuario fakeUsuario = Usuario.CrearUsuarioCliente(FakeIdCliente,fakeEmail,FakePassword); });
        }
        [Fact]
        public void Usuario_CrearUsuarioCliente_CrearUnUsuarioConPasswordNulo()
        {
            string FakeEmail = "tester@mail.com";
            CorreoElectronico FakeCorreo = CorreoElectronico.Crear(FakeEmail);
            Password FakePassword = null;
            Guid FakeIdUsuario = Guid.NewGuid();
            Assert.Throws<ArgumentNullException>(() => { Usuario FakeUsuario = Usuario.CrearUsuarioCliente(FakeIdUsuario,FakeCorreo,FakePassword); });
        }
        [Fact]
        public void Usuario_CrearUsuarioCliente_CrearUnUsuarioCompleto()
        {
            Guid FakeIdUsuario = Guid.NewGuid();
            string FakeEmail = "tester@mail.com";
            CorreoElectronico FakeCorreo = CorreoElectronico.Crear(FakeEmail);
            string FakePassword = "Micontrasena123";
            Password FakeContasena = Password.Crear(FakePassword);
            Usuario FakeUsuario = Usuario.CrearUsuarioCliente(FakeIdUsuario,FakeCorreo,FakeContasena);
            Assert.NotNull(FakeUsuario);
        }
        [Fact]
        public void Usuario_CrearUsuarioTatuador_CrearUsuarioConCorreoNulo()
        {
            string password = "MiContrasena123";
            CorreoElectronico fakeEmail = null;
            Password FakePassword = Password.Crear(password);
            Guid FakeIdTatuador = Guid.NewGuid();
            Assert.Throws<ArgumentNullException>(() => { Usuario fakeUsuario = Usuario.CrearUsuarioTatuador(FakeIdTatuador, fakeEmail, FakePassword); });
        }
        [Fact]
        public void Usuario_CrearUsuarioTatuador_CrearUsuarioConPasswordNulo()
        {
            string FakeEmail = "tester@mail.com";
            CorreoElectronico FakeCorreo = CorreoElectronico.Crear(FakeEmail);
            Password FakePassword = null;
            Guid FakeIdUsuario = Guid.NewGuid();
            Assert.Throws<ArgumentNullException>(() => { Usuario FakeUsuario = Usuario.CrearUsuarioTatuador(FakeIdUsuario, FakeCorreo, FakePassword); });
        }
        [Fact]
        public void Usuario_CrearUsuarioTatuador_CrearUsuarioCompleto()
        {
            Guid FakeIdUsuario = Guid.NewGuid();
            string FakeEmail = "tester@mail.com";
            CorreoElectronico FakeCorreo = CorreoElectronico.Crear(FakeEmail);
            string FakePassword = "Micontrasena123";
            Password FakeContasena = Password.Crear(FakePassword);
            Usuario FakeUsuario = Usuario.CrearUsuarioTatuador(FakeIdUsuario, FakeCorreo, FakeContasena);
            Assert.NotNull(FakeUsuario);
        }
    }
}
