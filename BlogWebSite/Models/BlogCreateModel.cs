namespace BlogWebSite.Models
{
    public class BlogCreateModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public bool IsPublish { get; set; }

        public string Poster { get; set; }

        public int CategoryId { get; set; }
    }
}
