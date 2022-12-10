using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasTatuajes.PruebasDominio
{
   public class ArregloPrecios
    {

        public string[] arregloBase { get; set; }
        public void EliminarPrecioPar(string[] arreglo)
        {
            for (int i = 0; i < arreglo.Length; i++)
            {
                if (int.Parse(arreglo[i]) % 2 == 0)
                {
                    arregloBase[i].Remove(i);
                    
                    

                }
            }

        }
        public void EliminarPrecioImpar(string[] arreglo)
        {
            for (int i = 0; i < arreglo.Length; i++)
            {
                if (!(int.Parse(arreglo[i]) % 2 == 0))
                {
                    arregloBase[i].Remove(i);


                }
            }

        }
        public void PasarPrimerPrecioAlFinal(string[] arreglo)
        {
            int tamañoArreglo = arreglo.Length - 1;
            var primero = arreglo[0];
            var ultimo = arreglo[tamañoArreglo];            
            arreglo[tamañoArreglo] = primero;
            arreglo[0] = ultimo;
        }
        public string BuscarPrecioPorPosicion(int posicion)
        {
            var objetoBuscado = arregloBase[posicion];
            return objetoBuscado;
        }
    }
}
