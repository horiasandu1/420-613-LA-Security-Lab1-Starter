using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SecurityLab1_Starter
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
             name: "New",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
             );


            routes.MapRoute(
             name: "Original",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
             );

            routes.MapRoute(
               name: "Home",
               url: "Home/{action}",
               defaults: new { controller = "Home", action = "Index" },
               constraints: new { action = "Index|Contact|About|GenError" }
           );

                        /*

            routes.MapRoute(
                name: "EmptyUrl",
                url: "",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Home",
                url: "Home/{action}",
                defaults: new { controller = "Home", action = "Index" },
                constraints: new {action = "Index|Contact|About"}
            );

            routes.MapRoute(
                name: "Inventory/Index",
                url: "Inventory/{action}",
                defaults: new { controller = "Inventory", action = "Index"},
                constraints: new { action = "Index" }
            );

     
            routes.MapRoute(
            name: "NotFound",
            url: "{*url}",
            defaults: new { controller = "Error", action = "NotFound", id = UrlParameter.Optional }
            );
            */
        }
    }
}
