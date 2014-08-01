using System.ComponentModel.DataAnnotations;

namespace NReddit.Models
{
    public class PostInputModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Title { get; set; }
        
        [Required]
        [MinLength(10)]
        [MaxLength(25)]
        public string Tagline { get; set; }

        [Url]
        [Required]
        public string Link { get; set; }
    }
}