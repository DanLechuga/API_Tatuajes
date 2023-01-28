using API_Aplicacion.DTOs;
using System;
using System.Collections;
using System.Collections.Generic;

namespace API_Aplicacion.Interfaces
{
    public interface IServicioDeCitas
    {
        IEnumerable<DTOCitas> ConsultarCitas(DTOUsuario dTOUsuario);
        void CrearCita(DTOCitas dTOCitas);
        IEnumerable<Guid> ConsultasIds(DTOUsuario dTOUsuario);
        DTOCitas ConsultarCita(DTOCitas dTOCitas);
        void ActualizarCita(DTOCitas dTOCitas);
        void EliminarCitaPorId(Guid idCita);
    }
}