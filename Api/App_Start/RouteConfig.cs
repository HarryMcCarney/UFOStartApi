using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UFOStart.Api
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            "ADMIN", // Route name
            "{versionNo}/admin/{controller}/{action}/{id}", // URL with parameters
            new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            new[] { "UFOStart.Api.Controllers.Admin" });


            routes.MapRoute(
             "WEB", // Route name
             "{versionNo}/web/{controller}/{action}/{id}", // URL with parameters
             new { controller = "Home", action = "Index", id = UrlParameter.Optional },
             new[] { "UFOStart.Api.Controllers.Web" });


        }
    }
}