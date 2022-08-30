using System.ComponentModel.DataAnnotations;

namespace BlogWebSite.Models
{
    public class BlogUpdateModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsPublish { get; set; }
        public string Poster { get; set; }
        public int CategoryId { get; set; }
    }
}
