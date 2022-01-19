using API_Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_DominioTatuajes.Agregados
{
   public class TatuadorCita : Agregado
    {
        public Guid IdTatuador { get; set; }
        public Guid IdCita { get; set; }
        private TatuadorCita(Guid TatuadorCita_Id,Guid TatuadorCita_IdTatuador,Guid TatuadorCita_IdCita)
        {
            this.Id = TatuadorCita_Id;
            this.IdTatuador = TatuadorCita_IdTatuador;
            this.IdCita = TatuadorCita_IdCita;
        }
        public static TatuadorCita Crear(Guid TatuadorCita_Id, Guid TatuadorCita_IdTatuador, Guid TatuadorCita_IdCita)
        {
            return new TatuadorCita(TatuadorCita_Id,TatuadorCita_IdTatuador,TatuadorCita_IdCita);
        }
        
        
    }
}
