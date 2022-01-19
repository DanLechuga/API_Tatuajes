using API_DominioTatuajes.Agregados;
using API_Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasTatuajes.PruebasInfraestructura
{
    public class MockRepositorioTatuadorCita : IRepositorioTatuadorCita
    {
        List<TatuadorCita> ListaTatuadesCitas { get; set; }
        public MockRepositorioTatuadorCita()
        {
            ListaTatuadesCitas = new();
        }
        public void Agregar(TatuadorCita agregado)
        {
            throw new NotImplementedException();
        }

        public void EliminarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(TatuadorCita agregado)
        {
            throw new NotImplementedException();
        }
    }
}
