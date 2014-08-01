using System.Web.Mvc;
using System.Web.Routing;

namespace NReddit
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "InfiniteScroll",
                url: "Home/InfiniteScroll/{pageNumber}",
                defaults: new { controller = "Home", action = "InfiniteScroll" }
            );
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
