﻿using API_Aplicacion.DTOs;
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
        DTOSession ConsultaSessionCliente(DTOCliente cliente);
        void CerrarSession(DTOUsuario dTOUsuario);
        void CerrarSessionTatuador(DTOTatuador dTOTatuador);
        DTOSession ConsultaSessionTatuador(DTOTatuador dTOTatuador);
        void CerrarSessionCreaddor(DTOCreador dTOCreador);
        DTOSession ConsultaSessionCreador(DTOCreador dTOCreador);
    }
}
