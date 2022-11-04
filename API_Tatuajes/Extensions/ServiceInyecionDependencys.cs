using Microsoft.Extensions.DependencyInjection;
using API_Aplicacion.Implementacion;
using API_Aplicacion.Interfaces;
using API_Comun;
using API_Infraestructura.Interfaces;
using API_Infraestructura.Repositorios;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using System;

namespace API_Tatuajes.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class ServiceInyecionDependencys
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddInyeccionDependencias(this IServiceCollection service,IConfiguration configuration)
        {
            service.DependencyInjection(configuration);
            return service;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddServiceSwagger(this IServiceCollection services) {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(SwaggerConst.SwaggerDocCitas, new OpenApiInfo { Title = SwaggerConst.CitasServiceTitle, Version = SwaggerConst.ServiceVersion });
                c.SwaggerDoc(SwaggerConst.SwaggerDocUsuarios,new OpenApiInfo { Title = SwaggerConst.UsuariosServiceTitle,Version = SwaggerConst.ServiceVersion});
                c.SwaggerDoc(SwaggerConst.SwaggerDocCatalogo, new OpenApiInfo { Title = SwaggerConst.CatalogoServiceTitle, Version = SwaggerConst.ServiceVersion });
                c.SwaggerDoc(SwaggerConst.SwaggerDocNotificaciones, new OpenApiInfo { Title = SwaggerConst.NotificacionesServiceTitle, Version = SwaggerConst.ServiceVersion });
                c.SwaggerDoc(SwaggerConst.SwaggerDocSession, new OpenApiInfo { Title = SwaggerConst.SessionsServiceTitle, Version = SwaggerConst.ServiceVersion });
                c.SwaggerDoc(SwaggerConst.SwaggerDocTest, new OpenApiInfo { Title = SwaggerConst.TestServiceTitle, Version = SwaggerConst.ServiceVersion });
                c.CustomSchemaIds(x => x.Name.Replace("Dto", string.Empty));

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}{SwaggerConst.SwaggerExtensionXml}";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            return services;
        }

        private static IServiceCollection DependencyInjection(this IServiceCollection services,IConfiguration Configuration)
        {
            services.AddTransient<IUnidadDeTrabajo>(unidad => new UnidadDetrabajo(Configuration.GetConnectionString("Base1")));
            services.AddTransient<IRepositorioUsuario, RepositorioUsuario>();
            services.AddTransient<IRepositorioCliente, RepositorioCliente>();
            services.AddTransient<IRepositorioSession, RepositorioSession>();
            services.AddTransient<IRepositorioError, RepositorioError>();
            services.AddTransient<IRepositorioCita, RepositorioCita>();
            services.AddTransient<IRepositorioClienteCita, RepositorioClienteCita>();
            services.AddTransient<IRepositorioCatalogoDeTatuajes, RepositorioCatalogoDeTatuajes>();
            services.AddTransient<IRepositorioNotificaciones, RepositorioNotificaciones>();
            services.AddTransient<IRepositorioTatuador, RepositorioTatuador>();
            services.AddTransient<IRepositorioTatuadorCita, RepositorioTatuadorCita>();
            services.AddTransient<IRepositorioTatuajeCita, RepositorioTatuajeCita>();
            services.AddTransient<IServicioNotificaciones, ServicioNotificaciones>();
            services.AddTransient<IServicioDeCitas, ServicioCitas>();
            services.AddTransient<IServicioError, ServicioError>();
            services.AddTransient<IServicioSession, ServicioSession>();
            services.AddTransient<IServicioCatalogoDeTatuajes, ServicioCatalogoDeTatuajes>();
            services.AddTransient<IServicioValidacionUsuarios, ServicioValidacionUsuarios>();
            return services;
        }
    }
}
