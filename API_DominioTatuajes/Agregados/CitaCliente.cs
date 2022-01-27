using API_Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_DominioTatuajes.Agregados
{
    public  class CitaCliente :Agregado
    {
        public Guid IdCita { get; set; }
        public Guid IdCliente { get; set; }
        public DateTime FechaCitaRegistrada { get; set; }
        public bool EsConAnticipo { get; set; }
        public double CantidadDeposito { get; set; }
        public Guid IdTatuador { get; set; }
        public Guid IdCitaCliente { get; }       
        public double CantidadAnticipo { get; }
        public string NombreTatuador { get;  }

        private CitaCliente(Guid idCitaCliente,Guid idCita,Guid idCliente,DateTime fechaRegistro, bool esConAnticipo, double cantidadAnticipo,Guid idTatuador,string nombreTatuador)
        {
            this.Id = idCitaCliente;
            IdCita = idCita;
            IdCliente = idCliente;
            FechaCitaRegistrada = fechaRegistro;
            EsConAnticipo = esConAnticipo;
            CantidadDeposito = cantidadAnticipo;
            IdTatuador = idTatuador;
            NombreTatuador = nombreTatuador;
        }

        public static CitaCliente Crear(Guid idCitaCliente, Guid idCita, Guid idCliente, DateTime fechaRegistro, bool esConAnticipo, double cantidadAnticipo, Guid idTatuador, string nombreTatuador)
        {
            return new CitaCliente(idCitaCliente,idCita,idCliente,fechaRegistro,esConAnticipo,cantidadAnticipo,idTatuador,nombreTatuador);
        }
    }
}
