using API_Aplicacion.DTOs;
using API_Aplicacion.Interfaces;
using API_Tatuajes.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Tatuajes.Controllers.tatuador
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    
    public class TatuadorController : ControllerBase
    {
        ///<Summary></Summary>
        public IServicioValidacionTatuador ServicioValidacionTatuador { get; }
        ///<Summary></Summary>
        public IServicioError ServicioError { get; }
        /// <summary>
        /// 
        /// </summary>
        public TatuadorController(IServicioValidacionTatuador servicioValidacionTatuador,IServicioError servicioError)
        {
            this.ServicioValidacionTatuador = servicioValidacionTatuador;
            this.ServicioError = servicioError;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/ConsultarInfoTatuador")]
        [ProducesResponseType(409, Type = typeof(InternalExpcetionMessage))]
        [ProducesResponseType(200, Type = typeof(DTOTatuador))]
       public ObjectResult ConsultarInfoTatuador(string correoTatuador)
        {
            if (string.IsNullOrEmpty(correoTatuador)) throw new ArgumentNullException("No se puede utlizar valores vacios o nulos");
            ObjectResult result = new(true);
            result.StatusCode = 403;
            try
                {
                DTOTatuador dTOTatuador = new() { correoTauador = correoTatuador};
                DTOTatuador tatuadorConsultado = ServicioValidacionTatuador.ConsultarInfoTatuador(dTOTatuador);
                result.Value = tatuadorConsultado;
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
        /// <param name="idTatuador"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/ConsultarTatuador")]
        [ProducesResponseType(409, Type = typeof(InternalExpcetionMessage))]
        [ProducesResponseType(200, Type = typeof(DTOTatuador))]
        public ObjectResult ConsultarTatuador(Guid idTatuador)
        {
            if (Guid.Empty == idTatuador) throw new ArgumentNullException("No se puede utlizar valores vacios o nulos");
            ObjectResult result = new(true);
            result.StatusCode = 403;
            try
            {
                DTOTatuador dTOTatuador = new() { idTatuador = idTatuador };
                DTOTatuador tatuadorConsultado = ServicioValidacionTatuador.ConsultarInfoTatuador(dTOTatuador);
                result.Value = tatuadorConsultado;
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
        /// <param name="idTatuador"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/ConsultaDeCitasTatuador")]
        [ProducesResponseType(409, Type = typeof(InternalExpcetionMessage))]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DTOCitasTatuador>))]
        public ObjectResult ConsultaDeCitasTatuador(Guid idTatuador)
        {
            if (Guid.Empty == idTatuador) throw new ArgumentNullException("No se puede utlizar valores vacios o nulos");
            ObjectResult result = new(true);
            result.StatusCode = 403;
            try
            {
                DTOTatuador dTOTatuador = new() { idTatuador = idTatuador };
                IEnumerable<DTOCitasTatuador> tatuadorConsultado = ServicioValidacionTatuador.ConsultarCitasPorTatuador(dTOTatuador);
                result.Value = tatuadorConsultado;
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
        /// <param name="idTatuador"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/DetalleCitaVista")]
        [ProducesResponseType(409, Type = typeof(InternalExpcetionMessage))]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Guid>))]
        public ObjectResult DetalleCitaVista(Guid idTatuador)
        {
            if (Guid.Empty == idTatuador) throw new ArgumentNullException("No se puede utlizar valores vacios o nulos");
            ObjectResult result = new(true);
            result.StatusCode = 403;
            try
            {
                DTOTatuador dTOTatuador = new() { idTatuador = idTatuador };
                IEnumerable<Guid> tatuadorConsultado = ServicioValidacionTatuador.ConsultarListaIdsCitas(dTOTatuador);
                result.Value = tatuadorConsultado;
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
        /// <param name="idTatuador"></param>
        /// <param name="idCita"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/DetalleCita")]
        [ProducesResponseType(409, Type = typeof(InternalExpcetionMessage))]
        [ProducesResponseType(200, Type = typeof(DTOCitasTatuador))]
        public ObjectResult DetalleCita(Guid idTatuador, Guid idCita)
        {
            if (Guid.Empty == idTatuador && Guid.Empty == idCita) throw new ArgumentNullException("No se puede utlizar valores vacios o nulos");
            ObjectResult result = new(true);
            result.StatusCode = 403;
            try
            {
                DTOTatuador dTOTatuador = new() { idTatuador = idTatuador };
                DTOCitasTatuador tatuadorConsultado = ServicioValidacionTatuador.ConsultarDetalleCita(dTOTatuador,idCita);
                result.Value = tatuadorConsultado;
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
