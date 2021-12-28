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
    [ApiController]
    [Route("[controller]")]    
    public class SessionController : ControllerBase
    {
        public IServicioSession ServicioSession { get; }
        public SessionController(IServicioSession servicioSession)
        {
            this.ServicioSession = servicioSession;
        }

        [HttpPost]
        [Route("/VerificaSession")]        
        public JsonResult CrearSession(ModeloSession modeloSession)
        {
            if (modeloSession ==    null) throw new ArgumentNullException("No se puede usar valores nulos");
            if (modeloSession.idSession == Guid.Empty) throw new ArgumentNullException("No se puede usar valores en 0");
            if (modeloSession.idSessionUsuario == Guid.Empty) throw new ArgumentNullException("No se puede usar valores en 0");
            JsonResult result = new(true);
            result.StatusCode = 403;
            try
            {
                DTOSession DtoSession = new() { IdSession = modeloSession.idSession,IdSessionUsuario = modeloSession.idSessionUsuario, IdSessionCliente = modeloSession.idSessionCliente, IdSessionTatuador = modeloSession.idSessionTatuador, SessionActiva = modeloSession.sessionActiva};
                ServicioSession.CrearSession(DtoSession);
                result.StatusCode = 200;
                result.Value = true;
                
            }
            catch (Exception ex)
            {
                result.StatusCode = 500;
                result.Value = ex.Message;
                
            }
            return result;
        }
        [HttpGet]
        [Route("/ConsultaSession")]
        public JsonResult ConsultaSession(Guid idCliente)
        {
            if (idCliente == Guid.Empty) throw new ArgumentNullException("No se puede utilizar id en 0");
            JsonResult result = new(true);
            result.StatusCode = 403;
            try
            {
                 DTOSession sessionConsultada = ServicioSession.ConsultaSessionCliente(new DTOCliente() { IdCliente = idCliente});                
                result.StatusCode = 200;
                result.Value = sessionConsultada;
            }
            catch (Exception ex)
            {

                result.StatusCode = 500;
                result.Value = ex.Message;
            }
            return result;
        }
        
    }
}
