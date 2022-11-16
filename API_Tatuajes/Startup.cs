
using API_Tatuajes.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace API_Tatuajes
{
    ///<Summary>StartUp</Summary>
    public class Startup
    {
        ///<Summary>Constructor StartUp</Summary>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        ///<Summary>Proerty configuration only read</Summary>
        public IConfiguration Configuration { get; }

        ///<Summary>This method gets called by the runtime. Use this method to add services to the container.</Summary> 
        
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddInyeccionDependencias(Configuration);

            services.AddMemoryCache();
            services.AddControllers(config => { config.Conventions.Add(new ControllerModelConvention()); })
                    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
            services.AddServiceSwagger();
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API_Tatuajes", Version = "v1" });
            //});

        }
        ///<Summary>This method gets called by the runtime. Use this method to configure the HTTP request pipeline.</Summary>
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
           
            

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            //app.UseDeveloperExceptionPage();
            app.UseExceptionHandler("/error");
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.AddSwaggerEndpointsPath(Configuration); });

            

        }
    }
}
