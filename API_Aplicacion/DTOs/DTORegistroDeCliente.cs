using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Aplicacion.DTOs
{
    public class DTORegistroDeCliente
    {
        public string NombreCliente { get; set; }
        public string CorreoElectronico { get; set; }
        public string Password { get; set; }
        public string NumeroTelefonico { get; set; }
    }
}
