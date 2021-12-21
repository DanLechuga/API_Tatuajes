using API_Aplicacion.DTOs;
using API_Aplicacion.Interfaces;
using API_DominioTatuajes.Agregados;
using API_Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Aplicacion.Implementacion
{
    public class ServicioValidacionUsuarios : IServicioValidacionUsuarios
    {
        public IRepositorioUsuario RepositorioUsuario { get; }
        public ServicioValidacionUsuarios(IRepositorioUsuario repositorioUsuario)
        {
            this.RepositorioUsuario = repositorioUsuario;
        }
        public DTOUsuario ValidacionUsuario(DTOUsuario usuario)
        {
            if (usuario == null) throw new ArgumentNullException("No se puede usar objetos nulos");
            if (string.IsNullOrEmpty(usuario.Username)) throw new ArgumentNullException("No se puede usar valores vacios");
            if (string.IsNullOrEmpty(usuario.Password)) throw new ArgumentNullException("No se puede usar valores vacios");
            Usuario usuarioDeBase = RepositorioUsuario.GetUsuarioPorCorreo(usuario.Username);
            if (usuarioDeBase == null) throw new ArgumentNullException("Usuario no encontrado para el correo ingresado");
            if (usuarioDeBase.UsuarioPassword.ContraseniaValida != usuario.Password) throw new Exception("Contraseña ingresa no coincide con el usuario ingresado");
            DTOUsuario UsuarioConsultado = new(usuarioDeBase.UsuarioCorreo.Cadenavalida, usuarioDeBase.UsuarioPassword.ContraseniaValida) { EsCliente = usuarioDeBase.UsuarioEsCliente, Estatuador = usuarioDeBase.UsuarioEsTatuador, EsUsuarioValido = true};
            
            return UsuarioConsultado;
        }
    }
}
