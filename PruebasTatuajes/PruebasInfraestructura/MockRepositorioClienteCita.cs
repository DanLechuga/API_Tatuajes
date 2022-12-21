using API_DominioTatuajes.Agregados;
using API_Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PruebasTatuajes.PruebasInfraestructura
{
    public class MockRepositorioClienteCita : IRepositorioClienteCita
    {
        public List<CitaCliente> ListaCitasCliente { get; set; }
        public MockRepositorioClienteCita()
        {
            ListaCitasCliente = new();
            ListaCitasCliente.Add(CitaCliente.Crear(Guid.Parse("00000000-0000-0000-0000-000000000001"), Guid.Parse("00000000-0000-0000-0000-000000000001"), Guid.Parse("00000000-0000-0000-0000-000000000001"), DateTime.Now,true,350.50,Guid.Parse("00000000-0000-0000-0000-000000000002"),"Tester"));
            ListaCitasCliente.Add(CitaCliente.Crear(Guid.Parse("00000000-0000-0000-0000-000000000002"), Guid.Parse("00000000-0000-0000-0000-000000000002"), Guid.Parse("00000000-0000-0000-0000-000000000002"), DateTime.Now, false, 0.0, Guid.Parse("00000000-0000-0000-0000-000000000002"), "Tester"));
            ListaCitasCliente.Add(CitaCliente.Crear(Guid.Parse("00000000-0000-0000-0000-000000000003"), Guid.Parse("00000000-0000-0000-0000-000000000003"), Guid.Parse("00000000-0000-0000-0000-000000000003"), DateTime.Now, false, 0.0, Guid.Parse("00000000-0000-0000-0000-000000000003"), "Tester"));
            ListaCitasCliente.Add(CitaCliente.Crear(Guid.Parse("00000000-0000-0000-0000-000000000004"), Guid.Parse("00000000-0000-0000-0000-000000000004"), Guid.Parse("00000000-0000-0000-0000-000000000004"), DateTime.Now, true, 350.50, Guid.Parse("00000000-0000-0000-0000-000000000002"), "Tester"));
            ListaCitasCliente.Add(CitaCliente.Crear(Guid.Parse("00000000-0000-0000-0000-000000000005"), Guid.Parse("00000000-0000-0000-0000-000000000005"), Guid.Parse("00000000-0000-0000-0000-000000000005"), DateTime.Now, true, 150.95, Guid.Parse("00000000-0000-0000-0000-000000000001"), "Tester"));
        }
        public void Agregar(CitaCliente agregado)
        {
            if (agregado is null) throw new ArgumentNullException("No se puede utilizar objeto vacio");
            if (ListaCitasCliente.Find(x => x.Id == agregado.Id) != null) ListaCitasCliente.Remove(agregado);
            ListaCitasCliente.Add(agregado);
        }

        public IEnumerable<CitaCliente> ConsultaCitaCliente(Usuario usuario)
        {
            return ListaCitasCliente;
        }

        public void EliminarPorId(Guid id)
        {
            CitaCliente citaCliente = ListaCitasCliente.Find(x => x.Id == id);
            if (!(citaCliente is null)) ListaCitasCliente.Remove(citaCliente);
            
        }

        public void Update(CitaCliente agregado)
        {
            CitaCliente citaCliente = ListaCitasCliente.Find(x => x.Id == agregado.Id);
            if (!(citaCliente is null))
            {
                ListaCitasCliente.Remove(citaCliente);
                ListaCitasCliente.Add(agregado);
            }
        }
       

        public CitaCliente ConsultarCitaClientePorId(Guid idCita)
        {
            return ListaCitasCliente.FirstOrDefault(x => x.Id == idCita);
        }

        public void ActualizarCita(CitaCliente cita)
        {
            throw new NotImplementedException();
        }
    }
}
