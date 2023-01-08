using API_Aplicacion.DTOs;
using API_Aplicacion.Interfaces;
using API_Tatuajes.Exceptions;
using API_Tatuajes.Modelos;
using AutoMapper;
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
        /// <summary>
        /// 
        /// </summary>
        public IMapper mapper { get; set; }
        ///<Summary></Summary>
        public SessionController(IServicioSession servicioSession, IServicioError servicioError,IMapper _mapper)
        {
            this.ServicioSession = servicioSession;
            this.ServicioError = servicioError;
            this.mapper = _mapper;
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
                if (modeloSession is null) throw new Exception("No se pueden usar valores vacios");
                if (modeloSession.idSession == Guid.Empty) throw new Exception("No se puede usar valor vacio para crear una session");
                if (modeloSession.idSessionUsuario == Guid.Empty) throw new Exception("No se puede usar valor vacio para crear una session sin id de usuario");
                DTOSession dtoSession = mapper.Map<DTOSession>(modeloSession);                
                ServicioSession.CrearSession(dtoSession);
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
        [HttpGet]
        [Route("/ConsultaSessionCreador")]
        [ProducesResponseType(409, Type = typeof(InternalExpcetionMessage))]
        [ProducesResponseType(200, Type = typeof(DTOSession))]
        public ObjectResult ConsultaSessionCreador(Guid idCreador)
        {
            
            ObjectResult result = new(true);
            result.StatusCode = 403;
            try
            {
                DTOSession sessionConsultada = ServicioSession.ConsultaSessionCreador(new DTOCreador { IdCreador = idCreador});
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
        public ObjectResult CerrarSession(ModeloCerrarSessionCliente modeloCerrarSession)
        {            
            ObjectResult result = new(true);
            try
            {
                DTOUsuario dTOUsuario = mapper.Map<DTOUsuario>(modeloCerrarSession);
                ServicioSession.CerrarSession(dTOUsuario);
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
            ObjectResult result = new(true);
            try
            {
                DTOTatuador dtoTatuador = mapper.Map<DTOTatuador>(modeloCerrarSession);
                ServicioSession.CerrarSessionTatuador(dtoTatuador);
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
        ///<Summary></Summary>
        [HttpPost]
        [Route("/CerrarSessionCreador")]
        [ProducesResponseType(409, Type = typeof(InternalExpcetionMessage))]
        [ProducesResponseType(200)]
        public ObjectResult CerrarSessionCreador(ModeloCerrarSessionCreador modeloCerrar)
        {
            
            ObjectResult result = new(true);
            try
            {
                DTOCreador dTOCreador = mapper.Map<DTOCreador>(modeloCerrar);
                ServicioSession.CerrarSessionCreaddor(dTOCreador);
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
