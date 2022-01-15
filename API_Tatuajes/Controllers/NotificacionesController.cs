using API_Aplicacion.DTOs;
using API_Aplicacion.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Tatuajes.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NotificacionesController : ControllerBase
    {
        public IServicioError ServicioError { get;  }
        public IServicioNotificaciones ServicioNotificaciones { get; }
        public NotificacionesController(IServicioError servicioError, IServicioNotificaciones servicioNotificaciones)
        {
            this.ServicioError = servicioError;
            this.ServicioNotificaciones = servicioNotificaciones;
        }
        [HttpGet]
        [Route("/EnviarNotificacionRecuperacion")]
        public JsonResult EnviarNotificacionRecuperacion(Guid idUsuario)
        {
            if (idUsuario == Guid.Empty) throw new ArgumentNullException("No se puede usar un id vacio");
            JsonResult result = new(true);
            try
            {
                ServicioNotificaciones.CrearNotificacionRecuperacionPassword(new DTOUsuario("", "") { IdUsaurio = idUsuario});
                result.Value = true;
                result.StatusCode = 200;
            }
            catch (Exception ex)
            {
                result.Value = ex.Message;
                result.StatusCode = 500;
                ServicioError.RegistrarError(new DTOException() { Exception = ex});
            }
            return result;
        }



    }
}
