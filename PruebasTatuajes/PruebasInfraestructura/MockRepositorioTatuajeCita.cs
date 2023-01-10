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
            ListadeTatuajes = new() { TatuajeCita.Crear(Guid.Parse("00000000-0000-0000-0000-000000000001"),Guid.Parse("00000000-0000-0000-0000-000000000001"),1,null),
                TatuajeCita.Crear(Guid.Parse("00000000-0000-0000-0000-000000000002"), Guid.Parse("00000000-0000-0000-0000-000000000002"), 2, null),
                TatuajeCita.Crear(Guid.Parse("00000000-0000-0000-0000-000000000003"), Guid.Parse("00000000-0000-0000-0000-000000000003"), 3, null),
                TatuajeCita.Crear(Guid.Parse("00000000-0000-0000-0000-000000000004"), Guid.Parse("00000000-0000-0000-0000-000000000004"), 4, null)
            };
        }

        public void Agregar(TatuajeCita agregado)
        {
            if(!(agregado.TatuajeCita_IdCita == ListadeTatuajes.FirstOrDefault(x => x.TatuajeCita_IdCita == agregado.TatuajeCita_IdCita).TatuajeCita_IdCita))
            {
                ListadeTatuajes.Add(agregado);
            }
            
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
            return ListadeTatuajes.FirstOrDefault(x => x.TatuajeCita_IdCita == idCita);
        }
    }
}
