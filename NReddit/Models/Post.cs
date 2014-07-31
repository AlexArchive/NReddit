namespace NReddit.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Tagline { get; set; }
        public string Link { get; set; }
        public int Score { get; set; }
        public bool Voted { get; set; }
    }
}