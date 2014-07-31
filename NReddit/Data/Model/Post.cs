using System.Collections.Generic;

namespace NReddit.Data.Model
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Tagline { get; set; }
        public string Link { get; set; }
        public int Score { get; set; }
        public virtual ICollection<ApplicationUser> UsersWhoVoted { get; set; }
    }
}