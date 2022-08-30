using AutoMapper;
using BlogWebSite.Models;
using BlogWebSite.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using X.PagedList;

namespace BlogWebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogService _blogService;

        public HomeController(IBlogService blogService)
        {

            _blogService = blogService;
        }
        public IActionResult Index(int? page)
        {
            var blogs = _blogService.GetAll().Result;

            ViewData["Title"] = "Home Page";
            ViewBag.Blogs = blogs;
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(blogs.ToPagedList(pageNumber, pageSize));
        }
        public IActionResult About()
        {

            return View();
        }
        public IActionResult Content()
        {
            return View();
        }
    }
}