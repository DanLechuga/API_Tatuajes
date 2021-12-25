using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Tatuajes.Modelos
{
    public class ModeloSession
    {
        public Guid idSession { get; set; }
        public Guid idSessionUsuario { get; set; }
        public Guid idSessionCliente { get; set; }
        public Guid idSessionTatuador { get; set; }
        public bool sessionActiva { get; set; }
    }
}
