using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace NReddit.Database.Models
{
    public class User : IdentityUser
    {
        public virtual ICollection<Post> PostsVotedOn { get; set; }
    }
}