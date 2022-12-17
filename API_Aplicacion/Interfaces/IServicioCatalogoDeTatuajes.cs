using API_Aplicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Aplicacion.Interfaces
{
    public interface IServicioCatalogoDeTatuajes
    {
        IEnumerable<DTOCatalogoTatuajes> ConsultarCatalogoDeTatuajes();
        DTODetalleTatuaje ConsultarDetalleTatuaje(int idTatuaje);
        DTODetalleTatuaje ConsultarDetalleTatuajePorIdCita(Guid idCita);
    }
}
