using AutoMapper;
using BlogWebSite.Core.DTOs;
using BlogWebSite.Core.Models;
using BlogWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebsite.Services
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Blog, BlogDto>().ReverseMap();
            CreateMap<Blog, BlogCreateDto>().ReverseMap();
            CreateMap<Blog, BlogUpdateDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<BlogUpdateViewModel, Blog>().ReverseMap();
            CreateMap<Blog, BlogViewModel>().ReverseMap();
            CreateMap<BlogCreateViewModel, Blog>().ReverseMap();
            CreateMap<BlogUpdateViewModel, Blog>().ReverseMap();
            CreateMap<CategoryViewModel, Category>().ReverseMap();
          
        }
    }
}
