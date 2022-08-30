using Microsoft.AspNetCore.Mvc;

namespace BlogWebSite.Models
{
    public class BlogViewModel
    {

        public int Id { get; set; }

       
        public string Title { get; set; }

        public string Poster { get; set; }

        public string Content { get; set; }

        public bool IsPublish { get; set; }
        public CategoryViewModel Category { get; set; }
    }
}
