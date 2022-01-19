using API_Aplicacion.DTOs;
using API_Aplicacion.Interfaces;
using API_Tatuajes.Modelos;
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
    public class CitasController : ControllerBase
    {
        public IServicioDeCitas ServicioDeCitas { get; set; }
        public IServicioError ServicioError { get; set; }
        public CitasController(IServicioDeCitas servicioCitas, IServicioError servicioError)
        {
            this.ServicioDeCitas = servicioCitas;
            this.ServicioError = servicioError;
        }
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
    }
}
