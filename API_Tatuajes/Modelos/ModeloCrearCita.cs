using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Tatuajes.Modelos
{
    ///<Summary></Summary>
    public class ModeloCrearCita
    {
        ///<Summary></Summary>
        public DateTime fechaCita { get; set; }
        ///<Summary></Summary>
        public int listaDeTatuajes { get; set; }
        ///<Summary></Summary>
        public bool esAnticipo { get; set; }
        ///<Summary></Summary>
        public double montoAnticipo { get; set; }
        ///<Summary></Summary>
        public Guid idUsuario { get; set; }

    }
}
