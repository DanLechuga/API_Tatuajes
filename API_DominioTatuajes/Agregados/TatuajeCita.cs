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
        public string TatuajeCita_NombreTatuajeCustom { get; set; }
        private TatuajeCita(Guid tatuajeCita_Id, Guid tatuajeCita_IdCita,int tatuajeCita_IdCatalogoTatuajes, string tatuajeCita_NombreTatuajeCustom)
        {
            this.Id = tatuajeCita_Id;
            this.TatuajeCita_IdCita = tatuajeCita_IdCita;
            this.TatuajeCita_IdCatalogo = tatuajeCita_IdCatalogoTatuajes;
            this.TatuajeCita_NombreTatuajeCustom = tatuajeCita_NombreTatuajeCustom;

        }

        public static TatuajeCita Crear(Guid tatuajeCita_Id, Guid tatuajeCita_IdCita, int tatuajeCita_IdCatalogoTatuajes, string tatuajeCita_NombreTatuajeCustom)
        {
            return new TatuajeCita(tatuajeCita_Id,tatuajeCita_IdCita,tatuajeCita_IdCatalogoTatuajes,tatuajeCita_NombreTatuajeCustom);
        }


    }
}
