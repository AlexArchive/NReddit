using Microsoft.AspNet.Identity.EntityFramework;
using NReddit.Data.Model;
using System.Data.Entity;

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