using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BlogWebSite.Models
{
    public class BlogUpdateViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public bool IsPublish { get; set; }
        public IFormFile Poster { get; set; }
        public int CategoryId { get; set; }
        
    }
}
