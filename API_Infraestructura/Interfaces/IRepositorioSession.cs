using API_Comun;
using API_DominioTatuajes.Agregados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Infraestructura.Interfaces
{
   public interface IRepositorioSession : IRepositorio<Session>
    {
        IEnumerable<Session> GetSessions();
        Session GetSessionPorId(Guid id);
        Session GetSessionPorUsuario(Guid idUsuario);
    }
}
