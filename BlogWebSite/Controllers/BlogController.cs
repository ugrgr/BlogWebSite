using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BlogWebSite.Models;
using Microsoft.Extensions.FileProviders;
using BlogWebSite.Services;


namespace BlogWebSite.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var categoryList = _blogService.GetCategories().Result;

            ViewBag.selectList = new SelectList(categoryList, "Id", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult Create(BlogCreateViewModel request)
        {
            string base64ImageRepresentation = "";
            //Stream fileStream = request.Poster.OpenReadStream();

            //byte[] imageArray = System.IO.File.ReadAllBytes(request.Poster.FileName);
            //string base64ImageRepresentation = Convert.ToBase64String(fileStream.);
            if (request.Poster!=null)
            {
                var stream = new MemoryStream((int)request.Poster.OpenReadStream().Length);
                request.Poster.CopyTo(stream);
                var bytes = stream.ToArray();
                base64ImageRepresentation = Convert.ToBase64String(bytes);
            }
            

            var blogCreate = new BlogCreateModel();
            blogCreate.Title = request.Title;
            blogCreate.CategoryId = request.CategoryId;
            blogCreate.Content = request.Content;
            blogCreate.IsPublish = request.IsPublish;
            blogCreate.Poster = base64ImageRepresentation;

            _blogService.Create(blogCreate);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Update(int id)

        {
            var categoryList = _blogService.GetCategories().Result;

            ViewBag.selectList = new SelectList(categoryList, "Id", "Name");
            var blog = _blogService.GetById(id).Result;
            ViewBag.poster = blog.Poster;

            return View(blog);
        }

        [HttpPost]
        public IActionResult Update(BlogUpdateViewModel request)
        {
            string base64ImageRepresentation = "";
            if (request.Poster != null)
            {
                var stream = new MemoryStream((int)request.Poster.OpenReadStream().Length);
                request.Poster.CopyTo(stream);
                var bytes = stream.ToArray();
                base64ImageRepresentation = Convert.ToBase64String(bytes);
            }

            var blogUpdate = new BlogUpdateModel();
            blogUpdate.Id = request.Id;
            blogUpdate.Title = request.Title;
            blogUpdate.CategoryId = request.CategoryId;
            blogUpdate.Content = request.Content;
            blogUpdate.IsPublish = request.IsPublish;
            blogUpdate.Poster = base64ImageRepresentation;

            _blogService.Update(blogUpdate);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(int id)
        {

            if (id>0)
            {
                var response = _blogService.Delete(Convert.ToInt32(id)).Result;

                return RedirectToAction("Index", "Home");

            }
            return RedirectToAction("Index","Home") ;
            
        }

    }
}
