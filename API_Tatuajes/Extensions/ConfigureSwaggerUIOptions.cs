using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace API_Tatuajes.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class ConfigureSwaggerUIOptions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>        
        /// <returns></returns>
        public static SwaggerUIOptions AddSwaggerEndpointsPath(this SwaggerUIOptions c)
        {
            //string pahtCssSwagger = configuration.GetSection("custom-swagger-ui").Value;
            //string virtualDirectory = configuration.GetSection("VirtualDirectory").Value;

            c.SwaggerEndpoint(SwaggerConst.PathCitas, SwaggerConst.CitasServiceTitle);
            c.SwaggerEndpoint(SwaggerConst.PathUsuarios, SwaggerConst.UsuariosServiceTitle);
            c.SwaggerEndpoint(SwaggerConst.PathCatalogo, SwaggerConst.CatalogoServiceTitle);
            c.SwaggerEndpoint(SwaggerConst.PathNotificaciones, SwaggerConst.NotificacionesServiceTitle);
            c.SwaggerEndpoint(SwaggerConst.PathSessiones, SwaggerConst.SessionsServiceTitle);
            c.SwaggerEndpoint(SwaggerConst.PathTest, SwaggerConst.TestServiceTitle);
            c.SwaggerEndpoint(SwaggerConst.PathTatuador, SwaggerConst.TatuadorServiceTitle);
            c.SwaggerEndpoint(SwaggerConst.PathCreador,SwaggerConst.CreadorServiceTitle);

//#if DEBUG
//            pahtCssSwagger = pahtCssSwagger.Replace(virtualDirectory, string.Empty);
//#endif

//            c.InjectStylesheet(pahtCssSwagger);
            return c;
        }
    }
}
