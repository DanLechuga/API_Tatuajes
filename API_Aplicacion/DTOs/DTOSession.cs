using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Aplicacion.DTOs
{
   public class DTOSession
    {
        public Guid IdSession { get; set; }
        public Guid IdSessionUsuario { get; set; }
        public Guid IdSessionCliente { get; set; }
        public Guid IdSessionTatuador { get; set; }
        public Guid IdSessionCreador { get; set; }
        public bool SessionActiva { get; set; }
    }
}
