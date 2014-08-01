using System.Data.Entity;
using NReddit.Database.Models;

namespace NReddit.Database
{
    public class ApplicationInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            context.Posts.Add(new Post
            {
                Title   = "Google", 
                Link    = "http://www.google.com", 
                Tagline = "Awesome search engine."
            });

            context.Posts.Add(new Post
            {
                Title   = "Facebook",
                Link    = "http://www.facebook.com",
                Tagline = "Social network."
            });

            context.Posts.Add(new Post
            {
                Title   = "YouTube",
                Link    = "http://www.youtube.com",
                Tagline = "Check out this cat video."
            });

            context.Posts.Add(new Post
            {
                Title   = "Runescape",
                Link    = "http://www.runscape.com",
                Tagline = "Simply the best MMORPG."
            });

            context.Posts.Add(new Post
            {
                Title   = "Google",
                Link    = "http://www.google.com",
                Tagline = "Awesome search engine."
            });

            context.Posts.Add(new Post
            {
                Title   = "Facebook",
                Link    = "http://www.facebook.com",
                Tagline = "Social network."
            });

            context.Posts.Add(new Post
            {
                Title   = "YouTube",
                Link    = "http://www.youtube.com",
                Tagline = "Check out this cat video."
            });

            context.Posts.Add(new Post
            {
                Title   = "Runescape",
                Link    = "http://www.runscape.com",
                Tagline = "Simply the best MMORPG."
            });

            context.Posts.Add(new Post
            {
                Title   = "Google",
                Link    = "http://www.google.com",
                Tagline = "Awesome search engine."
            });

            context.Posts.Add(new Post
            {
                Title   = "Facebook",
                Link    = "http://www.facebook.com",
                Tagline = "Social network."
            });

            context.Posts.Add(new Post
            {
                Title   = "YouTube",
                Link    = "http://www.youtube.com",
                Tagline = "Check out this cat video."
            });

            context.Posts.Add(new Post
            {
                Title   = "Runescape",
                Link    = "http://www.runscape.com",
                Tagline = "Simply the best MMORPG."
            });

            context.Posts.Add(new Post
            {
                Title   = "Google",
                Link    = "http://www.google.com",
                Tagline = "Awesome search engine."
            });

            context.Posts.Add(new Post
            {
                Title   = "Facebook",
                Link    = "http://www.facebook.com",
                Tagline = "Social network."
            });

            context.Posts.Add(new Post
            {
                Title   = "YouTube",
                Link    = "http://www.youtube.com",
                Tagline = "Check out this cat video."
            });

            context.Posts.Add(new Post
            {
                Title   = "Runescape",
                Link    = "http://www.runscape.com",
                Tagline = "Simply the best MMORPG."
            });

            context.Posts.Add(new Post
            {
                Title   = "Google",
                Link    = "http://www.google.com",
                Tagline = "Awesome search engine."
            });

            context.Posts.Add(new Post
            {
                Title   = "Facebook",
                Link    = "http://www.facebook.com",
                Tagline = "Social network."
            });

            context.Posts.Add(new Post
            {
                Title   = "YouTube",
                Link    = "http://www.youtube.com",
                Tagline = "Check out this cat video."
            });

            context.Posts.Add(new Post
            {
                Title   = "Runescape",
                Link    = "http://www.runscape.com",
                Tagline = "Simply the best MMORPG."
            });

            context.SaveChanges();
        }
    }
}