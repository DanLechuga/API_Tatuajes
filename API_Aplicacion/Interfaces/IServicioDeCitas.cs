using API_Aplicacion.DTOs;
using System.Collections;
using System.Collections.Generic;

namespace API_Aplicacion.Interfaces
{
    public interface IServicioDeCitas
    {
        IEnumerable<DTOCitas> ConsultarCitas(DTOUsuario dTOUsuario);

    }
}