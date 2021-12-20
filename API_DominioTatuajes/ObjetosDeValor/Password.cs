using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_DominioTatuajes.ObjetosDeValor
{
  public class Password
    {
        public string ContraseniaValida { get; set; }
        public bool EsContraseniaValida { get; set; }
        private static string[] ArregloDeLetrasMayusculas { get {
                return "A,B,C,CH,D,E,F,G,H,I,J,K,L,LL,M,Ñ,O,P,Q,R,S,T,W,X,Y,Z".Split(',') ;
            } }
        
        protected Password(string contrasenia)
        {
            if (string.IsNullOrEmpty(contrasenia)) throw new ArgumentNullException("No se puede utilizar valor vacio");
            int contadorDeLetrasMinusculas = 0, contadorDeLetrasMayusculas = 0;
            if(contrasenia.Length == 0 || contrasenia.Length > 50)
            {
                throw new ArgumentOutOfRangeException("la contraseña supera el limete para la contraseña");
            }
            for (int i = 0; i < ArregloDeLetrasMayusculas.Length; i++)
            {
                if (!contrasenia.Contains(ArregloDeLetrasMayusculas[i])) contadorDeLetrasMayusculas++; 
            }
            for (int i = 0; i < ArregloDeLetrasMayusculas.Length; i++)
            {
                if (!contrasenia.Contains(ArregloDeLetrasMayusculas[i].ToLower())) contadorDeLetrasMinusculas++;
            }
            if (contadorDeLetrasMayusculas == ArregloDeLetrasMayusculas.Length) throw new Exception("La contrasenia no contiene letras mayusculas");
            if (contadorDeLetrasMinusculas == 26) throw new Exception("La contrasenia no contiene letas minusculas");
            this.ContraseniaValida = contrasenia;
            this.EsContraseniaValida = true;
        }
        public static Password Crear(string contrasenia)
        {
            return new Password(contrasenia);
        } 

    }
}
