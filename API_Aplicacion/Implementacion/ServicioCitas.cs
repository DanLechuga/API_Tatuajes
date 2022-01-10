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
        public IRepositorioClienteCita RepositorioClienteCita { get; set; }
        public IRepositorioUsuario RepositorioUsuario { get; set; }
        public ServicioCitas(IRepositorioCita repositorioCita, IRepositorioClienteCita repositorioClienteCita, IRepositorioUsuario repositorioUsuario)
        {
            this.RepositorioCita = repositorioCita;
            this.RepositorioClienteCita = repositorioClienteCita;
            this.RepositorioUsuario = repositorioUsuario;
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
                    ListaDto.Add(new DTOCitas() { IdUsuario = itemCC.IdCliente, IdCita =itemCC.Id,EsConAnticipo = itemCC.EsConAnticipo, FechaCreacion = itemCC.FechaCitaRegistrada,IdTatuador = itemCC.IdTatuador,CantidadDeposito = itemCC.CantidadDeposito });
                    
                }
              
            return ListaDto;
            
        }
    }


}
