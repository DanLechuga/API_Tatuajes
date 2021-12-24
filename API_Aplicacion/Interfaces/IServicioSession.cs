using API_Aplicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Aplicacion.Interfaces
{
   public interface IServicioSession
    {
        void CrearSession(DTOSession dTOSession);
    }
}
