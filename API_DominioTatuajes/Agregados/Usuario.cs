using API_Comun;
using API_DominioTatuajes.ObjetosDeValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_DominioTatuajes.Agregados
{
   public class Usuario : Agregado
    {
        //
        public CorreoElectronico UsuarioCorreo { get; set; }
        public Password UsuarioPassword { get; set; }
        public bool UsuarioEsCliente { get; set; }
        public bool UsuarioEsTatuador { get; set; }
        public bool UsuarioEsCreadorContenido { get; set; }
        private Usuario(Guid usuarioId, CorreoElectronico usuarioCorreo, Password usuarioPassword, bool usuarioEsCliente, bool usuarioEsTatuador,bool usuarioEsCreadorContenido)
        {
            this.Id = usuarioId;
            this.UsuarioCorreo = usuarioCorreo ?? throw new ArgumentNullException("No se puede utilizar valores nulos");
            this.UsuarioPassword = usuarioPassword ?? throw new ArgumentNullException("No se puede utilizar valores nulos");
            this.UsuarioEsCliente = usuarioEsCliente;
            this.UsuarioEsTatuador = usuarioEsTatuador;
            this.UsuarioEsCreadorContenido = usuarioEsCreadorContenido;
        }
        private static Usuario Crear(Guid usuarioId, CorreoElectronico usuarioCorreo, Password usuarioPassword, bool usuarioEsCliente, bool usuarioEsTatuador,bool usuarioEsCreadorContenido)
        {
            return new Usuario(usuarioId,usuarioCorreo,usuarioPassword,usuarioEsCliente,usuarioEsTatuador,usuarioEsCreadorContenido);
        }

        public static Usuario CrearUsuarioCliente(Guid usuarioId, CorreoElectronico usuarioCorreo, Password usuarioPassword)
        {
          return  Crear(usuarioId, usuarioCorreo, usuarioPassword, true, false,false);
        }
        public static Usuario CrearUsuarioTatuador(Guid usuarioId, CorreoElectronico usuarioCorreo, Password usuarioPassword)
        {
            return Crear(usuarioId,usuarioCorreo,usuarioPassword,false,true,false);
        }
        public static Usuario CrearUsuarioCreadorContenido(Guid usuarioId, CorreoElectronico usuarioCorreo, Password usuarioPassword)
        {
            return Crear(usuarioId, usuarioCorreo, usuarioPassword, false, false, true);
        }
        
            
    } 
}
