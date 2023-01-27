using System;

namespace API_Aplicacion.DTOs
{
    [Serializable]
    public class DTOBusinessException : Exception
    {
        public DTOBusinessException(string message) : base(message)
        {
        }
        public DTOBusinessException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}
