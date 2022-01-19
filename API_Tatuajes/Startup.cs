using API_Aplicacion.Implementacion;
using API_Aplicacion.Interfaces;
using API_Comun;
using API_Infraestructura.Interfaces;
using API_Infraestructura.Repositorios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Tatuajes
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
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
            
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API_Tatuajes", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API_Tatuajes v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
