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
            ListaTatuadesCitas = new() { TatuadorCita.Crear(Guid.Parse("00000000-0000-0000-0000-000000000001"), Guid.Parse("00000000-0000-0000-0000-000000000001"), Guid.Parse("00000000-0000-0000-0000-000000000001")),
                TatuadorCita.Crear(Guid.Parse("00000000-0000-0000-0000-000000000002"), Guid.Parse("00000000-0000-0000-0000-000000000002"), Guid.Parse("00000000-0000-0000-0000-000000000002")),
                TatuadorCita.Crear(Guid.Parse("00000000-0000-0000-0000-000000000003"), Guid.Parse("00000000-0000-0000-0000-000000000003"), Guid.Parse("00000000-0000-0000-0000-000000000003"))
            };
        }
        public void Agregar(TatuadorCita agregado)
        {
            throw new NotImplementedException();
        }

        public void EliminarPorId(Guid id)
        {
            if(ListaTatuadesCitas.FirstOrDefault(x => x.Id == id) != null)
            {
                ListaTatuadesCitas.Remove(ListaTatuadesCitas.FirstOrDefault(x => x.Id == id));
            }
        }

        public void Update(TatuadorCita agregado)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TatuadorCita> ConsultarCitasPorTatuador(Tatuador tatuador)
        {
            return ListaTatuadesCitas;
        }

        public TatuadorCita ConsultarCitaPorId(Guid idCita)
        {
            throw new NotImplementedException();
        }
    }
}
