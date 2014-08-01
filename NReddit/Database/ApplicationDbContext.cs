using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using NReddit.Database.Models;

namespace NReddit.Database
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Post> Posts { get; set; }
 
        public ApplicationDbContext()
            : base("NReddit")
        {
        }
    }
}