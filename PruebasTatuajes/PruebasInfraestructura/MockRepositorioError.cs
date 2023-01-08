using API_Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasTatuajes.PruebasInfraestructura
{
    public class MockRepositorioError : IRepositorioError
    {
        public MockRepositorioError()
        {
            ListaExceptions = new();

        }
        public List<Exception> ListaExceptions { get; set; }
        public void RegistrarError(string ExceptionMessage, string InnerException, string StackTrace)
        {
            ListaExceptions.Add(new Exception(ExceptionMessage, new Exception(InnerException)));
        }
    }
}
