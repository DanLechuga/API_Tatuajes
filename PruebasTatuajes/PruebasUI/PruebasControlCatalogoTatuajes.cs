using API_Aplicacion.AutoMap;
using API_Aplicacion.Implementacion;
using API_Aplicacion.Interfaces;
using API_Infraestructura.Interfaces;
using API_Tatuajes.AutoMap;
using API_Tatuajes.Controllers;
using API_Tatuajes.Controllers.catalogo;
using AutoMapper;
using PruebasTatuajes.PruebasInfraestructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PruebasTatuajes.PruebasUI
{
   public class PruebasControlCatalogoTatuajes
    {
        public CatalogoDeTatuajesController CatalogoDeTatuajes { get;  }
        public IServicioError ServicioError { get;  }
        public IRepositorioError RepositorioError { get; set; }
        public IServicioCatalogoDeTatuajes ServicioCatalogoDeTatuajes { get;  }
        public IMapper Mapper { get; set; }
        public IRepositorioCatalogoDeTatuajes RepositorioCatalogoDeTatuajes { get;  }
        public IRepositorioTatuajeCita  RepositorioTatuajeCita { get;  }
        public PruebasControlCatalogoTatuajes()
        {
            if (Mapper is null)
            {
                var mapperConfig = new MapperConfiguration(
                    mc => {
                        mc.AddProfile(new ModelToDto());
                        mc.AddProfile(new DomainToDto());
                    }
                );
                IMapper mapper = mapperConfig.CreateMapper();
                this.Mapper = mapper;
            }
            this.RepositorioCatalogoDeTatuajes = new MockRepositorioCatalogoDeTatuajes();
            this.RepositorioTatuajeCita = new MockRepositorioTatuajeCita();
            this.RepositorioError = new MockRepositorioError();
            this.ServicioError = new ServicioError(RepositorioError);
            this.ServicioCatalogoDeTatuajes = new ServicioCatalogoDeTatuajes(RepositorioCatalogoDeTatuajes,RepositorioTatuajeCita,Mapper);
            this.CatalogoDeTatuajes = new CatalogoDeTatuajesController(ServicioCatalogoDeTatuajes,ServicioError);
        }
    
        [Fact]
        public void ConsultaDeCatalogo_CatalogoControl_ConsultaTodoElCatalogo()
        {
            var response = CatalogoDeTatuajes.ConsultarCatalogoTatuajes();
            Assert.Equal(200,response.StatusCode);
            
        }
        [Fact]
        public void ConsultaDeCatalogo_CatalogoControl_ConsultaDetalleTatuajeCorrecto()
        {
            var response = CatalogoDeTatuajes.ConsultarDetalleTatuaje(1);
            Assert.Equal(200,response.StatusCode);
        }
        [Fact]
        public void ConsultaDeCatalogo_CatalogoControl_ConsultaDetalleTatuajeIdInexistente()
        {
            var response = CatalogoDeTatuajes.ConsultarDetalleTatuaje(10);
            Assert.Equal(409,response.StatusCode);
        }
        [Fact]
        public void ConsultaDeCatalogo_CatalogoControl_ConsultaDEtallePorCitaCorrecto()
        {
            Guid idCita = Guid.Parse("00000000-0000-0000-0000-000000000001");
            var response = CatalogoDeTatuajes.ConsultarDetalleTatuajePorIdCita(idCita);
            Assert.Equal(200,response.StatusCode);
        }
    }
}
