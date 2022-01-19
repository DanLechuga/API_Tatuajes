using API_Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_DominioTatuajes.Agregados
{
   public class TatuajeCita : Agregado
    {
        // TatuajeCita_IdCatalogo  
        public Guid TatuajeCita_IdCita { get; set; }
        public int TatuajeCita_IdCatalogo { get; set; }
        private TatuajeCita(Guid tatuajeCita_Id, Guid tatuajeCita_IdCita,int tatuajeCita_IdCatalogoTatuajes)
        {
            this.Id = tatuajeCita_Id;
            this.TatuajeCita_IdCita = tatuajeCita_IdCita;
            this.TatuajeCita_IdCatalogo = tatuajeCita_IdCatalogoTatuajes;

        }

        public static TatuajeCita Crear(Guid tatuajeCita_Id, Guid tatuajeCita_IdCita, int tatuajeCita_IdCatalogoTatuajes)
        {
            return new TatuajeCita(tatuajeCita_Id,tatuajeCita_IdCita,tatuajeCita_IdCatalogoTatuajes);
        }


    }
}
