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
                name: "IndexTwoParametrs",
                url: "{controller}/{startDate}/{searchTerm}",
                defaults: new { controller = "EmployeesFulls", action = "Index", startDate = UrlParameter.Optional, searchTerm = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "IndexThreeParametrs",
                url: "{controller}/{startDate}/{startDate1}/{searchTerm}",
                defaults: new { controller = "EmployeesFulls", action = "About", startDate = UrlParameter.Optional, startDate1 = UrlParameter.Optional, searchTerm = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "SortByDate",
                url: "{controller}/{FilterOutTableAfterDate}/{startDate}",
                defaults: new { controller = "EmployeesFulls", action = "FilterOutTableAfterDate", startDate = UrlParameter.Optional, }
            );
            routes.MapRoute(
                name: "SearchForName",
                url: "{controller}/{action}/{searchTerm}",
                defaults: new { controller = "EmployeesFulls", action = "Index", searchTerm = UrlParameter.Optional, }
            );

            routes.MapRoute(
                name: "Default12",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );            
        }
    }
}
