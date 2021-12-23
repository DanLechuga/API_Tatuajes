using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Aplicacion.DTOs
{
   public class DTOCliente
    {
        public Guid IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string CorreoCliente { get; set; }
        public string NumeroTelefonico { get; set; }
        public string PasswordCliente { get; set; }
    }
}
