using API_Aplicacion.DTOs;
using API_Aplicacion.Interfaces;
using API_Tatuajes.Modelos;
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
        ///<Summary>Contructor de la clase</Summary>
        public CitasController(IServicioDeCitas servicioCitas, IServicioError servicioError)
        {
            this.ServicioDeCitas = servicioCitas;
            this.ServicioError = servicioError;
        }
        ///<Summary>Consulta una lista de citas por el id del usuario</Summary>
        [HttpGet]
        [Route("/ConsultaDeCitas")]
        public JsonResult ConsultaDeCitas(Guid idUsuario)
        {
            if (idUsuario == Guid.Empty) throw new ArgumentNullException("No se puede utilizar un id con valor en 0");
            JsonResult result = new(true);
            try
            {
                DTOUsuario dtoUsuario = new("", "") { IdUsaurio = idUsuario };
                IEnumerable<DTOCitas> ListaCitasPorUsuario = ServicioDeCitas.ConsultarCitas(dtoUsuario);
                result.Value = ListaCitasPorUsuario;
                result.StatusCode = 200;
            }
            catch (Exception ex)
            {
                result.StatusCode = 500;
                result.Value = ex.Message;
                ServicioError.RegistrarError(new DTOException() { Exception = ex }) ;
            }
            
            return result;
        }
        ///<Summary>Consulta una cita por el id ingresado</Summary>
        [HttpGet]
        [Route("/ConsultaCitaPorId")]
        public JsonResult ConsultaCitaPorId(Guid idCita)
        {
            if (idCita == Guid.Empty) throw new ArgumentNullException("No se puede utilizar con un id en 0");
            JsonResult result = new(true);             
            try
            {
                
                result.StatusCode = 200;
                result.Value = ServicioDeCitas.ConsultarCita(new DTOCitas() { IdCita = idCita });

            }
            catch (Exception ex)
            {
                result.StatusCode = 500;
                result.Value = ex.Message;
                ServicioError.RegistrarError(new DTOException() { Exception = ex});
            }
            return result;
        }
        ///<Summary>Crea una cita</Summary>
        [HttpPost]
        [Route("/CrearCita")]
        public JsonResult CrearCita(ModeloCrearCita modeloCrearCita)
        {
            if (modeloCrearCita == null) throw new ArgumentNullException("No se puede realizar la peticion por falta de argumentos vacios o nulos");
            JsonResult result = new(true);
            try
            {
                ServicioDeCitas.CrearCita(new DTOCitas() { IdCita = Guid.NewGuid(), IdUsuario = modeloCrearCita.idUsuario, EsConAnticipo = modeloCrearCita.esAnticipo, CantidadDeposito = modeloCrearCita.montoAnticipo, FechaCreacion = modeloCrearCita.fechaCita, IdCatalogo = modeloCrearCita.listaDeTatuajes });
                result.StatusCode = 200;
                result.Value = true;
            }
            catch (Exception ex)
            {
                result.StatusCode = 500;
                result.Value = ex.Message;
                ServicioError.RegistrarError(new DTOException() { Exception = ex });
                
            }
            return result;
        }
        ///<Summary>Edita una cita</Summary>
        [HttpGet]
        [Route("/EditarCita")]
        public JsonResult EditarCita(Guid idCliente)
        {
            if (idCliente == Guid.Empty) throw new ArgumentNullException("No se puede utilizar un id con valor en 0");
            JsonResult result = new(true);
            try
            {
                DTOUsuario dtoUsuario = new("", "") { IdUsaurio = idCliente };
                IEnumerable<Guid> ListaCitasPorUsuario = ServicioDeCitas.ConsultasIds(dtoUsuario);
                result.Value = ListaCitasPorUsuario;
                result.StatusCode = 200;
            }
            catch (Exception ex)
            {
                result.StatusCode = 500;
                result.Value = ex.Message;
                ServicioError.RegistrarError(new DTOException() { Exception = ex });
            }

            return result;
        }
       
    }
}
