using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace API
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Default", action = "Index" }
            );

            routes.MapRoute(
                name: "AddGroup",
                url: "Groupe/Add/{token}",
                defaults: new { controller = "Groupe", action = "Add", token = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "DeleteGroup",
                url: "Groupe/Delete/{token}",
                defaults: new { controller = "Groupe", action = "Delete", token = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "UpdateGroup",
                url: "Groupe/Update/{token}",
                defaults: new { controller = "Groupe", action = "Update", token = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "LoadAllGroup",
                url: "Groupe/LoadAll/{token}",
                defaults: new { controller = "Groupe", action = "LoadAll", token = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "LoadGroup",
                url: "Groupe/Load/{token}",
                defaults: new { controller = "Groupe", action = "Load", token = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "LoadByGroup",
                url: "Groupe/LoadBy/{token}",
                defaults: new { controller = "Groupe", action = "LoadBy", token = UrlParameter.Optional }
            );

            #region User
            routes.MapRoute(
                    name: "Login",
                    url: "User/Login",
                    defaults: new { controller = "User", action = "Login" }
                ); 
            #endregion

        }
    }
}
