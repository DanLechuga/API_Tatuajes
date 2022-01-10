using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Tatuajes.Modelos
{
    public class ModeloRegistrarCliente
    {
        
        public string nombreDeCliente { get; set; }
        public string correoElectronico { get; set; }
        public string password { get; set; }
        public string numeroTelefonico { get; set; }

    }
}
