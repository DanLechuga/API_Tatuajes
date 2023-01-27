using API_Comun;
using API_DominioTatuajes.Agregados;
using System.Collections.Generic;
using System;

namespace API_Infraestructura.Interfaces
{
    public interface IRepositorioCita: IRepositorio<Cita>
    {
        IEnumerable<Cita> ConsultaCita(Usuario usuario);
        Cita ConsultaCitaPorId(Guid idCita);
    }
}