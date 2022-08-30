using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebSite.Core.DTOs
{
    public class BlogUpdateDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int CategoryId { get; set; }
        public bool IsPublish { get; set; }
        public string? Poster { get; set; }
    }
}
