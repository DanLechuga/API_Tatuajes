using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Tatuajes.Modelos
{
    public class ModeloCerrarSession
    {
        public Guid idCliente { get; set; }
        public string nombreUsuario { get; set; }
        public string numeroTelefonico { get; set; }
    }
}
