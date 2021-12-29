using API_Aplicacion.DTOs;
using API_Aplicacion.Implementacion;
using API_Aplicacion.Interfaces;
using API_Infraestructura.Interfaces;
using PruebasTatuajes.PruebasInfraestructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PruebasTatuajes.PruebasAplicacion
{
    public class PruebasServicioValidacionUsuarios
    {
        public IRepositorioUsuario Repositorio { get; }
        public IServicioValidacionUsuarios ServicioValidacion { get; }
        public IRepositorioCliente RepositorioCliente { get;  }
        public PruebasServicioValidacionUsuarios()
        {
            this.Repositorio = new MockRepositorioUsuario();
            this.RepositorioCliente = new MockRepositorioCliente();
            this.ServicioValidacion = new ServicioValidacionUsuarios(Repositorio, RepositorioCliente);
        }
        [Fact]
        public void ServicioValidacionUsuarios_ValidacionUsuario_DTONulo()
        {

            DTOUsuario FakeDtoUsuario = null;
            Assert.Throws<ArgumentNullException>(() => { ServicioValidacion.ValidacionUsuario(FakeDtoUsuario); });
        }
        [Fact]
        public void ServicioValidacionUsuarios_ValidacionUsuario_DTOVacio()
        {
            DTOUsuario FakeDtoUsuario = new("", "");
            Assert.Throws<ArgumentNullException>(() => { ServicioValidacion.ValidacionUsuario(FakeDtoUsuario); });
        }
        [Fact]
        public void ServicioValidacionUsuarios_ValidacionUsuario_DTOConUsuarioRegistrado()
        {
            DTOUsuario FakeDtoUsuario = new("tester@mail.com", "Contraseña123");
            DTOUsuario usuarioConsultado = ServicioValidacion.ValidacionUsuario(FakeDtoUsuario);
            Assert.True(usuarioConsultado.EsUsuarioValido);
        }
        [Fact]
        public void ServicioValidacionUsuarios_ValidacionUsuario_DTOConPasswordErroneo()
        {
            DTOUsuario FakeDtoUsuario = new("tester@mail.com", "Contaseña123");
            Assert.Throws<Exception>(() => { DTOUsuario usuarioConsultado = ServicioValidacion.ValidacionUsuario(FakeDtoUsuario); });
        }
        [Fact]
        public void ServicioValidacionUsuarios_ConsultaInformacionCliente_DTONulo()
        {
            DTOUsuario FakeDTOUsuario = null;
            Assert.Throws<ArgumentNullException>(() => { ServicioValidacion.ConsultaInformacionCliente(FakeDTOUsuario); });
        }
        [Fact]
        public void ServicioValidacionUsuarios_ConsultaInformacionCliente_DTOVacio()
        {
            DTOUsuario FakeDtoUsuario = new("", "");
            Assert.Throws<ArgumentNullException>(() => { ServicioValidacion.ConsultaInformacionCliente(FakeDtoUsuario); });
        }
        [Fact]
        public void ServicioValidacionUsuarios_ConsultaInformacionCliente_DTOCompleto()
        {
            DTOUsuario FakeDtoUsuario = new("tester@mail.com", "");
            DTOCliente FakeCliente = ServicioValidacion.ConsultaInformacionCliente(FakeDtoUsuario);
            Assert.NotNull(FakeCliente);
            Assert.Equal("Tester1", FakeCliente.NombreCliente);

        }
        [Fact]
        public void ServicioValidacionUsuarios_ConsultaInformacionCliente_ConsultaInformacionConDtoNulo()
        {
            DTOCliente FakeCliente = null;
            Assert.Throws<ArgumentNullException>(() => { ServicioValidacion.ConsultaInformacionCliente(FakeCliente); });
        }
        [Fact]
        public void ServicioValidacionUsuarios_ConsultaInformacionCliente_ConsultaInformacionConIdClienteVacio()
        {
            DTOCliente FakeCliente = new() { IdCliente = Guid.Empty };
            Assert.Throws<ArgumentNullException>(() => { ServicioValidacion.ConsultaInformacionCliente(FakeCliente); });
        }
        [Fact]
        public void ServicioValidacionUsuarios_ConsultaInformacionCliente_ConsultaInformacionConIdClienteAleatorio()
        {
            DTOCliente FakeCliente = new() { IdCliente = Guid.NewGuid() };
            Assert.Throws<ArgumentNullException>(() => { ServicioValidacion.ConsultaInformacionCliente(FakeCliente); });
            
        }
        [Fact]
        public void ServicioValidacionUsuarios_ConsultaInformacionCliente_ConsultaInformacionConIdClienteExistente()
        {
            DTOCliente FakeCliente = new() { IdCliente = Guid.Parse("00000000-0000-0000-0000-000000000001") };
            DTOCliente clienteConsultado = ServicioValidacion.ConsultaInformacionCliente(FakeCliente);
            Assert.NotNull(clienteConsultado);
            Assert.Equal(Guid.Parse("00000000-0000-0000-0000-000000000001"),clienteConsultado.IdCliente);
        }
    }
}
