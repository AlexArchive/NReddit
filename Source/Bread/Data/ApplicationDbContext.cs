using System.Data.Entity;
using Bread.Data.Model;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Bread.Data
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