using System.Web.Mvc;
using System.Web.Routing;

namespace Patrimonio
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Marcas",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Marcas", action = "Index", id = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //    name: "Patrimonio",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Patrimonio", action = "Index", id = UrlParameter.Optional }
            //);

        }
    }
}
