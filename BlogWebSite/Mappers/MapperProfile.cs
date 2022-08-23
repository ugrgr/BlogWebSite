using AutoMapper;
using BlogWebSite.Models;
using BlogWebSite.Models.ViewModels;

namespace BlogWebSite.Mappers
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Blog, BlogViewModel>().ReverseMap();
            CreateMap<BlogCreateViewModel, Blog>().ReverseMap();
            CreateMap<BlogUpdateViewModel, Blog>().ReverseMap();
            CreateMap<CategoryViewModel, Category>().ReverseMap();
            CreateMap<BlogListViewModel, Blog>().ReverseMap();

        }
    }
}
