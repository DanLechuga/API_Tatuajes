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
            ListaCitasCliente.Add(CitaCliente.Crear(Guid.Parse("00000000-0000-0000-0000-000000000001"),DateTime.Now,true,350.50,Guid.Parse("00000000-0000-0000-0000-000000000002")));
            ListaCitasCliente.Add(CitaCliente.Crear(Guid.Parse("00000000-0000-0000-0000-000000000002"), DateTime.Now, false, 0.0, Guid.Parse("00000000-0000-0000-0000-000000000002")));
            ListaCitasCliente.Add(CitaCliente.Crear(Guid.Parse("00000000-0000-0000-0000-000000000003"), DateTime.Now, false, 0.0, Guid.Parse("00000000-0000-0000-0000-000000000003")));
            ListaCitasCliente.Add(CitaCliente.Crear(Guid.Parse("00000000-0000-0000-0000-000000000004"), DateTime.Now, true, 350.50, Guid.Parse("00000000-0000-0000-0000-000000000002")));
            ListaCitasCliente.Add(CitaCliente.Crear(Guid.Parse("00000000-0000-0000-0000-000000000005"), DateTime.Now, true, 150.95, Guid.Parse("00000000-0000-0000-0000-000000000001")));
        }
        public void Agregar(CitaCliente agregado)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CitaCliente> ConsultaCitaCliente(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void EliminarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(CitaCliente agregado)
        {
            throw new NotImplementedException();
        }
    }
}
