using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Tatuajes.Modelos
{
    ///<Summary></Summary>
    public class ModeloRegistrarCliente
    {
        ///<Summary></Summary>
        public string nombreDeCliente { get; set; }
        ///<Summary></Summary>
        public string correoElectronico { get; set; }
        ///<Summary></Summary>
        public string password { get; set; }
        ///<Summary></Summary>
        public string numeroTelefonico { get; set; }

    }
}
