using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Tatuajes.Modelos
{
    ///<Summary></Summary>
    public class ModeloCerrarSessionCliente
    {
        ///<Summary></Summary>
        public Guid idCliente { get; set; }
        ///<Summary></Summary>
        public string nombreUsuario { get; set; }
        ///<Summary></Summary>
        public string numeroTelefonico { get; set; }
    }
}
