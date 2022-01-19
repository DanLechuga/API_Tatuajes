using API_Comun;
using System;

namespace API_DominioTatuajes.Agregados
{
    public class Cita : Agregado
    {
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FechaEliminacion { get; set; }
        private Cita(Guid idCita, DateTime fechaCreacion, DateTime fechaModificacion, DateTime fechaEliminacion)
        {
            if (idCita == Guid.Empty) throw new ArgumentNullException("No se puede utilizar valor de id en 0");
            this.Id = idCita;
            this.FechaCreacion = fechaCreacion;
            this.FechaModificacion = fechaModificacion;
            this.FechaEliminacion = fechaEliminacion;
        }
        public static Cita Crear(Guid idCita, DateTime fechaCreacion, DateTime fechaModificacion, DateTime fechaEliminacion)
        {
            return new Cita(idCita, fechaCreacion, fechaModificacion, fechaEliminacion);
        }

    }
}