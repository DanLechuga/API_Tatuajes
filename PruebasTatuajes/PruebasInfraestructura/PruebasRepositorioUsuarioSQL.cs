using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Comun;
using API_DominioTatuajes.Agregados;
using API_Infraestructura.Repositorios;
using Xunit;

namespace PruebasTatuajes.PruebasInfraestructura
{
   public class PruebasRepositorioUsuarioSQL
    {
        public IUnidadDeTrabajo UnidadDeTrabajo { get; }
        public PruebasRepositorioUsuarioSQL()
        {
            UnidadDeTrabajo = new UnidadDetrabajo("Server=localhost;Database=Tatuajes;Trusted_Connection=True;");
        }
        [Fact]
        public void RepositorioUsuario_GetUsuarioPorCorreo_ConsultaUnUsuarioInexistente()
        {
            
            RepositorioUsuario repositorioUsuario = new(UnidadDeTrabajo);
            Usuario usuarioprueba = repositorioUsuario.GetUsuarioPorCorreo("tester10@mail.com");
            Assert.Null(usuarioprueba);

        }
        [Fact]
        public void RepositorioUsuario_GetUsuarioPorCorreo_ConsultaUnUsuarioExistente()
        {            
            RepositorioUsuario repositorioUsuario = new(UnidadDeTrabajo);
             Usuario usuarioprueba = repositorioUsuario.GetUsuarioPorCorreo("danlechuga@live.com");
            Assert.NotNull(usuarioprueba);
        }
        [Fact]
        public void RepositorioUsuario_GetUsuarioPorCorreo_ConsultaUnUsuarioConCorreoVacio()
        {
            RepositorioUsuario repositorioUsuario = new(UnidadDeTrabajo);
            Assert.Throws<Exception>(() => { Usuario usuarioprueba = repositorioUsuario.GetUsuarioPorCorreo(""); });    
        }
    }
}
