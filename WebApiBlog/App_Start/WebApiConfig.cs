using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BlogSite
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            EnableCorsAttribute attr = new EnableCorsAttribute("http://localhost:2890/","*","*");
            config.EnableCors(attr);
               

            // Web API routes
            config.MapHttpAttributeRoutes();
        
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
