using API_DominioTatuajes.Agregados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PruebasTatuajes.PruebasDominio
{
   public class PruebasDominioClienteCita
    {
        [Fact]
        public void CrearCitaCliente_CitaCliente_ExceptionControladaAlNoIngresarunIdUsuario()
        {
            DateTime FechaCreacion = DateTime.Parse("15/12/2004");
            Guid idCitaCliente = Guid.NewGuid();
            Guid idCita = Guid.NewGuid();
            Guid idCliente = Guid.NewGuid();
            bool esConAnticipo = false;
            double AnticipoNulo = 0.0;
            Guid idTatuador = Guid.NewGuid();
            string nombreTatuador = "Tester01Tatuador";
            CitaCliente citaCliente = CitaCliente.Crear(idCitaCliente,idCita,idCliente,FechaCreacion,esConAnticipo,AnticipoNulo,idTatuador,nombreTatuador);
            Assert.NotNull(citaCliente);
        }
    }
}
