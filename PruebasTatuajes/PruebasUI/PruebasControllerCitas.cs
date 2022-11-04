using API_Aplicacion;
using API_Aplicacion.Implementacion;
using API_Aplicacion.Interfaces;
using API_Infraestructura.Interfaces;
using API_Tatuajes.Controllers.citas;
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
        public IRepositorioTatuador RepositorioTatuador { get; set; }
        public IRepositorioTatuadorCita RepositorioTatuadorCita { get; set; }
        public IRepositorioTatuajeCita RepositorioTatuajeCita { get; set; }
        public CitasController CitasController { get; set; }
        public PruebasControllerCitas()
        {
            RepositorioUsuario = new MockRepositorioUsuario();
            RepositorioCita = new MockRepositorioCita();
            RepositorioClienteCita = new MockRepositorioClienteCita();
            RepositorioError = new MockRepositorioError();
            RepositorioTatuador = new MockRepositorioTatuador();
            RepositorioTatuadorCita = new MockRepositorioTatuadorCita();
            RepositorioTatuajeCita = new MockRepositorioTatuajeCita();
            ServicioError = new ServicioError(RepositorioError);
            ServicioDeCitas = new ServicioCitas(RepositorioCita,RepositorioClienteCita,RepositorioUsuario, RepositorioTatuador,RepositorioTatuadorCita,RepositorioTatuajeCita);
            CitasController = new(ServicioDeCitas,ServicioError);
        }
        [Fact]
        public void ConsultaDeCitas_Citas_ErrorDeCosnultaPorIdInexistente()
        {
            Guid idUsuario = Guid.Empty;

            
        }
    }
}
