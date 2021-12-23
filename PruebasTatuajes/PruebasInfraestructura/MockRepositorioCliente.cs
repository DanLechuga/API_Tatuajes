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
    public class MockRepositorioCliente : IRepositorioCliente
    {
        public List<Cliente> ListaDeClientes { get; set; }
        public MockRepositorioCliente()
        {
            ListaDeClientes = new();
            ListaDeClientes.Add(Cliente.Crear(Guid.Parse("00000000-0000-0000-0000-000000000001"), "Tester1", CorreoElectronico.Crear("tester@mail.com"), Password.Crear("Contraseña123"), "(52)5611855113"));
            ListaDeClientes.Add(Cliente.Crear(Guid.Parse("00000000-0000-0000-0000-000000000002"), "Tester2", CorreoElectronico.Crear("tester1@mail.com"), Password.Crear("Contraseña123"), "(52)5611855113"));
            ListaDeClientes.Add(Cliente.Crear(Guid.Parse("00000000-0000-0000-0000-000000000003"), "Tester3", CorreoElectronico.Crear("tester2@mail.com"), Password.Crear("Contraseña123"), "(52)5611855113"));
            ListaDeClientes.Add(Cliente.Crear(Guid.Parse("00000000-0000-0000-0000-000000000004"), "Tester4", CorreoElectronico.Crear("tester3@mail.com"), Password.Crear("Contraseña123"), "(52)5611855113"));
            ListaDeClientes.Add(Cliente.Crear(Guid.Parse("00000000-0000-0000-0000-000000000005"), "Tester5", CorreoElectronico.Crear("tester4@mail.com"), Password.Crear("Contraseña123"), "(52)5611855113"));

        }
        public void Agregar(Cliente agregado)
        {
            Cliente clienteConsultado = ListaDeClientes.FirstOrDefault(x => x.Id == agregado.Id);
            if (clienteConsultado != null) ListaDeClientes.Remove(agregado);
            ListaDeClientes.Add(agregado);

        }

        public void EliminarPorId(Guid id)
        {
            Cliente clienteConsultado = ListaDeClientes.FirstOrDefault(x => x.Id == id);
            if (clienteConsultado == null) return;
            ListaDeClientes.Remove(clienteConsultado);
        }

        public Cliente GetClientePorId(Guid id)
        {
            return ListaDeClientes.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Cliente> GetClientes()
        {
            return ListaDeClientes;
        }

        public Cliente GetClintePorCorreo(string correoElectronico)
        {
            return ListaDeClientes.FirstOrDefault(x => x.Cliente_correo.Cadenavalida == correoElectronico);
        }

        public void Update(Cliente agregado)
        {
            Cliente clienteConsultado = ListaDeClientes.FirstOrDefault(x => x.Id == agregado.Id);
            if (clienteConsultado != null) ListaDeClientes.Remove(agregado);
            ListaDeClientes.Add(agregado);
        }
    }
}
