

using API_Aplicacion.DTOs;
using System.Collections.Generic;

namespace API_Aplicacion.Interfaces
{
    public interface IServicioValidacionTatuador
    {
        DTOTatuador ConsultarInfoTatuador(DTOTatuador dTOTatuador);
        IEnumerable<DTOCitasTatuador> ConsultarCitasPorTatuador(DTOTatuador dTOTatuador);
    }
}
