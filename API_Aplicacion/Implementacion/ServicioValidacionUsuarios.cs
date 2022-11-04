using API_Aplicacion.DTOs;
using API_Aplicacion.Interfaces;
using API_DominioTatuajes.Agregados;
using API_DominioTatuajes.ObjetosDeValor;
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
        /// <summary>
        /// Revisa si es un usuario ingresado en la base de datos
        /// </summary>
        /// <param name="usuario">Username,Password</param>
        /// <returns></returns>
        public DTOUsuario ValidacionUsuario(DTOUsuario usuario)
        {
            if (usuario == null) throw new ArgumentNullException("No se puede usar objetos nulos");
            if (string.IsNullOrEmpty(usuario.Username)) throw new ArgumentNullException("No se puede usar valores vacios");
            if (string.IsNullOrEmpty(usuario.Password)) throw new ArgumentNullException("No se puede usar valores vacios");
            Usuario usuarioDeBase = RepositorioUsuario.GetUsuarioPorCorreo(usuario.Username);
            if (usuarioDeBase == null) throw new ArgumentNullException($"Usuario no encontrado para el correo ingresado {usuario.Username}");
            if (usuarioDeBase.UsuarioPassword.ContraseniaValida != usuario.Password) throw new Exception($"Contraseña ingresa no coincide con el usuario ingresado {usuario.Username}");
            DTOUsuario UsuarioConsultado = new(usuarioDeBase.UsuarioCorreo.Cadenavalida, usuarioDeBase.UsuarioPassword.ContraseniaValida) { EsCliente = usuarioDeBase.UsuarioEsCliente, Estatuador = usuarioDeBase.UsuarioEsTatuador, EsUsuarioValido = true};
            
            return UsuarioConsultado;
        }
        /// <summary>
        /// Consulta la informacion de un cliente mediante su correo electronico
        /// </summary>
        /// <param name="usuario">Username</param>
        /// <returns></returns>
        public DTOCliente ConsultaInformacionCliente(DTOUsuario usuario)
        {
            if (usuario == null) throw new ArgumentNullException("No se puede usar valores nulos");
            if (string.IsNullOrEmpty(usuario.Username)) throw new ArgumentNullException("No se pueden usar valores vacios");
            Cliente clienteConsultado = this.RepositorioCliente.GetClintePorCorreo(usuario.Username);
            if (clienteConsultado == null) throw new ArgumentNullException($"No se encontro usuario para el correo ingresado {usuario.Username}");
            return  new DTOCliente() {
                IdCliente = clienteConsultado.Id,
                CorreoCliente = clienteConsultado.Cliente_correo.Cadenavalida,
                PasswordCliente = clienteConsultado.Password.ContraseniaValida,
                NombreCliente = clienteConsultado.Cliente_nombre,
                NumeroTelefonico = clienteConsultado.Cliente_numeroTel
            };
            
        }
        /// <summary>
        /// Consulta la informacion de un cliente registrado en base por el id ingresado
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public DTOCliente ConsultaInformacionCliente(DTOCliente cliente)
        {
            if (cliente == null) throw new ArgumentNullException("No se pueden usar valores vacios");
            if (cliente.IdCliente == Guid.Empty) throw new ArgumentNullException("No se pueden usar valores en 0");
            Cliente clienteConsultado = RepositorioCliente.GetClientePorId(cliente.IdCliente);
            if (clienteConsultado == null) throw new ArgumentNullException($"No se encontro cliente para el id ingresado {cliente.IdCliente}");
            return new DTOCliente() { 
            IdCliente = clienteConsultado.Id,
            CorreoCliente = clienteConsultado.Cliente_correo.Cadenavalida,
            NombreCliente = clienteConsultado.Cliente_nombre,
            NumeroTelefonico = clienteConsultado.Cliente_numeroTel,
            PasswordCliente = clienteConsultado.Password.ContraseniaValida
            };
            
        }

        public void CrearUsuarioCliente(DTORegistroDeCliente dTORegistroDeCliente)
        {
            if (dTORegistroDeCliente == null) throw new ArgumentNullException("No se puede utilizar valores nulos para crear solicitud");
            Usuario usuario = Usuario.CrearUsuarioCliente(Guid.NewGuid(), CorreoElectronico.Crear(dTORegistroDeCliente.CorreoElectronico), Password.Crear(dTORegistroDeCliente.Password));
            Cliente cliente = Cliente.Crear(usuario.Id,dTORegistroDeCliente.NombreCliente,CorreoElectronico.Crear(dTORegistroDeCliente.CorreoElectronico),Password.Crear(dTORegistroDeCliente.Password),dTORegistroDeCliente.NumeroTelefonico);
            RepositorioUsuario.Agregar(usuario);
            RepositorioCliente.Agregar(cliente);
            
        }
    }
}
