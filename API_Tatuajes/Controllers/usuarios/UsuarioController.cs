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

namespace API_Tatuajes.Controllers.usuarios
{
    ///<Summary></Summary>
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        ///<Summary></Summary>
        public IServicioValidacionUsuarios ServicioValidacionUsuarios { get; }
        ///<Summary></Summary>
        public IServicioError ServicioError { get; }
        /// <summary>
        /// 
        /// </summary>
        public IMapper mapper { get; set; }
        ///<Summary></Summary>
        public UsuarioController(IServicioValidacionUsuarios servicioValidacionUsuarios,IServicioError servicioError,IMapper _mapper)
        {
            this.ServicioValidacionUsuarios = servicioValidacionUsuarios;
            this.ServicioError = servicioError;
            this.mapper = _mapper;
        }
        /// <summary>
        /// Peticion Post para validar el usuario y password que se ingresan
        /// </summary>
        /// <param name="modeloUsuario"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/ValidarUsuario")]
        [ProducesResponseType(StatusCodes.Status409Conflict,Type = typeof(InternalExpcetionMessage))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DTOUsuario))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError,Type=typeof(CriticalException))]
        public ObjectResult ValidarUsuario(ModeloUsuario modeloUsuario)
        {
            
            ObjectResult result = new(true);
            result.StatusCode = 403;
            try
            {
                DTOUsuario dtoUsuario = mapper.Map<DTOUsuario>(modeloUsuario);                
              DTOUsuario dtoUsuarioConsultado = ServicioValidacionUsuarios.ValidacionUsuario(dtoUsuario);
                result.StatusCode = 200;
                result.Value = dtoUsuarioConsultado; 
            }
            catch(DTOBusinessException  ex)
            {                
                string response = ServicioError.RegistrarError(new DTOException() { Exception = ex});
                result = Conflict(new InternalExpcetionMessage() { Id = ex.Source,Message = ex.Message,IdDataBase = response});
            }
            catch (Exception ex)
            {
                string response = ServicioError.RegistrarError(new DTOException { Exception = ex });
                result = StatusCode(StatusCodes.Status500InternalServerError, new CriticalException { TrakingCode = response, Origin = ex.Source, Messages = new[] { ex.Message } });
            }
            return result;
        }
        /// <summary>
        /// Peticion Get para consultar la informacion del cliente por correo o email
        /// </summary>
        /// <param name="correoUsuario"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/ConsultaInfoCliente")]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(InternalExpcetionMessage))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DTOCliente))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError,Type = typeof(CriticalException))]
        public ObjectResult ConsultaInfoCliente(string correoUsuario)
        {
            if (string.IsNullOrEmpty(correoUsuario)) throw new ArgumentNullException("No se puede utlizar valores vacios o nulos");
            ObjectResult result = new(true);
            result.StatusCode = 403;
            try
            {
                DTOUsuario dTOUsuario = new() { Username = correoUsuario};
                DTOCliente clienteConsultado = ServicioValidacionUsuarios.ConsultaInformacionCliente(dTOUsuario);
                result.Value = clienteConsultado;
                result.StatusCode = 200;
            }
            catch(DTOBusinessException  ex)
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
        /// <summary>
        /// Peticion Get para consultar la informacion del cliente por IdUsuario
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/ConsultaCliente")]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(InternalExpcetionMessage))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DTOCliente))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError,Type = typeof(CriticalException))]
        public ObjectResult ConsultaCliente(Guid idUsuario)
        {
            if (idUsuario == Guid.Empty) throw new ArgumentNullException("No se puede usar valor en 0");
            ObjectResult result = new(true);
            try
            {
                DTOCliente cliente = new() { IdCliente = idUsuario};
                DTOCliente clienteConsultado = ServicioValidacionUsuarios.ConsultaInformacionCliente(cliente);
                result.Value = clienteConsultado;
                result.StatusCode = 200;
            }
            catch(DTOBusinessException  ex)
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
        ///<Summary></Summary>
        [HttpPost]
        [Route("/CrearUsuarioCliente")]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(InternalExpcetionMessage))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError,Type =typeof(CriticalException))]
        public ObjectResult CrearUsuarioCliente(ModeloRegistrarCliente modeloRegistrarCliente)
        {
           
            ObjectResult result = new(true);
            try
            {
                DTORegistroDeCliente dtoRegistro = mapper.Map<DTORegistroDeCliente>(modeloRegistrarCliente);                
                ServicioValidacionUsuarios.CrearUsuarioCliente(dtoRegistro);
                result.StatusCode = 200;
                result.Value = true;
                
            }
            catch(DTOBusinessException  ex)
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
