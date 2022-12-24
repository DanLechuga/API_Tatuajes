using System;

namespace API_Aplicacion.DTOs
{
   public class DTOCitasTatuador
    {
        public Guid IdCita { get; set; }
        public string NombreCliente { get; set; }
        public Guid IdCliente { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool EsConAnticipo { get; set; }
        public double CantidadDeposito { get; set; }
        public int IdCatalogo { get; set; }
    }
}
