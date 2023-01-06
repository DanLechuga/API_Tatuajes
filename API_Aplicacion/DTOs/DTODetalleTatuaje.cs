using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace API_Aplicacion.DTOs
{
   public class DTODetalleTatuaje
    {
        public int IdTatuaje { get; set; }
        public string NombreTatuaje { get; set; }
        public string PrecioTatuaje { get; set; }
        [JsonProperty("nombreTatuajeCustom",NullValueHandling =NullValueHandling.Ignore)]
        public string NombreTatuajeCustom { get; set; }


    }
}
