using API_Aplicacion.DTOs;
using API_Aplicacion.Interfaces;
using API_Tatuajes.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Tatuajes.Controllers.catalogo
{
    ///<Summary></Summary>
    [Route("[controller]")]
    [ApiController]
    public class CatalogoDeTatuajesController : ControllerBase
    {
        ///<Summary></Summary>
        public IServicioError ServicioError { get; }
        ///<Summary></Summary>
        public IServicioCatalogoDeTatuajes ServicioCatalogoDeTatuajes { get; }

        ///<Summary></Summary>
        public CatalogoDeTatuajesController(IServicioCatalogoDeTatuajes servicioCatalogoDeTatuajes, IServicioError servicioError)
        {
            ServicioCatalogoDeTatuajes = servicioCatalogoDeTatuajes;
            ServicioError = servicioError;
        }
        ///<Summary></Summary>
        [HttpGet]
        [Route("/ConsultarCatalogoTatuajes")]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(InternalExpcetionMessage))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DTOCatalogoTatuajes>))]
        public ObjectResult ConsultarCatalogoTatuajes()
        {
            ObjectResult result = new(true);
            try
            {
                IEnumerable<DTOCatalogoTatuajes> catalogoTatuajes = ServicioCatalogoDeTatuajes.ConsultarCatalogoDeTatuajes();
                result.Value = catalogoTatuajes;
                result.StatusCode = 200;
            }
            catch (Exception ex)
            {

                string response = ServicioError.RegistrarError(new DTOException() { Exception = ex });
                result = Conflict(new InternalExpcetionMessage() { Id = ex.Source, Message = ex.Message, IdDataBase = response });
            }
            return result;
        }
        ///<Summary></Summary>
        [HttpGet]
        [Route("/ConsultarDetalleTatuaje")]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(InternalExpcetionMessage))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DTODetalleTatuaje))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CriticalException))]
        public ObjectResult ConsultarDetalleTatuaje(int idTatuaje)
        {
            ObjectResult result = new(true);
            try
            {
                DTODetalleTatuaje dTODetalle = ServicioCatalogoDeTatuajes.ConsultarDetalleTatuaje(idTatuaje);
                result.Value = dTODetalle;
                result.StatusCode = 200;
            }
            catch (DTOBusinessException capex)
            {
                string response = ServicioError.RegistrarError(new DTOException() { Exception = capex });
                result = Conflict(new InternalExpcetionMessage() { Id = capex.Source, Message = capex.Message, IdDataBase = response });
            }
            catch (Exception ex)
            {
                string response = ServicioError.RegistrarError(new DTOException() { Exception = ex });
                result = StatusCode(StatusCodes.Status500InternalServerError, new CriticalException { Origin = ex.Source, Messages = new[] { ex.Message }, TrakingCode = response });
            }
            return result;
        }
        ///<Summary></Summary>
        [HttpGet]
        [Route("/ConsultarDetalleTatuajePorIdCita")]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(InternalExpcetionMessage))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DTODetalleTatuaje))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CriticalException))]
        public ObjectResult ConsultarDetalleTatuajePorIdCita(Guid idCita)
        {
            ObjectResult result = new(true);

            try
            {
                DTODetalleTatuaje dTODetalle = ServicioCatalogoDeTatuajes.ConsultarDetalleTatuajePorIdCita(idCita);
                result.Value = dTODetalle;
                result.StatusCode = 200;
            }
            catch (DTOBusinessException capex)
            {
                string response = ServicioError.RegistrarError(new DTOException() { Exception = capex });
                result = Conflict(new InternalExpcetionMessage() { Id = capex.Source, Message = capex.Message, IdDataBase = response });
            }
            catch (Exception ex)
            {
                string response = ServicioError.RegistrarError(new DTOException() { Exception = ex });
                result = StatusCode(StatusCodes.Status500InternalServerError, new CriticalException { Origin = ex.Source, Messages = new[] { ex.Message }, TrakingCode = response });
            }
            return result;
        }
    }
}
