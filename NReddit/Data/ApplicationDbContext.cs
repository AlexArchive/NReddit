using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using NReddit.Data.Model;

namespace NReddit.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Post> Posts { get; set; }

        public ApplicationDbContext()
            : base("NReddit")
        {
        }
    }
}