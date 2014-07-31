using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;
using NReddit.Data;
using NReddit.Data.Model;

namespace NReddit
{   
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Database.SetInitializer(new MyClass());
        }
    }

    public class MyClass : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            context.Posts.Add(new Post { Title = "Google", Link = "http://www.google.com",Tagline = "Awesome search engine."});
            context.Posts.Add(new Post { Title = "Facebook", Link = "http://www.facebook.com",Tagline="Best social media website." });
            context.Posts.Add(new Post { Title = "Twitter", Link = "http://www.twitter.com",Tagline="The real best social media website."});
            context.Posts.Add(new Post { Title = "YouTube", Link = "http://www.youtube.com",Tagline="Share videos with your friends." });

            context.SaveChanges();
        }
    }
}
