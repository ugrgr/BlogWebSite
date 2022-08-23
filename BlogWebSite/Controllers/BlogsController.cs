using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BlogWebSite.Filters;
using BlogWebSite.Models;
using BlogWebSite.Models.ViewModels;
using BlogWebSite.Repositories;
using Microsoft.Extensions.FileProviders;

namespace BlogWebSite.Controllers
{
    public class BlogController : Controller
    {

        private readonly IBlogRepository _blogRepository;

        private readonly IMapper _mapper;
        private readonly IFileProvider fileProvider;

        public BlogController(IBlogRepository blogRepository, IMapper mapper, IFileProvider fileProvider)
        {

            _blogRepository = blogRepository;
            _mapper = mapper;
            this.fileProvider = fileProvider;
        }

        public IActionResult Index()
        {

            var blogs = _blogRepository.GetAll();
            var tableName = "Ürünler";

            var blogListViewModel = _mapper.Map<List<BlogViewModel>>(blogs);

            return View(new IndexPageViewModel() { blogs = blogListViewModel, TableName = tableName });
        }

        [HttpGet]
        public IActionResult Create()

        {

            var categoryList = _blogRepository.GetCategories();

            ViewBag.selectList = new SelectList(categoryList, "Id", "Name");




            return View();
        }

        [HttpPost]
        public IActionResult Create(BlogCreateViewModel request)
        {
            if (!ModelState.IsValid)
            {
                var categoryList = _blogRepository.GetCategories();

                ViewBag.selectList = new SelectList(categoryList, "Id", "Name");

                return View(request);
            }

            var imagePath = SavePhoto(request.photo);
     

            var newBlog = _mapper.Map<Blog>(request);
            newBlog.Poster = imagePath;
            _blogRepository.Create(newBlog);
            return RedirectToAction("Index", "Home");


        }
        public string SavePhoto(IFormFile photo)
        {
            if (photo != null && photo.Length > 0)
            {
                var root = fileProvider.GetDirectoryContents("wwwroot");
                var picturesDirectory = root.Single(x => x.Name == "pictures");
                var path = Path.Combine(picturesDirectory.PhysicalPath, photo.FileName);
                using var stream = new FileStream(path, FileMode.Create);

                photo.CopyToAsync(stream);

            }
            return photo.FileName;
        }
        public string UpdatePhoto(IFormFile photo)
        {
            if (photo != null && photo.Length > 0)
            {
                var root = fileProvider.GetDirectoryContents("wwwroot");
                var picturesDirectory = root.Single(x => x.Name == "pictures");
                var path = Path.Combine(picturesDirectory.PhysicalPath, photo.FileName);
                using var stream = new FileStream(path, FileMode.Open);

                photo.CopyToAsync(stream);

            }
            return photo.FileName;
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        public IActionResult Update(int id)

        {
            var categoryList = _blogRepository.GetCategories();

            ViewBag.selectList = new SelectList(categoryList, "Id", "Name");

            var blogUpdateViewModel = _mapper.Map<BlogUpdateViewModel>(_blogRepository.GetById(id));


            return View(blogUpdateViewModel);
        }
        public IActionResult List()
        {
            
        //    _mapper.Map<BlogListViewModel>(_blogRepository.GetAll());
            return View(_blogRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Update(BlogUpdateViewModel request)

        {
            if (!ModelState.IsValid)
            {

                var categoryList = _blogRepository.GetCategories();

                ViewBag.selectList = new SelectList(categoryList, "Id", "Name");
                return View();
            }

            var imagePath = SavePhoto(request.photo);

            _blogRepository.Update(_mapper.Map<Blog>(request));

            return RedirectToAction("Index", "Home");
        }



        [ServiceFilter(typeof(NotFoundFilter))]
        public IActionResult Delete(int id)
        {
            //Id'ye data varmı yokmu
            _blogRepository.Delete(id);
            //silme
            return RedirectToAction("Index", "Home");
        }



        public IActionResult AnyBlogTitle(string Title)
        {

            var anyBlog = _blogRepository.Any(x => x.Title.ToLower() == Title.ToLower());

            if (anyBlog)
            {
                return Json("Ürün ismi veritabanında bulunmaktadır.");
            }

            return Json(true);

        }

        public IActionResult AnyProductNameWithUpdate(string Title, int Id)
        {
            var anyBlog = _blogRepository.Any(x => x.Title.ToLower() == Title.ToLower() && x.Id != Id);

            if (anyBlog)
            {
                return Json("Ürün ismi veritabanında bulunmaktadır.");
            }
            return Json(true);

        }
    }
}
