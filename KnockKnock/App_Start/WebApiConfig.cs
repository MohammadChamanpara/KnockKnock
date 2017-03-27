using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace ReadifyKnockKnock
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            GlobalConfiguration.Configuration.Formatters.Clear();
            GlobalConfiguration.Configuration.Formatters.Add(new JsonMediaTypeFormatter());
            GlobalConfiguration.Configuration.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.LocalOnly;

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute
            (
               name: "DefaultApi",
               routeTemplate: "api/{controller}/{action}",
               defaults: new { action = RouteParameter.Optional }
            );

           
        }
    }
}
