

using API_Aplicacion.DTOs;
using System;
using System.Collections.Generic;

namespace API_Aplicacion.Interfaces
{
    public interface IServicioValidacionTatuador
    {
        DTOTatuador ConsultarInfoTatuador(DTOTatuador dTOTatuador);
        IEnumerable<DTOCitasTatuador> ConsultarCitasPorTatuador(DTOTatuador dTOTatuador);
        IEnumerable<Guid> ConsultarListaIdsCitas(DTOTatuador dTOTatuador);
        DTOCitasTatuador ConsultarDetalleCita(DTOTatuador dTOTatuador, Guid idCita);
    }
}
