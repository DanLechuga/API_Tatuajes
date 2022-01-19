using API_DominioTatuajes.Agregados;
using API_Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasTatuajes.PruebasInfraestructura
{
    public class MockRepositorioTatuador : IRepositorioTatuador
    {
        public List<Tatuador> Tatuadors { get; set; }
        public MockRepositorioTatuador()
        {
            Tatuadors = new();
        }
        public void Agregar(Tatuador agregado)
        {
            throw new NotImplementedException();
        }

        public Tatuador ConsultarPorId(Guid idTatuador)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tatuador> ConsultarTodosLosTatuadores()
        {
            throw new NotImplementedException();
        }

        public void EliminarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Tatuador agregado)
        {
            throw new NotImplementedException();
        }
    }
}
