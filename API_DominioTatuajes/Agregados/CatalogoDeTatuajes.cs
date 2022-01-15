using API_Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_DominioTatuajes.Agregados
{
   public class CatalogoDeTatuajes : Agregado
    {
        
        public string NombreTatuaje { get; set; }
        public double PrecioTatuaje { get; set; }
        private CatalogoDeTatuajes(int idCatalogo, string nombretatuaje, double precioTatuaje)
        {
            this.ID = idCatalogo;
            this.NombreTatuaje = nombretatuaje;
            this.PrecioTatuaje = precioTatuaje;
        }
        public static CatalogoDeTatuajes Crear(int idCatalogo, string nombretatuaje, double precioTatuaje)
        {
            return new CatalogoDeTatuajes(idCatalogo,nombretatuaje,precioTatuaje);
        }
    }
}
