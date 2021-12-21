﻿using API_Aplicacion.DTOs;
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
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public IServicioValidacionUsuarios ServicioValidacionUsuarios { get; }
        public UsuarioController(IServicioValidacionUsuarios servicioValidacionUsuarios)
        {
            this.ServicioValidacionUsuarios = servicioValidacionUsuarios;
        }

        [HttpPost]
        [Route("/ValidarUsuario")]
        public JsonResult ValidarUsuario(ModeloUsuario modeloUsuario)
        {
            if (modeloUsuario == null) throw new ArgumentNullException("No se puede usar valores nulos");
            if (string.IsNullOrEmpty(modeloUsuario.Username)) throw new ArgumentNullException("No se puede usar valores vacios");
            if(string.IsNullOrEmpty(modeloUsuario.Password)) throw new ArgumentNullException("No se puede usar valores vacios");
            JsonResult result = new(true);
            result.StatusCode = 403;
            try
            {
                DTOUsuario dTOUsuario = new(modeloUsuario.Username,modeloUsuario.Password);
              DTOUsuario dtoUsuarioConsultado = ServicioValidacionUsuarios.ValidacionUsuario(dTOUsuario);
                result.StatusCode = 200;
                result.Value = dtoUsuarioConsultado; 
            }
            catch (Exception ex)
            {
                result.Value = ex.Message;
                result.StatusCode = 500;
            }
            return result;
        }
    }
}
