using API_DominioTatuajes.Agregados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PruebasTatuajes.PruebasDominio
{
  public class PruebasDominioCita
    {
        [Fact]
        public void CrearCita_Cita_CrearUnaCitaNueva()
        {
            Guid idCita = Guid.NewGuid();
            DateTime FechaCreaacion = DateTime.Now;
            DateTime FechaEliminacion = DateTime.Parse("15/12/2004");
            
            Cita cita = Cita.Crear(idCita,FechaCreaacion,FechaEliminacion,FechaEliminacion);
            Assert.NotNull(cita);
        }
    }
}
