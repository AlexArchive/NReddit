using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NReddit.Database.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Tagline { get; set; }

        [Required]
        public string Link { get; set; }

        public int Votes { get; set; }

        public virtual ICollection<User> UsersWhoVoted { get; set; }
    }
}