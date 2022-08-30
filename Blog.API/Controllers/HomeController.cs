using AutoMapper;
using BlogWebSite.Models;
using BlogWebSite.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogWebSite.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        //private readonly IMapper _mapper;
        //private readonly IBlogRepository _blogRepository;

        //public HomeController(ILogger<HomeController> logger, IMapper mapper, IBlogRepository blogRepository)
        //{
        //    _logger = logger;
        //    _blogRepository = blogRepository;
        //    _mapper = mapper;
        //}


        //public IActionResult Index(int? page)
        //{
        //    var blogs = _mapper.Map<List<Blog>>(_blogRepository.GetAll());

        //    ViewData["Title"] = "Home Page";
        //    ViewBag.Blogs = _blogRepository.GetAll();
        //    int pageSize = 6;
        //    int pageNumber = (page ?? 1);
        //    return View(blogs.ToPagedList(pageNumber, pageSize));
        //}


        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        //public IActionResult About()
        //{

        //    return View();
        //}
        //public IActionResult Content()
        //{
        //    return View();
        //}
    }
}