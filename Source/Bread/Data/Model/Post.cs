namespace Bread.Data.Model
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Tagline { get; set; }
        public string Link { get; set; }
        public int Votes { get; set; }
    }
}