using System;

namespace API_Aplicacion.DTOs
{
    public class DTOCitas
    {
        public Guid IdCita { get; set; }
        public Guid IdUsuario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool EsConAnticipo { get; set; }
        public double CantidadDeposito { get; set; }
        public Guid IdTatuador { get; set; }
        public int IdCatalogo { get; set; }
    }
}