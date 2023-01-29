using API_Comun;
using API_DominioTatuajes.Agregados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Infraestructura.Interfaces
{
    public interface IRepositorioTatuadorCita : IRepositorio<TatuadorCita>
    {
        IEnumerable<TatuadorCita> ConsultarCitasPorTatuador(Tatuador tatuador);
        TatuadorCita ConsultarCitaPorId(Guid idCita);
    }
}
