using API_DominioTatuajes.Agregados;
using API_Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasTatuajes.PruebasInfraestructura
{
   public class MockRepositorioCatalogoDeTatuajes : IRepositorioCatalogoDeTatuajes
    {
        public List<CatalogoDeTatuajes> ListaCatalogos { get; set; }
        public MockRepositorioCatalogoDeTatuajes()
        {
            ListaCatalogos = new();
            ListaCatalogos.Add(CatalogoDeTatuajes.Crear(1,"Lobo",230.60));
            ListaCatalogos.Add(CatalogoDeTatuajes.Crear(2, "Rosas", 256.60));
            ListaCatalogos.Add(CatalogoDeTatuajes.Crear(3, "Letras", 560.60));
            ListaCatalogos.Add(CatalogoDeTatuajes.Crear(4, "Hojas", 780.60));
            ListaCatalogos.Add(CatalogoDeTatuajes.Crear(5, "Ramos", 150.60));
        }

        public IEnumerable<CatalogoDeTatuajes> ConsultarCatalogoDeTatuajes()
        {
            return ListaCatalogos;
        }
    }
}
