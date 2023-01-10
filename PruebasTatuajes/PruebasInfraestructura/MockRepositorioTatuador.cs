using API_DominioTatuajes.Agregados;
using API_DominioTatuajes.ObjetosDeValor;
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
            Tatuadors = new() { Tatuador.Crear(Guid.Parse("00000000-0000-0000-0000-000000000001"),"Tester1",CorreoElectronico.Crear("tester@mail.com"),"525611855113"),
                Tatuador.Crear(Guid.Parse("00000000-0000-0000-0000-000000000002"), "Tester2", CorreoElectronico.Crear("tester2@mail.com"), "525611855113"),
                Tatuador.Crear(Guid.Parse("00000000-0000-0000-0000-000000000003"), "Tester3", CorreoElectronico.Crear("tester3@mail.com"), "525611855113")
            };
        }
        public void Agregar(Tatuador agregado)
        {
            throw new NotImplementedException();
        }

        public Tatuador ConsultarPorId(Guid idTatuador)
        {
            return Tatuadors.FirstOrDefault(x => x.Id == idTatuador);
        }

        public IEnumerable<Tatuador> ConsultarTodosLosTatuadores()
        {
            return Tatuadors;
        }

        public void EliminarPorId(Guid id)
        {
            if(Tatuadors.FirstOrDefault(x=>x.Id == id) != null)
            {
                Tatuadors.Remove(Tatuadors.FirstOrDefault(x=>x.Id == id));
            }
        }

        public void Update(Tatuador agregado)
        {
            throw new NotImplementedException();
        }
    }
}
