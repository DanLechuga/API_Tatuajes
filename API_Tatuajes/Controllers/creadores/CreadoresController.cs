using API_Aplicacion.DTOs;
using API_Aplicacion.Interfaces;
using API_Tatuajes.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Tatuajes.Controllers.creadores
{
   /// <summary>
   /// 
   /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class CreadoresController : ControllerBase
    {
        ///<Summary>Propiedad del servicio de errores solo lectura</Summary>
        public IServicioError ServicioError { get; }
        ///<Summary>Propiedad del servicio de validacion de creadores solo lectura</Summary>
        public IServicioValidacionCreadores ServicioValidacionCreadores { get;  }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="servicioError"></param>
        /// <param name="servicioValidacionCreadores"></param>
        public CreadoresController(IServicioValidacionCreadores servicioValidacionCreadores,IServicioError servicioError)
        {
            this.ServicioError = servicioError;
            this.ServicioValidacionCreadores = servicioValidacionCreadores;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/ConsultarInfoCreador")]
        [ProducesResponseType(409, Type = typeof(InternalExpcetionMessage))]
        [ProducesResponseType(200, Type = typeof(DTOCreador))]
        public ObjectResult ConsultarInfoTatuador(string correoCreador)
        {
            if (string.IsNullOrEmpty(correoCreador)) throw new ArgumentNullException("No se puede utlizar valores vacios o nulos");
            ObjectResult result = new(true);
            result.StatusCode = 403;
            try
            {
                DTOCreador dTOCreador = new() { CorreoCreador = correoCreador };
                DTOCreador CreadorConsultado = ServicioValidacionCreadores.ConsultarInfoCreador(dTOCreador);
                result.Value = CreadorConsultado;
                result.StatusCode = 200;
            }
            catch (Exception ex)
            {
                result = Conflict(new InternalExpcetionMessage() { Id = ex.Source, Message = ex.Message });
                ServicioError.RegistrarError(new DTOException() { Exception = ex });
            }
            return result;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idCreador"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/ConsultarCreador")]
        [ProducesResponseType(409, Type = typeof(InternalExpcetionMessage))]
        [ProducesResponseType(200, Type = typeof(DTOCreador))]
        public ObjectResult ConsultarCreador(Guid idCreador)
        {
            
            ObjectResult result = new(true);
            result.StatusCode = 403;
            try
            {
                DTOCreador dTOCreador = new() { IdCreador = idCreador };
                DTOCreador CreadorConsultado = ServicioValidacionCreadores.ConsultarInfoCreador(dTOCreador);
                result.Value = CreadorConsultado;
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
