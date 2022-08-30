using BlogWebSite.Core.DTOs;
using BlogWebSite.Core.Models;
using BlogWebSite.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace BlogWebSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        private readonly IFileProvider fileProvider;

        public BlogController(IBlogService blogService)
        {

            _blogService = blogService;
            this.fileProvider = fileProvider;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(BlogCreateDto request)
        {
            var response = _blogService.Create(request);
            return new ObjectResult(response) { StatusCode = response.Status };
        }

        [HttpGet()]
        [Route("getcategories")]
        public IActionResult GetCategories()
        {
            var response = _blogService.GetCategories();
            return new ObjectResult(response) { StatusCode = response.Status };
        }


        [HttpGet]
        [Route("list")]
        public IActionResult GetAll()
        {
            var response = _blogService.GetAll();
            return new ObjectResult(response) { StatusCode = response.Status };
        }
        [HttpGet("{id}")]
        public  IActionResult GetById(int id)
        {
            var response = _blogService.GetById(id);

            return new ObjectResult(response) { StatusCode = response.Status };
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Update(BlogUpdateDto request)
        {
            var response = _blogService.Update(request);
            return new ObjectResult(response) { StatusCode = response.Status };
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var response = _blogService.Delete(id);
            return new ObjectResult(response) { StatusCode = response.Status };
        }
    }
}
