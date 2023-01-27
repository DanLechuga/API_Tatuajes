using API_Aplicacion.DTOs;
using API_Aplicacion.Interfaces;
using API_DominioTatuajes.Agregados;
using API_DominioTatuajes.ObjetosDeValor;
using API_Infraestructura.Interfaces;
using System;
using AutoMapper;

namespace API_Aplicacion.Implementacion
{
    public class ServicioValidacionUsuarios : IServicioValidacionUsuarios
    {
        public IRepositorioUsuario RepositorioUsuario { get; }
        public IRepositorioCliente RepositorioCliente { get; }
        public IMapper Mapper { get; }

        public ServicioValidacionUsuarios(IRepositorioUsuario repositorioUsuario, IRepositorioCliente repositorioCliente,IMapper mapper)
        {
            this.RepositorioUsuario = repositorioUsuario;
            this.RepositorioCliente = repositorioCliente;
            this.Mapper = mapper;
        }
        /// <summary>
        /// Revisa si es un usuario ingresado en la base de datos
        /// </summary>
        /// <param name="usuario">Username,Password</param>
        /// <returns></returns>
        public DTOUsuario ValidacionUsuario(DTOUsuario usuario)
        {
            if (usuario == null) throw new DTOBusinessException($"No se puede usar objetos nulos");
            if (string.IsNullOrEmpty(usuario.Username)) throw new DTOBusinessException($"No se puede usar valores vacios para el nombre de usuario");
            if (string.IsNullOrEmpty(usuario.Password)) throw new DTOBusinessException($"No se puede usar valores vacios para la constraseña");
            Usuario usuarioDeBase = RepositorioUsuario.GetUsuarioPorCorreo(usuario.Username);
            if (usuarioDeBase == null) throw new DTOBusinessException($"Usuario no encontrado para el correo ingresado {usuario.Username}");
            if (usuarioDeBase.UsuarioPassword.ContraseniaValida != usuario.Password) throw new DTOBusinessException($"Contraseña ingresada no coincide con el usuario ingresado {usuario.Username}");
            DTOUsuario UsuarioConsultado = Mapper.Map<DTOUsuario>(usuarioDeBase);                        
            return UsuarioConsultado;
        }
        /// <summary>
        /// Consulta la informacion de un cliente mediante su correo electronico
        /// </summary>
        /// <param name="usuario">Username</param>
        /// <returns></returns>
        public DTOCliente ConsultaInformacionCliente(DTOUsuario usuario)
        {
            if (usuario == null) throw new DTOBusinessException($"No se puede usar valores nulos");
            if (string.IsNullOrEmpty(usuario.Username)) throw new DTOBusinessException($"No se pueden usar valores vacios para el nombre de usuario");
            Cliente clienteConsultado = this.RepositorioCliente.GetClintePorCorreo(usuario.Username);
            if (clienteConsultado == null) throw new DTOBusinessException($"No se encontro usuario para el correo ingresado {usuario.Username}");
            DTOCliente ClienteConsultado = Mapper.Map<DTOCliente>(clienteConsultado);
            return ClienteConsultado;
            
        }
        /// <summary>
        /// Consulta la informacion de un cliente registrado en base por el id ingresado
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public DTOCliente ConsultaInformacionCliente(DTOCliente cliente)
        {
            if (cliente == null) throw new DTOBusinessException($"No se pueden usar valores vacios");
            if (cliente.IdCliente == Guid.Empty) throw new DTOBusinessException($"No se pueden usar valores en 0 para el identificador de cita");
            Cliente clienteConsultado = RepositorioCliente.GetClientePorId(cliente.IdCliente);
            if (clienteConsultado == null) throw new DTOBusinessException($"No se encontro cliente para el id ingresado {cliente.IdCliente}");
            DTOCliente ClienteConsultado = Mapper.Map<DTOCliente>(clienteConsultado);
            return ClienteConsultado;

        }

        public void CrearUsuarioCliente(DTORegistroDeCliente dTORegistroDeCliente)
        {
            if (dTORegistroDeCliente == null) throw new DTOBusinessException($"No se puede utilizar valores nulos para crear solicitud");
            Usuario usuario = Usuario.CrearUsuarioCliente(Guid.NewGuid(), CorreoElectronico.Crear(dTORegistroDeCliente.CorreoElectronico), Password.Crear(dTORegistroDeCliente.Password));
            Cliente cliente = Cliente.Crear(usuario.Id,dTORegistroDeCliente.NombreCliente,CorreoElectronico.Crear(dTORegistroDeCliente.CorreoElectronico),Password.Crear(dTORegistroDeCliente.Password),dTORegistroDeCliente.NumeroTelefonico);
            RepositorioUsuario.Agregar(usuario);
            RepositorioCliente.Agregar(cliente);
            
        }
    }
}
