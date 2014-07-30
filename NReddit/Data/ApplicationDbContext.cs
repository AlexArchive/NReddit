using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using NReddit.Data.Model;

namespace NReddit.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Post> FeedItems { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
    }
}