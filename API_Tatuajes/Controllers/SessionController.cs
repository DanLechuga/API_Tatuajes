using API_Tatuajes.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Tatuajes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        public SessionController()
        {

        }

        [Route("/CrearSession")]
        [HttpPost]
        public JsonResult CrearSession(ModeloSession modeloSession)
        {
            return null;
        }
    }
}
