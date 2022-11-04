using API_Aplicacion.DTOs;
using API_Aplicacion.Interfaces;
using API_Tatuajes.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Tatuajes.Controllers.usuarios
{
    ///<Summary></Summary>
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        ///<Summary></Summary>
        public IServicioValidacionUsuarios ServicioValidacionUsuarios { get; }
        ///<Summary></Summary>
        public IServicioError ServicioError { get; }
        ///<Summary></Summary>
        public UsuarioController(IServicioValidacionUsuarios servicioValidacionUsuarios,IServicioError servicioError)
        {
            this.ServicioValidacionUsuarios = servicioValidacionUsuarios;
            this.ServicioError = servicioError;
        }
        /// <summary>
        /// Peticion Post para validar el usuario y password que se ingresan
        /// </summary>
        /// <param name="modeloUsuario"></param>
        /// <returns></returns>
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
                ServicioError.RegistrarError(new DTOException() { Exception = ex});
            }
            return result;
        }
        /// <summary>
        /// Peticion Get para consultar la informacion del cliente por correo o email
        /// </summary>
        /// <param name="correoUsuario"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/ConsultaInfoCliente")]
        public JsonResult ConsultaInfoCliente(string correoUsuario)
        {
            if (string.IsNullOrEmpty(correoUsuario)) throw new ArgumentNullException("No se puede utlizar valores vacios o nulos");
            JsonResult result = new(true);
            result.StatusCode = 403;
            try
            {
                DTOUsuario dTOUsuario = new(correoUsuario, "");
                DTOCliente clienteConsultado = ServicioValidacionUsuarios.ConsultaInformacionCliente(dTOUsuario);
                result.Value = clienteConsultado;
                result.StatusCode = 200;
            }
            catch (Exception ex)
            {
                result.Value = ex.Message;
                result.StatusCode = 500;
                ServicioError.RegistrarError(new DTOException() { Exception = ex });
            }
            return result;

        }
        /// <summary>
        /// Peticion Get para consultar la informacion del cliente por IdUsuario
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/ConsultaCliente")]
        public JsonResult ConsultaCliente(Guid idUsuario)
        {
            if (idUsuario == Guid.Empty) throw new ArgumentNullException("No se puede usar valor en 0");
            JsonResult result = new(true);
            try
            {
                DTOCliente cliente = new() { IdCliente = idUsuario};
                DTOCliente clienteConsultado = ServicioValidacionUsuarios.ConsultaInformacionCliente(cliente);
                result.Value = clienteConsultado;
                result.StatusCode = 200;
            }
            catch (Exception ex)
            {
                result.Value = ex.Message;
                result.StatusCode = 500;
                ServicioError.RegistrarError(new DTOException() { Exception = ex });
            }
            return result;
        }
        ///<Summary></Summary>
        [HttpPost]
        [Route("/CrearUsuarioCliente")]
        public JsonResult CrearUsuarioCliente(ModeloRegistrarCliente modeloRegistrarCliente)
        {
            if (modeloRegistrarCliente == null) throw new ArgumentNullException("No se puede utilizar valores nulos");
            JsonResult result = new(true);
            try
            {
                DTORegistroDeCliente dTORegistroDeCliente = new() {NombreCliente = modeloRegistrarCliente.nombreDeCliente,CorreoElectronico = modeloRegistrarCliente.correoElectronico, Password = modeloRegistrarCliente.password, NumeroTelefonico = modeloRegistrarCliente.numeroTelefonico };
                ServicioValidacionUsuarios.CrearUsuarioCliente(dTORegistroDeCliente);
                result.StatusCode = 200;
                result.Value = true;
                
            }
            catch (Exception ex)
            {
                result.StatusCode = 500;
                result.Value = ex.Message;
                ServicioError.RegistrarError(new DTOException() { Exception = ex});
            }
            return result;
        }
    }
}
