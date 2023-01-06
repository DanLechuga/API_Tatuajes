using API_Aplicacion.DTOs;
using API_Aplicacion.Interfaces;
using API_DominioTatuajes.Agregados;
using API_Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using AutoMapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Aplicacion.Implementacion
{
    public class ServicioCatalogoDeTatuajes : IServicioCatalogoDeTatuajes
    {
        public IRepositorioCatalogoDeTatuajes RepositorioCatalogoDeTatuajes { get;}
        public IRepositorioTatuajeCita RepositorioTatuajeCita { get; }
        public IMapper mapper { get; set; }
        public ServicioCatalogoDeTatuajes(IRepositorioCatalogoDeTatuajes repositorioCatalogoDeTatuajes,IRepositorioTatuajeCita repositorioTatuajeCita, IMapper _mapper)
        {
            this.RepositorioCatalogoDeTatuajes = repositorioCatalogoDeTatuajes;
            this.RepositorioTatuajeCita = repositorioTatuajeCita;
            this.mapper = _mapper;
        }
        public IEnumerable<DTOCatalogoTatuajes> ConsultarCatalogoDeTatuajes()
        {
            
            IEnumerable<CatalogoDeTatuajes> catalogoDeTatuajes = RepositorioCatalogoDeTatuajes.ConsultarCatalogoDeTatuajes();
            IEnumerable<DTOCatalogoTatuajes> dtoCatalogo = mapper.Map<IEnumerable<DTOCatalogoTatuajes>>(catalogoDeTatuajes);
            return dtoCatalogo;
        }

        public DTODetalleTatuaje ConsultarDetalleTatuaje(int idTatuaje)
        {
            
            DetalleDeTatuaje detalleDeTatuaje = RepositorioCatalogoDeTatuajes.ConsultarDetalleTatuaje(idTatuaje);
            DTODetalleTatuaje dtoDetalle = mapper.Map<DTODetalleTatuaje>(detalleDeTatuaje);

            return dtoDetalle;
        }

        public DTODetalleTatuaje ConsultarDetalleTatuajePorIdCita(Guid idCita)
        {
            if (idCita == Guid.Empty) throw new ArgumentNullException("No se puede consultar valores vacios");
            TatuajeCita tatuajeCita = RepositorioTatuajeCita.ConsultarPorIdCita(idCita);
            DTODetalleTatuaje dtoDetalle = mapper.Map<DTODetalleTatuaje>(tatuajeCita);
            var detalle = ConsultarDetalleTatuaje(tatuajeCita.TatuajeCita_IdCatalogo);
            mapper.Map(detalle, dtoDetalle);            
            if (tatuajeCita.TatuajeCita_IdCatalogo == 25 && string.IsNullOrEmpty(tatuajeCita.TatuajeCita_NombreTatuajeCustom)) throw new Exception("No se registro nombre para el tatuaje dado por el cliente");
            return dtoDetalle;
        }
    }
}
