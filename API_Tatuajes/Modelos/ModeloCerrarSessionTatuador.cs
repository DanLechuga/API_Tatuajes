using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Tatuajes.Modelos
{
    /// <summary>
    /// 
    /// </summary>
    public class ModeloCerrarSessionTatuador
    {
        ///<Summary></Summary>
        public Guid idTatuador { get; set; }
        ///<Summary></Summary>
        public string nombreUsuario { get; set; }
        ///<Summary></Summary>
        public string numeroTelefonico { get; set; }
    }
}
