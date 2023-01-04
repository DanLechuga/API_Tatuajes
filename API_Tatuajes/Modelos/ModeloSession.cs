using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Tatuajes.Modelos
{
    ///<Summary></Summary>
    public class ModeloSession
    {
        ///<Summary></Summary>
        public Guid idSession { get; set; }
        ///<Summary></Summary>
        public Guid idSessionUsuario { get; set; }
        ///<Summary></Summary>
        public Guid idSessionCliente { get; set; }
        ///<Summary></Summary>
        public Guid idSessionTatuador { get; set; }
        ///<Summary></Summary>
        public Guid idSessionCreador { get; set; }
        ///<Summary></Summary>
        public bool sessionActiva { get; set; }
    }
}
