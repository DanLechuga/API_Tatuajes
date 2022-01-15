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
    public class ServicioNotificaciones : IServicioNotificaciones
    {
        public IRepositorioNotificaciones RepositorioNotificaciones { get; }
        public IRepositorioUsuario RepositorioUsuario { get; set; }
        public ServicioNotificaciones(IRepositorioNotificaciones repositorioNotificaciones, IRepositorioUsuario repositorioUsuario)
        {
            this.RepositorioNotificaciones = repositorioNotificaciones;
            this.RepositorioUsuario = repositorioUsuario;
        }
        public void CrearNotificacionRecuperacionPassword(DTOUsuario dTOUsuario)
        {
            if (dTOUsuario == null) throw new ArgumentNullException("No se puede usar valores nulos");
            if (dTOUsuario.IdUsaurio == Guid.Empty) throw new ArgumentNullException("No se puede usar valor vacio");
            Usuario usuario = RepositorioUsuario.GetUsuarioCliente(dTOUsuario.IdUsaurio);
            if (usuario == null) throw new ArgumentNullException("No se encontro usuario para el id ingresado");
            RepositorioNotificaciones.EnviarCorreoNotificacion(usuario);
            
        }
    }
}
