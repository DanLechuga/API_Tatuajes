using API_Aplicacion;
using API_Aplicacion.Implementacion;
using API_Aplicacion.Interfaces;
using API_Infraestructura.Interfaces;
using API_Tatuajes.Controllers;
using PruebasTatuajes.PruebasInfraestructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PruebasTatuajes.PruebasUI
{
   public class PruebasControllerCitas
    {
        public IRepositorioCita RepositorioCita { get; set; }
        public IRepositorioUsuario RepositorioUsuario { get; set; }
        public IRepositorioClienteCita RepositorioClienteCita { get; set; }
        public IServicioDeCitas ServicioDeCitas { get; set; }
        public IRepositorioError RepositorioError { get; set; }
        public IServicioError ServicioError { get; set; }
        public CitasController CitasController { get; set; }
        public PruebasControllerCitas()
        {
            RepositorioUsuario = new MockRepositorioUsuario();
            RepositorioCita = new MockRepositorioCita();
            RepositorioClienteCita = new MockRepositorioClienteCita();
            RepositorioError = new MockRepositorioError();
            ServicioError = new ServicioError(RepositorioError);
            ServicioDeCitas = new ServicioCitas(RepositorioCita,RepositorioClienteCita,RepositorioUsuario);
            CitasController = new(ServicioDeCitas,ServicioError);
        }
        [Fact]
        public void ConsultaDeCitas_Citas_ErrorDeCosnultaPorIdInexistente()
        {
            Guid idUsuario = Guid.Empty;

            
        }
    }
}
