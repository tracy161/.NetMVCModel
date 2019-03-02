using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();
            // how to define a custom route
            routes.MapRoute(
                "MoviesByReleaseYear",
                "Movies/released/{year}/{month}",
                // make default
                new {controller = "Movies", action = "ByReleaseYear" },
                // make 4 digits in year and 2 digits in month
                // @ = \
                new { year = @"\d{4}", month = @"\d{2}" });
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
