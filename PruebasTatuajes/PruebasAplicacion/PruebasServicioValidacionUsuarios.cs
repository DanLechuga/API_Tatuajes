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
        public IRepositorioUsuario Repositorio { get; set; }
        public IServicioValidacionUsuarios ServicioValidacion { get; set; }
        public PruebasServicioValidacionUsuarios()
        {
            this.Repositorio = new MockRepositorioUsuario();
            this.ServicioValidacion = new ServicioValidacionUsuarios(Repositorio);
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
            DTOUsuario FakeDtoUsuario = new("","");
            Assert.Throws<ArgumentNullException>(() => { ServicioValidacion.ValidacionUsuario(FakeDtoUsuario); });
        }
        [Fact]
        public void ServicioValidacionUsuarios_ValidacionUsuario_DTOConUsuarioRegistrado()
        {
            DTOUsuario FakeDtoUsuario = new("tester@mail.com", "Contraseña123");
           DTOUsuario usuarioConsultado =  ServicioValidacion.ValidacionUsuario(FakeDtoUsuario);
            Assert.True(usuarioConsultado.EsUsuarioValido);
        }
        [Fact]
        public void ServicioValidacionUsuarios_ValidacionUsuario_DTOConPasswordErroneo()
        {
            DTOUsuario FakeDtoUsuario = new("tester@mail.com", "Contaseña123");
            Assert.Throws<Exception>(() => { DTOUsuario usuarioConsultado = ServicioValidacion.ValidacionUsuario(FakeDtoUsuario); }); 
        }
    }
}
