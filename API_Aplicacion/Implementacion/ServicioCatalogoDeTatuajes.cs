using API_Aplicacion.DTOs;
using API_Aplicacion.Interfaces;
using API_DominioTatuajes.Agregados;
using API_Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Aplicacion.Implementacion
{
    public class ServicioCatalogoDeTatuajes : IServicioCatalogoDeTatuajes
    {
        public IRepositorioCatalogoDeTatuajes RepositorioCatalogoDeTatuajes { get;}
        public IRepositorioTatuajeCita RepositorioTatuajeCita { get; }
        public ServicioCatalogoDeTatuajes(IRepositorioCatalogoDeTatuajes repositorioCatalogoDeTatuajes,IRepositorioTatuajeCita repositorioTatuajeCita)
        {
            this.RepositorioCatalogoDeTatuajes = repositorioCatalogoDeTatuajes;
            this.RepositorioTatuajeCita = repositorioTatuajeCita;
        }
        public IEnumerable<DTOCatalogoTatuajes> ConsultarCatalogoDeTatuajes()
        {
            List<DTOCatalogoTatuajes> dTOCatalogos = new();
            IEnumerable<CatalogoDeTatuajes> catalogoDeTatuajes = RepositorioCatalogoDeTatuajes.ConsultarCatalogoDeTatuajes();
            foreach (var item in catalogoDeTatuajes)
            {
                dTOCatalogos.Add(new DTOCatalogoTatuajes() { IdTatuaje = item.ID,NombreTatuaje = item.NombreTatuaje, PrecioTatuaje = item.PrecioTatuaje});
            }
            return dTOCatalogos;
        }

        public DTODetalleTatuaje ConsultarDetalleTatuaje(int idTatuaje)
        {
            
            DetalleDeTatuaje detalleDeTatuaje = RepositorioCatalogoDeTatuajes.ConsultarDetalleTatuaje(idTatuaje); 
            
            return new DTODetalleTatuaje()
            {
                IdTatuaje = detalleDeTatuaje.ID,
                NombreTatuaje = detalleDeTatuaje.NombreTatuaje,
                PrecioTatuaje = $"${detalleDeTatuaje.PrecioTatuaje}"
            };
        }

        public DTODetalleTatuaje ConsultarDetalleTatuajePorIdCita(Guid idCita)
        {
            if (idCita == Guid.Empty) throw new ArgumentNullException("No se puede consultar valores vacios");
            TatuajeCita tatuajeCita = RepositorioTatuajeCita.ConsultarPorIdCita(idCita);
            if (tatuajeCita.TatuajeCita_IdCatalogo == 25 && string.IsNullOrEmpty(tatuajeCita.TatuajeCita_NombreTatuajeCustom)) throw new Exception("No se registro nombre para el tatuaje dado por el cliente");
            return new DTODetalleTatuaje()
            {
                NombreTatuajeCustom = tatuajeCita.TatuajeCita_NombreTatuajeCustom
            };
        }
    }
}
