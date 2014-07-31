using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace NReddit.Data.Model
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Post> PostsVotedOn { get; set; }
    }
}