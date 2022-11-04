using API_Aplicacion.DTOs;
using API_Aplicacion.Interfaces;
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
        public IServicioError ServicioError { get;  }
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
        public JsonResult ConsultarCatalogoTatuajes()
        {
            JsonResult result = new(true);
            try
            {
                IEnumerable<DTOCatalogoTatuajes> catalogoTatuajes = ServicioCatalogoDeTatuajes.ConsultarCatalogoDeTatuajes();
                result.Value = catalogoTatuajes;                
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
