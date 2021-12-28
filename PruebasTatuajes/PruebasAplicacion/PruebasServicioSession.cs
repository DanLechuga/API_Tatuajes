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
   public class PruebasServicioSession
    {
        public IRepositorioSession RepositorioSession { get; set; }
        public IServicioSession ServicioSession { get;  }
        public PruebasServicioSession()
        {
            this.RepositorioSession = new MockRepositorioSession();
            this.ServicioSession = new ServicioSession(RepositorioSession);
        }
        [Fact]
        public void ServicioSession_CrearSession_SessionConDTONulo()
        {
            DTOSession dtoSession = null;

            Assert.Throws<ArgumentNullException>(() => { ServicioSession.CrearSession(dtoSession); }); 
        }
        [Fact]
        public void ServicioSession_CrearSession_SessionConIdSessionVacio()
        {
            DTOSession dTOSession = new() { IdSession = Guid.Empty};
            Assert.Throws<ArgumentNullException>(() => { ServicioSession.CrearSession(dTOSession); });
            

        }
        [Fact]
        public void ServicioSession_CrearSession_SessionConIdSessionUsuarioVacio()
        {
            DTOSession dTOSession = new() { IdSession = Guid.NewGuid(),IdSessionUsuario = Guid.Empty };
            Assert.Throws<ArgumentNullException>(() => { ServicioSession.CrearSession(dTOSession); });
        }
        [Fact]
        public void ServicioSession_CrearSession_SessionCreada()
        {
            DTOSession dTOSession = new() { IdSession = Guid.Parse("00000000-0000-0000-0000-000000000006"), IdSessionUsuario = Guid.NewGuid(),IdSessionCliente = Guid.NewGuid(),IdSessionTatuador = Guid.Empty,SessionActiva = true};
            ServicioSession.CrearSession(dTOSession);
            Assert.Equal(6,RepositorioSession.GetSessions().ToList().Count);
        }
        [Fact]
        public void ServicioSession_ConsultaSessionCliente_SessionConDTONulo()
        {
            DTOCliente dTOCliente = null;
            Assert.Throws<ArgumentNullException>(() => { ServicioSession.ConsultaSessionCliente(dTOCliente); }); 
            
        } 
        [Fact]
        public void ServicioSession_ConsultaSessionCliente_SessionidClienteVacio()
        {
            DTOCliente dTOCliente = new() { IdCliente = Guid.Empty};
            Assert.Throws<ArgumentNullException>(() => { ServicioSession.ConsultaSessionCliente(dTOCliente); });
        }
        [Fact]
        public void ServicioSession_ConsultaSessionCliente_ConsultaDTOSession()
        {
            DTOCliente dTOCliente = new() { IdCliente = Guid.Parse("00000000-0000-0000-0000-000000000001") };
            DTOSession dTOSession = ServicioSession.ConsultaSessionCliente(dTOCliente);
            Assert.NotNull(dTOSession);
            Assert.True(dTOSession.SessionActiva);
        }



    }
}
