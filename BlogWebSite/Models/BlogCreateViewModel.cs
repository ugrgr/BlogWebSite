using System.ComponentModel.DataAnnotations;

namespace BlogWebSite.Models
{
    public class BlogCreateViewModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public bool IsPublish { get; set; }

        public IFormFile Poster { get; set; }

        public int CategoryId { get; set; }
    }
}
