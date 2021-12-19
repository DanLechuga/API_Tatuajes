using API_DominioTatuajes.Agregados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Comun;
namespace API_Infraestructura.Interfaces
{
   public interface IRepositorioCliente: IRepositorio<Cliente>
    {
        IEnumerable<Cliente> GetClientes();
        Cliente GetClientePorId(Guid id);

    }
}
