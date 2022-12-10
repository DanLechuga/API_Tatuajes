using API_DominioTatuajes.Agregados;
using API_Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasTatuajes.PruebasInfraestructura
{
    
    public class MockRepositorioTatuajeCita : IRepositorioTatuajeCita
    {
        public List<TatuajeCita> ListadeTatuajes { get; set; }
        public MockRepositorioTatuajeCita()
        {
            ListadeTatuajes = new();
        }

        public void Agregar(TatuajeCita agregado)
        {
            throw new NotImplementedException();
        }

        public void EliminarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(TatuajeCita agregado)
        {
            throw new NotImplementedException();
        }

        public TatuajeCita ConsultarPorIdCita(Guid idCita)
        {
            throw new NotImplementedException();
        }
    }
}
