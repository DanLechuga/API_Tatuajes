using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Linq;

namespace API_Tatuajes.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public class ControllerModelConvention : IControllerModelConvention
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="controller"></param>
        public void Apply(ControllerModel controller)
        {
            #region Custom controller name

            if (controller == null)
                return;

            foreach (var attr in controller.Attributes)
            {
                if (attr.GetType() == typeof(RouteAttribute))
                {
                    var routeAttr = (RouteAttribute)attr;
                    if (!string.IsNullOrEmpty(routeAttr.Name))
                        controller.ControllerName = routeAttr.Name;
                }
            }

            #endregion

            #region versionamiento de api

            var namespaceController = controller.ControllerType.Namespace;
            var apiVersion = namespaceController.Split(".").Last().ToLower();
            controller.ApiExplorer.GroupName = apiVersion;
            #endregion
        }
    }
}
