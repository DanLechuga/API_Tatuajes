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
        public IRepositorioCliente RepositorioCliente { get; }
        public ServicioValidacionUsuarios(IRepositorioUsuario repositorioUsuario, IRepositorioCliente repositorioCliente)
        {
            this.RepositorioUsuario = repositorioUsuario;
            this.RepositorioCliente = repositorioCliente;
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

        public DTOCliente ConsultaInformacionCliente(DTOUsuario usuario)
        {
            if (usuario == null) throw new ArgumentNullException("No se puede usar valores nulos");
            if (string.IsNullOrEmpty(usuario.Username)) throw new ArgumentNullException("No se pueden usar valores vacios");
            Cliente clienteConsultado = this.RepositorioCliente.GetClintePorCorreo(usuario.Username);
            if (clienteConsultado == null) throw new ArgumentNullException("No se encontro usuario para el correo ingresado");
            DTOCliente dTOCliente = new() {
                IdCliente = clienteConsultado.Id,
                CorreoCliente = clienteConsultado.Cliente_correo.Cadenavalida,
                PasswordCliente = clienteConsultado.Password.ContraseniaValida,
                NombreCliente = clienteConsultado.Cliente_nombre,
                NumeroTelefonico = clienteConsultado.Cliente_numeroTel
            };
            return dTOCliente;
        }
    }
}
