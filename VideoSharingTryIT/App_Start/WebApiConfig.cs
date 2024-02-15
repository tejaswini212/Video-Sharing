using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace VideoSharingTryIT
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}"
            );

            //config.Routes.MapHttpRoute(
            //    name: "Like",
            //    routeTemplate: "api/{controller}/Like/{id}",
            //    defaults: new { controller = "Video", Action = "Like" }
            //);
        }
    }
}
