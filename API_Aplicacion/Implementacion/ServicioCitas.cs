using API_Aplicacion.DTOs;
using API_Aplicacion.Interfaces;
using API_Infraestructura;
using API_Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_DominioTatuajes.Agregados;

namespace API_Aplicacion.Implementacion
{
   public class ServicioCitas : IServicioDeCitas
    {
        public IRepositorioCita RepositorioCita { get; }
        public IRepositorioClienteCita RepositorioClienteCita { get;  }
        public IRepositorioTatuadorCita RepositorioTatuadorCita { get; }
        public IRepositorioTatuajeCita RepositorioTatuajeCita { get;  }

        public IRepositorioUsuario RepositorioUsuario { get; set; }
        public IRepositorioTatuador RepositorioTatuador { get; set; }
        public ServicioCitas(IRepositorioCita repositorioCita, IRepositorioClienteCita repositorioClienteCita, IRepositorioUsuario repositorioUsuario, IRepositorioTatuador repositorioTatuador, IRepositorioTatuadorCita repositorioTatuadorCita, IRepositorioTatuajeCita repositorioTatuajeCita)
        {
            this.RepositorioCita = repositorioCita;
            this.RepositorioClienteCita = repositorioClienteCita;
            this.RepositorioUsuario = repositorioUsuario;
            this.RepositorioTatuador = repositorioTatuador;
            this.RepositorioTatuadorCita = repositorioTatuadorCita;
            this.RepositorioTatuajeCita = repositorioTatuajeCita;
        }

        public IEnumerable<DTOCitas> ConsultarCitas(DTOUsuario usuario)
        {
            Usuario usuarioConsultado = null;
            List<DTOCitas> ListaDto = new();
            if (usuario == null) throw new ArgumentNullException("No se pude usar valores nulos para consultar citas");            
            usuarioConsultado = RepositorioUsuario.GetUsuarioCliente(usuario.IdUsaurio);            
            //IEnumerable<Cita> ListaCitas = RepositorioCita.ConsultaCita(usuarioConsultado);
            IEnumerable<CitaCliente> ListaCitaClientes = RepositorioClienteCita.ConsultaCitaCliente(usuarioConsultado);
            
                foreach (CitaCliente itemCC in ListaCitaClientes)
                {
                    ListaDto.Add(new DTOCitas() { IdUsuario = itemCC.IdCliente, IdCita =itemCC.Id,EsConAnticipo = itemCC.EsConAnticipo, FechaCreacion = itemCC.FechaCitaRegistrada,IdTatuador = itemCC.IdTatuador,CantidadDeposito = itemCC.CantidadDeposito,NombreTatuador = itemCC.NombreTatuador });
                    
                }
              
            return ListaDto;
            
        }

        public void CrearCita(DTOCitas dTOCitas)
        {
            if (dTOCitas == null) throw new ArgumentNullException("No se puede usar un valor vacio o nulo");
            IEnumerable<Tatuador> ListaTatuadores = RepositorioTatuador.ConsultarTodosLosTatuadores();
            Tatuador tatuador = ListaTatuadores.FirstOrDefault();
            if (tatuador == null) throw new ArgumentNullException("No existe tatuadores registrados en el sistema");
            Cita cita = Cita.Crear(dTOCitas.IdCita,dTOCitas.FechaCreacion, dTOCitas.FechaCreacion, dTOCitas.FechaCreacion);
            CitaCliente citaCliente = CitaCliente.Crear(Guid.NewGuid(),cita.Id,dTOCitas.IdUsuario,cita.FechaCreacion,dTOCitas.EsConAnticipo,dTOCitas.CantidadDeposito,tatuador.Id,tatuador.Tatuador_Nombre);
            TatuadorCita tatuadorCita = TatuadorCita.Crear(Guid.NewGuid(), tatuador.Id, cita.Id);
            TatuajeCita tatuajeCita = TatuajeCita.Crear(Guid.NewGuid(),cita.Id,dTOCitas.IdCatalogo);

            RepositorioCita.Agregar(cita);
            RepositorioClienteCita.Agregar(citaCliente);
            RepositorioTatuadorCita.Agregar(tatuadorCita);
            RepositorioTatuajeCita.Agregar(tatuajeCita);
        }
    }

  
}
