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

namespace API_Tatuajes.Controllers.citas
{
    ///<Summary>Control de Citas</Summary>
    [Route("[controller]")]
    [ApiController]    
    public class CitasController : ControllerBase
    {
        ///<Summary>Propiedad del servicio de citas solo lectura</Summary>
        public IServicioDeCitas ServicioDeCitas { get; set; }
        ///<Summary>Propiedad del servicio de errores solo lectura</Summary>
        public IServicioError ServicioError { get; set; }
        /// <summary>
        /// Propiedad del mapper
        /// </summary>
        public IMapper mapper { get; set; }
        ///<Summary>Contructor de la clase</Summary>
        public CitasController(IServicioDeCitas servicioCitas, IServicioError servicioError, IMapper _mapper)
        {
            this.ServicioDeCitas = servicioCitas;
            this.ServicioError = servicioError;
            this.mapper = _mapper;
        }
        ///<Summary>Consulta una lista de citas por el id del usuario</Summary>
        [HttpGet]
        [Route("/ConsultaDeCitas")]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(InternalExpcetionMessage))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DTOCitas>))]
        public ObjectResult ConsultaDeCitas(Guid idUsuario)
        {
            
            ObjectResult result = new(true);
            try
            {
                if (idUsuario == Guid.Empty) throw new ArgumentNullException("No se puede utilizar un id con valor en 0");
                DTOUsuario dtoUsuario = new() { IdUsaurio = idUsuario };
                IEnumerable<DTOCitas> ListaCitasPorUsuario = ServicioDeCitas.ConsultarCitas(dtoUsuario);
                result.Value = ListaCitasPorUsuario;
                result.StatusCode = 200;
            }
            catch (Exception ex)
            {

                string response = ServicioError.RegistrarError(new DTOException() { Exception = ex });
                result = Conflict(new InternalExpcetionMessage() { Id = ex.Source, Message = ex.Message, IdDataBase = response });
            }
            
            return result;
        }
        ///<Summary>Consulta una cita por el id ingresado</Summary>
        [HttpGet]
        [Route("/ConsultaCitaPorId")]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(InternalExpcetionMessage))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DTOCitas))]
        public ObjectResult ConsultaCitaPorId(Guid idCita)
        {
            
            ObjectResult result = new(true);             
            try
            {
                if (idCita == Guid.Empty) throw new ArgumentNullException("No se puede utilizar con un id en 0");
                result.StatusCode = 200;
                result.Value = ServicioDeCitas.ConsultarCita(new DTOCitas() { IdCita = idCita });

            }
            catch (Exception ex)
            {string response = ServicioError.RegistrarError(new DTOException() { Exception = ex });
                result = Conflict(new InternalExpcetionMessage() { Id = ex.Source, Message = ex.Message, IdDataBase = response });
            }
            return result;
        }
        ///<Summary>Crea una cita</Summary>
        [HttpPost]
        [Route("/CrearCita")]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(InternalExpcetionMessage))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ObjectResult CrearCita(ModeloCrearCita modeloCrearCita)
        {
            if (modeloCrearCita == null) throw new ArgumentNullException("No se puede realizar la peticion por falta de argumentos vacios o nulos");
            ObjectResult result = new(true);
            try
            {
                DTOCitas dtoCita = mapper.Map<DTOCitas>(modeloCrearCita);
                ServicioDeCitas.CrearCita(dtoCita);
                result.StatusCode = 200;
                result.Value = true;
            }
            catch (Exception ex)
            {string response = ServicioError.RegistrarError(new DTOException() { Exception = ex });
                result = Conflict(new InternalExpcetionMessage() { Id = ex.Source, Message = ex.Message, IdDataBase = response });
            }
            return result;
        }
        ///<Summary>Consulta los ids para editar las citas</Summary>
        [HttpGet]
        [Route("/EditarCitaVista")]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(InternalExpcetionMessage))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Guid>))]
        public ObjectResult EditarCitaVista(Guid idCliente)
        {
            if (idCliente == Guid.Empty) throw new ArgumentNullException("No se puede utilizar un id con valor en 0");
            ObjectResult result = new(true);
            try
            {
                DTOUsuario dtoUsuario = new(){ IdUsaurio = idCliente };
                IEnumerable<Guid> ListaCitasPorUsuario = ServicioDeCitas.ConsultasIds(dtoUsuario);
                result.Value = ListaCitasPorUsuario;
                result.StatusCode = 200;
            }
            catch (Exception ex)
            {string response = ServicioError.RegistrarError(new DTOException() { Exception = ex });
                result = Conflict(new InternalExpcetionMessage() { Id = ex.Source, Message = ex.Message, IdDataBase = response });
            }

            return result;
        }
        ///<Summary>Editar Cita</Summary>
        [HttpPatch]
        [Route("/EditarCita")]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(InternalExpcetionMessage))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ObjectResult EditarCita(ModeloActualizarCita modelo)
        {
            
            ObjectResult result = new(true);
            try
            {
                DTOCitas dtoCita = mapper.Map<DTOCitas>(modelo);
                ServicioDeCitas.ActualizarCita(dtoCita);
                result.StatusCode = 200;
            }
            catch (Exception ex)
            {string response = ServicioError.RegistrarError(new DTOException() { Exception = ex });
                result = Conflict(new InternalExpcetionMessage() { Id = ex.Source, Message = ex.Message, IdDataBase = response });
            }

            return result;
        }

    }
}
