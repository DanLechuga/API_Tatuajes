

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
        public IRepositorioCliente RepositorioCliente { get; set; }

        public ServicioValidacionTatuador(IRepositorioTatuador repositorioTatuador,IRepositorioTatuadorCita repositorioTatuadorCita, IRepositorioClienteCita repositorioClienteCita, IRepositorioCliente repositorioCliente)
        {
            this.RepositorioTatuador = repositorioTatuador;
            this.RepositorioTatuadorCita = repositorioTatuadorCita;
            this.RepositorioClienteCita = repositorioClienteCita;
            this.RepositorioCliente = repositorioCliente;
            
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
    }
}
