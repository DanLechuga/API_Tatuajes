using API_Comun;
using API_DominioTatuajes.ObjetosDeValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_DominioTatuajes.Agregados
{
   public class Cliente : Agregado
    {        
        public string Cliente_nombre { get; set; }
        public CorreoElectronico Cliente_correo { get; set; }
        public string Cliente_numeroTel { get; set; }
        public Password Password { get; set; }

        private Cliente(Guid idCliente,string nombreCliente,CorreoElectronico emailCliente,Password contraseniaCliente,string numeroTelCliente)
        {
            this.Id = idCliente;
            this.Cliente_nombre = nombreCliente;
            this.Cliente_correo = emailCliente ?? throw new ArgumentNullException("No se puede utilizar correo nulo");
            this.Password = contraseniaCliente ?? throw new ArgumentNullException("No se puede utilizar correo nulo");
            this.Cliente_numeroTel = numeroTelCliente;
        }
        public static Cliente Crear(Guid idCliente, string nombreCliente, CorreoElectronico emailCliente, Password contraseniaCliente, string numeroTelCliente)
        {
            return new Cliente(idCliente,nombreCliente,emailCliente,contraseniaCliente,numeroTelCliente);
        }
    }
}
