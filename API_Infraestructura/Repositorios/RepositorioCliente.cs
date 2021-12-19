using API_Comun;
using API_DominioTatuajes.Agregados;
using API_Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Infraestructura.Repositorios
{
    public class RepositorioCliente : IRepositorioCliente
    {
        public IUnidadDeTrabajo UnidadDeTrabajo { get; }
        public RepositorioCliente(IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.UnidadDeTrabajo = unidadDeTrabajo;
        }

        public IEnumerable<Cliente> GetClientes()
        {
            throw new NotImplementedException();
        }

        public Cliente GetClientePorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Agregar(Cliente agregado)
        {
            throw new NotImplementedException();
        }

        public void Update(Cliente agregado)
        {
            throw new NotImplementedException();
        }

        public void EliminarPorId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
