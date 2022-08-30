using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BlogWebSite.Models.ViewModels
{
    public class BlogUpdateViewModel
    {

        [Remote(action: "AnyTitle", controller: "Blog")]

        [Required(ErrorMessage = "Başlık alanı boş olamaz")]
        public int Id { get; set; }
        public string Title { get; set; }

        [Required(ErrorMessage = "İçerik alanı boş olamaz")]
        public string Content { get; set; }


        [Required(ErrorMessage = "Kategory alanı boş olamaz")]
        public bool IsPublish { get; set; }
        public string? Poster { get; set; }
        public int CategoryId { get; set; }
        public IFormFile photo { get; set; }

    }
}
