using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DisplayEmployees
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "EmployeesFulls", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(

"Citysearch",

"Find/{Country}/{state}",

new { controller = "Home", action = " Find", Country = UrlParameter.Optional, state = UrlParameter.Optional }

);
            routes.MapRoute(
                name: "Default12",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            
        }
    }
}
