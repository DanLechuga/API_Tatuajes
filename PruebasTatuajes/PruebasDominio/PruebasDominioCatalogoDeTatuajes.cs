using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using API_DominioTatuajes.Agregados;
namespace PruebasTatuajes.PruebasDominio
{
   public class PruebasDominioCatalogoDeTatuajes
    {
        [Fact]
        public void CatalogoDeTatuajes_Crear_CrearUnCatalogoDeTatuajes()
        {
            int FakeidCatlogo = 1;
            string FakeNombre = "Lobo";
            double FakePrecio = 254.30;
            CatalogoDeTatuajes catalogoDeTatuajes = CatalogoDeTatuajes.Crear(FakeidCatlogo,FakeNombre,FakePrecio);
            Assert.NotNull(catalogoDeTatuajes);
        }
    }
}
