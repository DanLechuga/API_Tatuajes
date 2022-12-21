

using API_Aplicacion.DTOs;
using API_Aplicacion.Interfaces;
using API_DominioTatuajes.Agregados;
using API_Infraestructura.Interfaces;
using System.Linq;

namespace API_Aplicacion.Implementacion
{
    public class ServicioValidacionTatuador : IServicioValidacionTatuador
    {
        public IRepositorioTatuador RepositorioTatuador { get; set; }
        public ServicioValidacionTatuador(IRepositorioTatuador repositorioTatuador)
        {
            this.RepositorioTatuador = repositorioTatuador;
        }
        public DTOTatuador ConsultarInfoTatuador(DTOTatuador dTOTatuador)
        {
            
            var listaTatuadores = RepositorioTatuador.ConsultarTodosLosTatuadores();
            Tatuador tatuador1 = listaTatuadores.FirstOrDefault(x => x.Tatuador_Correo.Cadenavalida.Equals(dTOTatuador.correoTauador));
            if (tatuador1 is null) tatuador1 = listaTatuadores.FirstOrDefault(x => x.Id.Equals(dTOTatuador.idTatuador));
            if (tatuador1 is null) throw new System.Exception("No se encontro informacion para los parametros dados");
            return new DTOTatuador { idTatuador = tatuador1.Id,correoTauador = tatuador1.Tatuador_Correo.Cadenavalida,nombreTatuador = tatuador1.Tatuador_Nombre,numeroTalefonico = tatuador1.Tatuador_NumTel};
        }
    }
}
