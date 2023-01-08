using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Aplicacion.DTOs
{
   public class DTOUsuario
    {
        public Guid IdUsaurio { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool EsUsuarioValido { get; set; }
        public bool EsTatuador { get; set; }
        public bool EsCliente { get; set; }
        public bool EsCreadorContenido { get; set; }
      
    }
}
