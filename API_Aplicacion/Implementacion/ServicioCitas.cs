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
using AutoMapper;

namespace API_Aplicacion.Implementacion
{
   public class ServicioCitas : IServicioDeCitas
    {
        public IRepositorioCita RepositorioCita { get; }
        public IRepositorioClienteCita RepositorioClienteCita { get;  }
        public IRepositorioTatuadorCita RepositorioTatuadorCita { get; }
        public IRepositorioTatuajeCita RepositorioTatuajeCita { get;  }
        public IMapper Mapper { get; set; }
        public IRepositorioUsuario RepositorioUsuario { get; set; }
        public IRepositorioTatuador RepositorioTatuador { get; set; }
        public IServicioError ServicioError { get; }
        public ServicioCitas(IRepositorioCita repositorioCita, IRepositorioClienteCita repositorioClienteCita, IRepositorioUsuario repositorioUsuario, IRepositorioTatuador repositorioTatuador, IRepositorioTatuadorCita repositorioTatuadorCita, IRepositorioTatuajeCita repositorioTatuajeCita, IServicioError servicioError,IMapper _mapper)
        {
            this.RepositorioCita = repositorioCita;
            this.RepositorioClienteCita = repositorioClienteCita;
            this.RepositorioUsuario = repositorioUsuario;
            this.RepositorioTatuador = repositorioTatuador;
            this.RepositorioTatuadorCita = repositorioTatuadorCita;
            this.RepositorioTatuajeCita = repositorioTatuajeCita;
            this.ServicioError = servicioError;
            this.Mapper = _mapper;
        }

        public IEnumerable<DTOCitas> ConsultarCitas(DTOUsuario usuario)
        {
            IEnumerable<DTOCitas> listaDtos;
            
                Usuario usuarioConsultado;                
                if (usuario == null) throw new DTOBusinessException("No se pude usar valores nulos para consultar citas");
                usuarioConsultado = RepositorioUsuario.GetUsuarioCliente(usuario.IdUsaurio);
                if (usuarioConsultado is null) throw new DTOBusinessException($"No se encontro usuario para el valor ingresado: {usuario.Username}");
                IEnumerable<CitaCliente> ListaCitaClientes = RepositorioClienteCita.ConsultaCitaCliente(usuarioConsultado);
                listaDtos = Mapper.Map<IEnumerable<DTOCitas>>(ListaCitaClientes);

            return listaDtos;

        }

        public void CrearCita(DTOCitas dTOCitas)
        {
           
                if (dTOCitas == null) throw new Exception("No se puede usar un valor vacio o nulo");
                IEnumerable<Tatuador> ListaTatuadores = RepositorioTatuador.ConsultarTodosLosTatuadores();
                Tatuador tatuador = ListaTatuadores.FirstOrDefault();
                if (tatuador == null) throw new Exception("No existe tatuadores registrados en el sistema");
                Cita cita = Cita.Crear(dTOCitas.IdCita, dTOCitas.FechaCreacion, dTOCitas.FechaCreacion, dTOCitas.FechaCreacion);
                CitaCliente citaCliente = CitaCliente.Crear(Guid.NewGuid(), cita.Id, dTOCitas.IdUsuario, cita.FechaCreacion, dTOCitas.EsConAnticipo, dTOCitas.CantidadDeposito, tatuador.Id, tatuador.Tatuador_Nombre);
                TatuadorCita tatuadorCita = TatuadorCita.Crear(Guid.NewGuid(), tatuador.Id, cita.Id);
                TatuajeCita tatuajeCita = TatuajeCita.Crear(Guid.NewGuid(), cita.Id, dTOCitas.IdCatalogo, dTOCitas.NombreTatuajeCustom);
                if (tatuajeCita.TatuajeCita_IdCatalogo == 25 && string.IsNullOrEmpty(tatuajeCita.TatuajeCita_NombreTatuajeCustom)) throw new Exception($"No se puede registrar tatuaje custom sin nombre para cita {cita.Id}");
                RepositorioCita.Agregar(cita);
                RepositorioClienteCita.Agregar(citaCliente);
                RepositorioTatuadorCita.Agregar(tatuadorCita);
                RepositorioTatuajeCita.Agregar(tatuajeCita);
                      
        }

        public IEnumerable<Guid> ConsultasIds(DTOUsuario dTOUsuario)
        {
            List<Guid> ListaDto = new();
           
                if (dTOUsuario == null) throw new DTOBusinessException("No se pude usar valores nulos para consultar citas");
                Usuario UsuarioConsultado = RepositorioUsuario.GetUsuarioCliente(dTOUsuario.IdUsaurio);
            if (UsuarioConsultado is null) throw new DTOBusinessException($"No se puede consultar usuario por el id dado: {dTOUsuario.IdUsaurio}");
                //IEnumerable<Cita> ListaCitas = RepositorioCita.ConsultaCita(usuarioConsultado);
                IEnumerable<CitaCliente> ListaCitaClientes = RepositorioClienteCita.ConsultaCitaCliente(UsuarioConsultado);

                foreach (CitaCliente itemCC in ListaCitaClientes)
                {
                    ListaDto.Add(itemCC.IdCita);

                }

          
            
            
            return ListaDto;
        }

        public DTOCitas ConsultarCita(DTOCitas dTOCitas)
        {
            DTOCitas citas = null;
            
                if (dTOCitas is null) throw new DTOBusinessException("No se puede ultilizar valores vacios");

                CitaCliente citaCliente = RepositorioClienteCita.ConsultarCitaClientePorId(dTOCitas.IdCita);
                if (citaCliente is null) throw new DTOBusinessException($"No se pudo obtener informacion para el id solicitado: {dTOCitas.IdCita}");
                TatuajeCita tatuajeCita = RepositorioTatuajeCita.ConsultarPorIdCita(dTOCitas.IdCita);
                if(tatuajeCita is null) throw new DTOBusinessException($"No se pudo obtener informacion para el id solicitado: {dTOCitas.IdCita}");
                var tatuador = RepositorioTatuador.ConsultarTodosLosTatuadores();
                citas = Mapper.Map<DTOCitas>(citaCliente);
                Mapper.Map(tatuajeCita, citas);
                citas.NombreTatuador = tatuador.FirstOrDefault(x => x.Id.Equals(citaCliente.IdTatuador)).Tatuador_Nombre;                               
          
             return citas;
            
        }

        public void ActualizarCita(DTOCitas dTOCitas)
        {
           
                CitaCliente citaC = RepositorioClienteCita.ConsultarCitaClientePorId(dTOCitas.IdCita);
                if(citaC is null) throw new DTOBusinessException($"No se puede consultar cita por el identificado ingresado: {dTOCitas.IdCita}");
                citaC.CambioDeFecha(dTOCitas.FechaCreacion);
            Cita cita = RepositorioCita.ConsultaCitaPorId(dTOCitas.IdCita);
            cita.CambioFecha(dTOCitas.FechaCreacion);
                RepositorioClienteCita.Update(citaC);
                RepositorioCita.Update(cita);

        }

        public void EliminarCitaPorId(Guid idCita)
        {
            if (idCita.Equals(Guid.Empty)) throw new DTOBusinessException("No se acepta valores vacios");
            CitaCliente citaC = RepositorioClienteCita.ConsultarCitaClientePorId(idCita);
            if (citaC is null) throw new DTOBusinessException($"No se encontro cita para el id ingresado: {idCita}");
            Cita cita = RepositorioCita.ConsultaCitaPorId(idCita);
            if (cita is null) throw new DTOBusinessException($"No se encontro cita para el id ingresado: {idCita}");
            TatuajeCita tatuajeCita = RepositorioTatuajeCita.ConsultarPorIdCita(idCita);
            if (tatuajeCita is null) throw new DTOBusinessException($"No se encontro cita para el id ingresado: {idCita}");
            TatuadorCita tatuadorCita = RepositorioTatuadorCita.ConsultarCitaPorId(idCita);
            if (tatuadorCita is null) throw new DTOBusinessException($"No se encontro cita para el id ingresado: {idCita}");
            RepositorioClienteCita.EliminarPorId(idCita);
            RepositorioCita.EliminarPorId(idCita);

            RepositorioTatuajeCita.EliminarPorId(idCita);
            RepositorioTatuadorCita.EliminarPorId(idCita);
        }
    }

  
}
