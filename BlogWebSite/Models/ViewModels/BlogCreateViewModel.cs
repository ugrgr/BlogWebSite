using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BlogWebSite.Models.ViewModels
{
    public class BlogCreateViewModel
    {

        [Remote(action: "AnyTitle",controller:"Blog")]
       
        [Required(ErrorMessage = "Title alanı boş olamaz")]
        public string Title { get; set; }

        [Required(ErrorMessage = "İçerik alanı boş olamaz")]
        public string Content { get; set; }


        [Required(ErrorMessage ="Kategory alanı boş olamaz")]
        public int CategoryId { get; set; }
        public bool IsPublish { get; set; }
        public string? Poster { get; set; }
        public IFormFile photo { get; set; }
    }
}
