using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Tatuajes.Modelos
{
    public class ModeloCrearCita
    {
        public DateTime fechaCita { get; set; }
        public int listaDeTatuajes { get; set; }
        public bool esAnticipo { get; set; }
        public double montoAnticipo { get; set; }
        public Guid idUsuario { get; set; }

    }
}
