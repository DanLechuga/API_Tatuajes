using API_Comun;
using API_DominioTatuajes.Agregados;
using API_Infraestructura.Interfaces;
using API_Infraestructura.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PruebasTatuajes.PruebasInfraestructura
{
   public class PruebasRepositorioClienteSQL
    {
        public IUnidadDeTrabajo UnidadDeTrabajo { get; }
        public IRepositorioCliente RepositorioCliente { get; }
        public PruebasRepositorioClienteSQL()
        {
            UnidadDeTrabajo = new UnidadDetrabajo("Server=localhost;Database=Tatuajes;Trusted_Connection=True;");
            RepositorioCliente = new RepositorioCliente(UnidadDeTrabajo);
        }
        [Fact]
        public void RepositorioCliente_GetClintePorCorreo_ConsultaClienteConCorreoVacio()
        {
            Assert.Throws<ArgumentNullException>(() => { Cliente FakeCliente = RepositorioCliente.GetClintePorCorreo(""); });
        }
        [Fact]
        public void RepositorioCliente_GetClintePorCorreo_ConsultaClienteConCorreoInexistente()
        {
            Assert.Throws<ArgumentNullException>(() => { Cliente FakeCliente = RepositorioCliente.GetClintePorCorreo("tester@mail.com"); });
        }
        [Fact]
        public void RepositorioCliente_GetClintePorCorreo_ConsultaClienteConCorreoExistente()
        {
            Cliente FakeCliente = RepositorioCliente.GetClintePorCorreo("danlechuga@live.com");
            Assert.NotNull(FakeCliente);
            Assert.Equal("DanLechuga",FakeCliente.Cliente_nombre);
        }
    }
}
