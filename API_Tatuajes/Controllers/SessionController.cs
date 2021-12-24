using API_Aplicacion.DTOs;
using API_Aplicacion.Interfaces;
using API_Tatuajes.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Tatuajes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        public IServicioSession ServicioSession { get; }
        public SessionController(IServicioSession servicioSession)
        {
            this.ServicioSession = servicioSession;
        }

        [Route("/CrearSession")]
        [HttpPost]
        public JsonResult CrearSession(ModeloSession modeloSession)
        {
            if (modeloSession == null) throw new ArgumentNullException("No se puede usar valores nulos");
            if (modeloSession.IdSession == Guid.Empty) throw new ArgumentNullException("No se puede usar valores en 0");
            if (modeloSession.IdSessionUsuario == Guid.Empty) throw new ArgumentNullException("No se puede usar valores en 0");
            JsonResult result = new(true);
            result.StatusCode = 403;
            try
            {
                DTOSession DtoSession = new() { IdSession = modeloSession.IdSession,IdSessionUsuario = modeloSession.IdSessionUsuario, IdSessionCliente = modeloSession.IdSessionCliente, IdSessionTatuador = modeloSession.IdSessionTatuador, SessionActiva = modeloSession.SessionActiva};
                ServicioSession.CrearSession(DtoSession);
                result.StatusCode = 200;
                result.Value = true;
                
            }
            catch (Exception ex)
            {
                result.StatusCode = 500;
                result.Value = ex.Message;
                
            }
            return result;
        }
    }
}
