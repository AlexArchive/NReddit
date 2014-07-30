using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Bread.Data;
using Bread.Data.Model;

namespace Bread
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

    public class MyClass : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            context.FeedItems.Add(new Post { Title = "Google", Link = "http://www.google.com",Tagline = "Awesome search engine."});
            context.FeedItems.Add(new Post { Title = "Facebook", Link = "http://www.facebook.com",Tagline="Best social media website." });
            context.FeedItems.Add(new Post { Title = "Twitter", Link = "http://www.twitter.com",Tagline="The real best social media website."});
            context.FeedItems.Add(new Post { Title = "YouTube", Link = "http://www.youtube.com",Tagline="Share videos with your friends." });

            context.SaveChanges();
        }
    }
}
