using API_Comun;
using API_DominioTatuajes.ObjetosDeValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_DominioTatuajes.Agregados
{
   public class Tatuador : Agregado
    {
        public string Tatuador_Nombre { get; set; }
        public CorreoElectronico Tatuador_Correo { get; set; }
        public string Tatuador_NumTel { get; set; }
        private Tatuador(Guid tatuadorId,string tatuadorNombre,CorreoElectronico tatuadorCorreo, string tatuadorNumTel)
        {
            this.Id = tatuadorId;
            this.Tatuador_Correo = tatuadorCorreo ?? throw new ArgumentNullException("No se puede utilizar valores nulos");
            this.Tatuador_Nombre = tatuadorNombre;
            if (tatuadorNumTel.Length > 14) throw new ArgumentOutOfRangeException("El numero telefonico no puede exceder los 14 caracteres");
            if (string.IsNullOrEmpty(tatuadorNumTel)) throw new ArgumentNullException("El campo numero telefonico es obligatorio");
            if (string.IsNullOrWhiteSpace(tatuadorNumTel)) throw new ArgumentNullException("El campo numero telefonico esta mal escrito, por favor corregir");
            this.Tatuador_NumTel = tatuadorNumTel;
        }
        public static Tatuador Crear(Guid tatuadorId, string tatuadorNombre, CorreoElectronico tatuadorCorreo, string tatuadorNumTel)
        {
            return new Tatuador(tatuadorId,tatuadorNombre,tatuadorCorreo,tatuadorNumTel);
        }
        
    }
}
