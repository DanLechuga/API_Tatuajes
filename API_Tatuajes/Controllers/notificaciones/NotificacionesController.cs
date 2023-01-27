using API_Aplicacion.DTOs;
using API_Aplicacion.Interfaces;
using API_Tatuajes.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Tatuajes.Controllers.notificaciones
{
    ///<Summary>Control de notificaiones</Summary>
    [Route("[controller]")]
    [ApiController]
    public class NotificacionesController : ControllerBase
    {
        ///<Summary>Propiedad del servicoo de errores solo lectura</Summary>
        public IServicioError ServicioError { get; }
        ///<Summary>Propiedad del servicio de notificaciones solo lectura</Summary>
        public IServicioNotificaciones ServicioNotificaciones { get; }
        ///<Summary>Contructor de la clase</Summary>
        public NotificacionesController(IServicioError servicioError, IServicioNotificaciones servicioNotificaciones)
        {
            this.ServicioError = servicioError;
            this.ServicioNotificaciones = servicioNotificaciones;
        }
        ///<Summary>Enviar notificaion para recuperar contraseña</Summary>
        [HttpGet]
        [Route("/EnviarNotificacionRecuperacion")]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(InternalExpcetionMessage))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError,Type =typeof(CriticalException))]
        public ObjectResult EnviarNotificacionRecuperacion(Guid idUsuario)
        {            
            ObjectResult result = new(true);
            try
            {
                ServicioNotificaciones.CrearNotificacionRecuperacionPassword(new DTOUsuario{ IdUsaurio = idUsuario});
                result.Value = true;
                result.StatusCode = 200;
            }
            catch (DTOBusinessException ex)
            {
                string response = ServicioError.RegistrarError(new DTOException() { Exception = ex });
                result = Conflict(new InternalExpcetionMessage() { Id = ex.Source, Message = ex.Message, IdDataBase = response });
            }
            catch (Exception ex)
            {
                string response = ServicioError.RegistrarError(new DTOException { Exception = ex });
                result = StatusCode(StatusCodes.Status500InternalServerError, new CriticalException { TrakingCode = response, Origin = ex.Source, Messages = new[] { ex.Message } });
            }
            return result;
        }



    }
}
