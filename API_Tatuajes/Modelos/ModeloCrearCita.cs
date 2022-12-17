using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Tatuajes.Modelos
{
    ///<Summary></Summary>
    public class ModeloCrearCita 
    {
        ///<Summary></Summary>
        [Required]
        public DateTime fechaCita { get; set; }
        ///<Summary></Summary>
        [Required]
        public int listaDeTatuajes { get; set; }
        ///<Summary></Summary>
        [Required]
        public bool esAnticipo { get; set; }
        ///<Summary></Summary>
        [Required]
        public double montoAnticipo { get; set; }
        ///<Summary></Summary>
        [Required]
        public Guid idUsuario { get; set; }
        /// <summary>       
        /// </summary>
        public string nombreTatuajeCustom { get; set; }


    }
}
