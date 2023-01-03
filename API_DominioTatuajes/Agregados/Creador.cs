using API_Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_DominioTatuajes.Agregados
{
   public class Creador : Agregado
    {
        			
        public string CreadorNombre { get; private set; }
        public string CreadorTelefono { get; private set; }
        public string CreadorCorreo { get; private set; }
        private Creador(Guid creadorId,string creadorNombre,string creadorTelefono,string creadorCorreo)
        {
            this.Id = creadorId;
            this.CreadorNombre = creadorNombre;
            this.CreadorCorreo = creadorCorreo;
            this.CreadorTelefono = creadorTelefono;
        }
        public static Creador Crear(Guid creadorId, string creadorNombre, string creadorTelefono, string creadorCorreo)
        {
            return new Creador(creadorId,creadorNombre,creadorTelefono,creadorCorreo);
        }
    }
}
