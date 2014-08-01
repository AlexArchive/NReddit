using System.Web.Mvc;
using System.Web.Routing;
using NReddit.Database;

namespace NReddit
{   
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);
            System.Data.Entity.Database.SetInitializer(new ApplicationInitializer());
        }

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
