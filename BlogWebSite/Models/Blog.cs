using BlogWebSite.Models.ViewModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogWebSite.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public Category Category { get; set; }
        public int? CategoryId { get; set; }
        public bool IsPublish { get; set; }
        public string? Poster { get; set; }
    }
}
