using API_Aplicacion.DTOs;
using API_Aplicacion.Implementacion;
using API_Aplicacion.Interfaces;
using API_Infraestructura.Interfaces;
using PruebasTatuajes.PruebasInfraestructura;
using System;
using Xunit;
using AutoMapper;
using API_Aplicacion.AutoMap;
using API_Tatuajes.AutoMap;

namespace PruebasTatuajes.PruebasAplicacion
{
    public class PruebasServicioValidacionUsuarios
    {
        public IRepositorioUsuario Repositorio { get; }
        public IServicioValidacionUsuarios ServicioValidacion { get; }
        public IRepositorioCliente RepositorioCliente { get;  }
        public IMapper Mapper { get; set; }
        public PruebasServicioValidacionUsuarios()
        {
            if(Mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new DomainToDto());
                    mc.AddProfile(new ModelToDto());

                });
                IMapper mapper = mappingConfig.CreateMapper();
                Mapper = mapper;
            }
            this.Repositorio = new MockRepositorioUsuario();
            this.RepositorioCliente = new MockRepositorioCliente();
            this.ServicioValidacion = new ServicioValidacionUsuarios(Repositorio, RepositorioCliente,Mapper);
        }
        [Fact]
        public void ServicioValidacionUsuarios_ValidacionUsuario_DTONulo()
        {

            DTOUsuario FakeDtoUsuario = null;
            Assert.Throws<Exception>(() => { ServicioValidacion.ValidacionUsuario(FakeDtoUsuario); });
        }
        [Fact]
        public void ServicioValidacionUsuarios_ValidacionUsuario_DTOVacio()
        {
            DTOUsuario FakeDtoUsuario = new();
            Assert.Throws<Exception>(() => { ServicioValidacion.ValidacionUsuario(FakeDtoUsuario); });
        }
        [Fact]
        public void ServicioValidacionUsuarios_ValidacionUsuario_DTOConUsuarioRegistrado()
        {
            DTOUsuario FakeDtoUsuario = new() { Username = "tester@mail.com", Password = "Contraseña123" };
            DTOUsuario usuarioConsultado = ServicioValidacion.ValidacionUsuario(FakeDtoUsuario);
            Assert.True(usuarioConsultado.EsUsuarioValido);
        }
        [Fact]
        public void ServicioValidacionUsuarios_ValidacionUsuario_DTOConPasswordErroneo()
        {
            DTOUsuario FakeDtoUsuario = new() { Username = "tester@mail.com", Password = "Contraseña123!" };
            Assert.Throws<Exception>(() => { DTOUsuario usuarioConsultado = ServicioValidacion.ValidacionUsuario(FakeDtoUsuario); });
        }
        [Fact]
        public void ServicioValidacionUsuarios_ConsultaInformacionCliente_DTONulo()
        {
            DTOUsuario FakeDTOUsuario = null;
            Assert.Throws<Exception>(() => { ServicioValidacion.ConsultaInformacionCliente(FakeDTOUsuario); });
        }
        [Fact]
        public void ServicioValidacionUsuarios_ConsultaInformacionCliente_DTOVacio()
        {
            DTOUsuario FakeDtoUsuario = new();
            Assert.Throws<Exception>(() => { ServicioValidacion.ConsultaInformacionCliente(FakeDtoUsuario); });
        }
        [Fact]
        public void ServicioValidacionUsuarios_ConsultaInformacionCliente_DTOCompleto()
        {
            DTOUsuario FakeDtoUsuario = new() { Username = "tester@mail.com"};
            DTOCliente FakeCliente = ServicioValidacion.ConsultaInformacionCliente(FakeDtoUsuario);
            Assert.NotNull(FakeCliente);
            Assert.Equal("Tester1", FakeCliente.NombreCliente);

        }
        [Fact]
        public void ServicioValidacionUsuarios_ConsultaInformacionCliente_ConsultaInformacionConDtoNulo()
        {
            DTOCliente FakeCliente = null;
            Assert.Throws<Exception>(() => { ServicioValidacion.ConsultaInformacionCliente(FakeCliente); });
        }
        [Fact]
        public void ServicioValidacionUsuarios_ConsultaInformacionCliente_ConsultaInformacionConIdClienteVacio()
        {
            DTOCliente FakeCliente = new() { IdCliente = Guid.Empty };
            Assert.Throws<Exception>(() => { ServicioValidacion.ConsultaInformacionCliente(FakeCliente); });
        }
        [Fact]
        public void ServicioValidacionUsuarios_ConsultaInformacionCliente_ConsultaInformacionConIdClienteAleatorio()
        {
            DTOCliente FakeCliente = new() { IdCliente = Guid.NewGuid() };
            Assert.Throws<Exception>(() => { ServicioValidacion.ConsultaInformacionCliente(FakeCliente); });
            
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
