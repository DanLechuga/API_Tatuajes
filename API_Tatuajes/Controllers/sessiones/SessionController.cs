using API_Aplicacion.DTOs;
using API_Aplicacion.Interfaces;
using API_Tatuajes.Exceptions;
using API_Tatuajes.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Tatuajes.Controllers.sessiones
{
    ///<Summary></Summary>
    [ApiController]
    [Route("[controller]")]    
    public class SessionController : ControllerBase
    {
        ///<Summary></Summary>
        public IServicioSession ServicioSession { get; }
        ///<Summary></Summary>
        public IServicioError ServicioError { get; }
        ///<Summary></Summary>
        public SessionController(IServicioSession servicioSession, IServicioError servicioError)
        {
            this.ServicioSession = servicioSession;
            this.ServicioError = servicioError;
        }
        ///<Summary></Summary>
        [HttpPost]
        [Route("/VerificaSession")]
        [ProducesResponseType(409, Type = typeof(InternalExpcetionMessage))]
        [ProducesResponseType(200)]
        public ObjectResult CrearSession(ModeloSession modeloSession)
        {
            ObjectResult result = new(true);
            result.StatusCode = 403;
            try
            {
                DTOSession DtoSession = new() { IdSession = modeloSession.idSession,
                    IdSessionUsuario = modeloSession.idSessionUsuario,
                    IdSessionCliente = modeloSession.idSessionCliente,
                    IdSessionTatuador = modeloSession.idSessionTatuador,
                    IdSessionCreador = modeloSession.idSessionCreador,
                    SessionActiva = modeloSession.sessionActiva};
                ServicioSession.CrearSession(DtoSession);
                result.StatusCode = 200;
                result.Value = true;
                
            }
            catch (Exception ex)
            {
                
                result = Conflict(new InternalExpcetionMessage() { Id = ex.Source,Message = ex.Message});
                ServicioError.RegistrarError(new DTOException() { Exception = ex });
            }
            return result;
        }
        ///<Summary></Summary>
        [HttpGet]
        [Route("/ConsultaSession")]
        [ProducesResponseType(409, Type = typeof(InternalExpcetionMessage))]
        [ProducesResponseType(200, Type = typeof(DTOSession))]
        public ObjectResult ConsultaSession(Guid idCliente)
        {
            if (idCliente == Guid.Empty) throw new ArgumentNullException("No se puede utilizar id en 0");
            ObjectResult result = new(true);
            result.StatusCode = 403;
            try
            {
                 DTOSession sessionConsultada = ServicioSession.ConsultaSessionCliente(new DTOCliente() { IdCliente = idCliente});                
                result.StatusCode = 200;
                result.Value = sessionConsultada;
            }
            catch (Exception ex)
            {
                
                result = Conflict(new InternalExpcetionMessage() { Id = ex.Source,Message = ex.Message});
                ServicioError.RegistrarError(new DTOException() { Exception = ex });
            }
            return result;
        }
        ///<Summary></Summary>
        [HttpGet]
        [Route("/ConsultaSessionTatuador")]
        [ProducesResponseType(409, Type = typeof(InternalExpcetionMessage))]
        [ProducesResponseType(200, Type = typeof(DTOSession))]
        public ObjectResult ConsultaSessionTatuador(Guid idTatuador)
        {
            if (idTatuador == Guid.Empty) throw new ArgumentNullException("No se puede utilizar id en 0");
            ObjectResult result = new(true);
            result.StatusCode = 403;
            try
            {
                DTOSession sessionConsultada = ServicioSession.ConsultaSessionTatuador(new DTOTatuador {idTatuador = idTatuador });
                result.StatusCode = 200;
                result.Value = sessionConsultada;
            }
            catch (Exception ex)
            {

                result = Conflict(new InternalExpcetionMessage() { Id = ex.Source, Message = ex.Message });
                ServicioError.RegistrarError(new DTOException() { Exception = ex });
            }
            return result;
        }
        ///<Summary></Summary>
        [HttpPost]
        [Route("/CerrarSession")]
        [ProducesResponseType(409, Type = typeof(InternalExpcetionMessage))]
        [ProducesResponseType(200)]
        public ObjectResult CerrarSession(ModeloCerrarSession modeloCerrarSession)
        {
            if (modeloCerrarSession == null) throw new ArgumentNullException("No se puede cerrar session debido a falta de argumentos para crear la solicitud");
            if (modeloCerrarSession.idCliente == Guid.Empty) throw new ArgumentNullException("No se puede crear solicitud debido a falta de argumentos para crear la solicitud");
            ObjectResult result = new(true);
            try
            {
                ServicioSession.CerrarSession(new DTOUsuario("", "") { IdUsaurio = modeloCerrarSession.idCliente });
                result.Value = true;
                result.StatusCode = 200;
            }
            catch (Exception ex)
            {
                
                result = Conflict(new InternalExpcetionMessage() { Id = ex.Source,Message = ex.Message});
                ServicioError.RegistrarError(new DTOException() { Exception = ex});
           
            }
          return  result;
        }
        ///<Summary></Summary>
        [HttpPost]
        [Route("/CerrarSessionTatuador")]
        [ProducesResponseType(409, Type = typeof(InternalExpcetionMessage))]
        [ProducesResponseType(200)]
        public ObjectResult CerrarSessionTatuador(ModeloCerrarSessionTatuador modeloCerrarSession)
        {
            if (modeloCerrarSession == null) throw new ArgumentNullException("No se puede cerrar session debido a falta de argumentos para crear la solicitud");
            if (modeloCerrarSession.idTatuador == Guid.Empty) throw new ArgumentNullException("No se puede crear solicitud debido a falta de argumentos para crear la solicitud");
            ObjectResult result = new(true);
            try
            {
                ServicioSession.CerrarSessionTatuador(new DTOTatuador { idTatuador = modeloCerrarSession.idTatuador});
                result.Value = true;
                result.StatusCode = 200;
            }
            catch (Exception ex)
            {

                result = Conflict(new InternalExpcetionMessage() { Id = ex.Source, Message = ex.Message });
                ServicioError.RegistrarError(new DTOException() { Exception = ex });

            }
            return result;
        }


    }
}
