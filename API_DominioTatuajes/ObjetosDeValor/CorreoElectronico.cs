using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace API_DominioTatuajes.ObjetosDeValor
{
   public class CorreoElectronico
    {
        public string Cadenavalida { get; set; }
        public bool EscadenaValida { get; set; }
        protected CorreoElectronico(string correo)
        {
             if (string.IsNullOrEmpty(correo)) throw new ArgumentNullException("No se puede utilizar valor vacio");
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(correo, expresion)) {
                if (Regex.Replace(correo, expresion, String.Empty).Length == 0)
                {
                    EscadenaValida = true;
                    this.Cadenavalida = correo;

                }
                else
                {
                    this.EscadenaValida = false;
                    this.Cadenavalida = "";
                }

            }
            else
            {
                this.Cadenavalida = "";
                this.EscadenaValida = false;
            }
            if (this.EscadenaValida == false) throw new Exception("correo electronico mal escrito");

        }
        public static CorreoElectronico Crear(string email)
        {
            return new CorreoElectronico(email);
        }

    }
}
