using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BlogWebSite.Models.ViewModels
{
    public class BlogViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public CategoryViewModel Category { get; set; }
        public bool IsPublish { get; set; }
        public string? Poster { get; set; }
    }
}
