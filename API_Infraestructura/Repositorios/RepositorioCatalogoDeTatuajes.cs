using API_Comun;
using API_DominioTatuajes.Agregados;
using API_Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace API_Infraestructura.Repositorios
{
    class DTOCatalogoDeTatuajes
    {
        public int id_Tatuaje { get; set; }
        public string nombreTatuaje { get; set; }
        public double precioTatuaje { get; set; }
        
    }
    public class RepositorioCatalogoDeTatuajes : IRepositorioCatalogoDeTatuajes
    {
        public IUnidadDeTrabajo UnidadDeTrabajo { get;  }
        public RepositorioCatalogoDeTatuajes(IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.UnidadDeTrabajo = unidadDeTrabajo;
        }
        public IEnumerable<CatalogoDeTatuajes> ConsultarCatalogoDeTatuajes()
        {
            List<CatalogoDeTatuajes> catalogoDeTatuajes = new();
            CommandDefinition command = new("ConsultarCatalogoDeTatuajes", commandType: System.Data.CommandType.StoredProcedure, commandTimeout: 0);
            IEnumerable<DTOCatalogoDeTatuajes> dTOCatalogoDeTatuajes = UnidadDeTrabajo.SqlConnection.Query<DTOCatalogoDeTatuajes>(command);
            if (!dTOCatalogoDeTatuajes.Any()) throw new ArgumentNullException("No se encontro registro en el catalogo");
            foreach (var item in dTOCatalogoDeTatuajes)
            {
               catalogoDeTatuajes.Add(CatalogoDeTatuajes.Crear(item.id_Tatuaje, item.nombreTatuaje, item.precioTatuaje));
            }
            return catalogoDeTatuajes;
        }

        public DetalleDeTatuaje ConsultarDetalleTatuaje(int idTatuaje)
        {
            DetalleDeTatuaje detalle;            
            DynamicParameters parameters = new();
            parameters.Add("@idTatuaje", idTatuaje, System.Data.DbType.Int32);
            CommandDefinition command = new("ConsultarDetalleTatuaje",parameters, commandType: System.Data.CommandType.StoredProcedure, commandTimeout: 0);
            DTOCatalogoDeTatuajes dTOCatalogoDeTatuajes = UnidadDeTrabajo.SqlConnection.QueryFirstOrDefault<DTOCatalogoDeTatuajes>(command);
            if (dTOCatalogoDeTatuajes is null) return null;
            detalle = DetalleDeTatuaje.Crear(dTOCatalogoDeTatuajes.id_Tatuaje, dTOCatalogoDeTatuajes.nombreTatuaje, dTOCatalogoDeTatuajes.precioTatuaje);
            return detalle;
        }

        
    }
}
