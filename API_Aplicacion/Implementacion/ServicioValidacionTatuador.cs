

using API_Aplicacion.DTOs;
using API_Aplicacion.Interfaces;
using API_DominioTatuajes.Agregados;
using API_Infraestructura.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;

namespace API_Aplicacion.Implementacion
{
    public class ServicioValidacionTatuador : IServicioValidacionTatuador
    {
        public IRepositorioTatuador RepositorioTatuador { get; }
        public IRepositorioTatuadorCita RepositorioTatuadorCita { get;  }
        public IRepositorioClienteCita RepositorioClienteCita { get;  }
        public IRepositorioCliente RepositorioCliente { get;  }
        public IRepositorioTatuajeCita RepositorioTatuajeCita { get;  }

        public ServicioValidacionTatuador(IRepositorioTatuador repositorioTatuador,IRepositorioTatuadorCita repositorioTatuadorCita, IRepositorioClienteCita repositorioClienteCita, IRepositorioCliente repositorioCliente, IRepositorioTatuajeCita repositorioTatuajeCita)
        {
            this.RepositorioTatuador = repositorioTatuador;
            this.RepositorioTatuadorCita = repositorioTatuadorCita;
            this.RepositorioClienteCita = repositorioClienteCita;
            this.RepositorioCliente = repositorioCliente;
            this.RepositorioTatuajeCita = repositorioTatuajeCita;
            
        }
        public DTOTatuador ConsultarInfoTatuador(DTOTatuador dTOTatuador)
        {
            
            var listaTatuadores = RepositorioTatuador.ConsultarTodosLosTatuadores();
            Tatuador tatuador1 = listaTatuadores.FirstOrDefault(x => x.Tatuador_Correo.Cadenavalida.Equals(dTOTatuador.correoTauador));
            if (tatuador1 is null) tatuador1 = listaTatuadores.FirstOrDefault(x => x.Id.Equals(dTOTatuador.idTatuador));
            if (tatuador1 is null) throw new System.Exception("No se encontro informacion para los parametros dados");
            return new DTOTatuador { idTatuador = tatuador1.Id,correoTauador = tatuador1.Tatuador_Correo.Cadenavalida,nombreTatuador = tatuador1.Tatuador_Nombre,numeroTalefonico = tatuador1.Tatuador_NumTel};
        }

        public IEnumerable<DTOCitasTatuador> ConsultarCitasPorTatuador(DTOTatuador dTOTatuador)
        {
            var tatuador = RepositorioTatuador.ConsultarTodosLosTatuadores().FirstOrDefault(x => x.Id.Equals(dTOTatuador.idTatuador));            
            IEnumerable<TatuadorCita> listaCitas = RepositorioTatuadorCita.ConsultarCitasPorTatuador(tatuador);
            
            List<DTOCitasTatuador> listaDtos = new();
            foreach (var item in listaCitas)
            {
                CitaCliente citaCliente = RepositorioClienteCita.ConsultarCitaClientePorId(item.IdCita);
                Cliente cliente = RepositorioCliente.GetClientePorId(citaCliente.IdCliente);
                
                listaDtos.Add(new DTOCitasTatuador() { IdCita = item.IdCita,EsConAnticipo = citaCliente.EsConAnticipo,CantidadDeposito = citaCliente.CantidadDeposito,FechaCreacion = citaCliente.FechaCitaRegistrada,IdCliente = citaCliente.IdCliente,NombreCliente = cliente.Cliente_nombre});
            }
            return listaDtos;
        }

        public IEnumerable<Guid> ConsultarListaIdsCitas(DTOTatuador dTOTatuador)
        {
            List<Guid> listaIds = new();
            var tatuador = RepositorioTatuador.ConsultarTodosLosTatuadores().FirstOrDefault(x => x.Id == dTOTatuador.idTatuador);
            if (tatuador is null) throw new Exception("No se puede consultar el tatuador por el id ingresado");
            IEnumerable<TatuadorCita> tatuadorCitas = RepositorioTatuadorCita.ConsultarCitasPorTatuador(tatuador);
            foreach (var item in tatuadorCitas)
            {
                listaIds.Add(item.IdCita);
            }
            return listaIds;
        }

        public DTOCitasTatuador ConsultarDetalleCita(DTOTatuador dTOTatuador, Guid idCita)
        {
            DTOCitasTatuador dTO = new();
            var tatuador = RepositorioTatuador.ConsultarTodosLosTatuadores().FirstOrDefault(x => x.Id == dTOTatuador.idTatuador);
            if (tatuador is null) throw new Exception("No se puede consultar el tatuador por el id ingresado");
            var cita = RepositorioClienteCita.ConsultarCitaClientePorId(idCita);
            if (cita is null) throw new Exception("No se encontro cita para el id ingresado");

            var cliente = RepositorioCliente.GetClientePorId(cita.IdCliente);
            if (cliente is null) throw new Exception("No se encontro clinete para el id ingresado");
            var tatuaje = RepositorioTatuajeCita.ConsultarPorIdCita(idCita);
            if (tatuaje is null) throw new Exception("No se encontro informacion para el tatuaje ingresado");
            return new DTOCitasTatuador() { EsConAnticipo = cita.EsConAnticipo,
                CantidadDeposito = cita.CantidadDeposito,
                FechaCreacion = cita.FechaCitaRegistrada,
                IdCita = cita.IdCita,
                IdCliente = cita.IdCliente,
                NombreCliente = cliente.Cliente_nombre,
                IdCatalogo = tatuaje.TatuajeCita_IdCatalogo
            };            
        }
    }
}
