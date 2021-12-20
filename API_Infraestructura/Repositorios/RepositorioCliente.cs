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
     class DTOCliente
    {
        public Guid Cliente_id { get; set; }
        public string Cliente_nombre { get; set; }
        public string Cliente_correo { get; set; }
        public string Cliente_numeroTel { get; set; }
        public string Cliente_password { get; set; }
    }
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
