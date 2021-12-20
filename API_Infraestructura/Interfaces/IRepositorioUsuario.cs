using API_Comun;
using API_DominioTatuajes.Agregados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Infraestructura.Interfaces
{
   public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        IEnumerable<Usuario> GetUsuarios();
        Usuario GetUsuarioPorId(Guid id);
        Usuario GetUsuarioPorCorreo(string correo);
    }
}
