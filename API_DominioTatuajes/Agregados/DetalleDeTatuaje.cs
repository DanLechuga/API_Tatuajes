using API_Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_DominioTatuajes.Agregados
{
   public class DetalleDeTatuaje : Agregado
    {
        public string NombreTatuaje { get; set; }
        public double PrecioTatuaje { get; set; }
        private DetalleDeTatuaje(int Id,string NombreTatuaje,double PrecioTatuaje)
        {
            this.ID = Id;
            this.NombreTatuaje = NombreTatuaje;
            this.PrecioTatuaje = PrecioTatuaje;
        }
        public static DetalleDeTatuaje Crear (int Id, string NombreTatuaje, double PrecioTatuaje)
        {
            return new DetalleDeTatuaje(Id, NombreTatuaje, PrecioTatuaje);
        }

    }
}
