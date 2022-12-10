using API_Aplicacion.DTOs;
using API_Aplicacion.Interfaces;
using API_Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Aplicacion.Implementacion
{
    public class ServicioError : IServicioError
    {
        public IRepositorioError RepositorioError { get; }
        public ServicioError(IRepositorioError repositorioError)
        {
            this.RepositorioError = repositorioError;
        }
        public void RegistrarError(DTOException dTOException)
        {
            if (dTOException == null) throw new Exception("No se puede usar valores nulos");
            if (dTOException.Exception == null) throw new Exception("No se pueden usar valores nulos");
            if (string.IsNullOrEmpty(dTOException.Exception.Message)) throw new Exception("Es necesario ingresar un mensaje a los errores");
            RepositorioError.RegistrarError(dTOException.Exception.Message, dTOException.Exception.InnerException?.Message, dTOException.Exception.StackTrace);

        }
        
    }
}
