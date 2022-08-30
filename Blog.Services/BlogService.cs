using AutoMapper;
using BlogWebSite.Core;
using BlogWebSite.Core.DTOs;
using BlogWebSite.Core.Models;
using BlogWebSite.Core.Services;
using BlogWebSite.Repositories;
using BlogWebSite.Repository;

namespace BlogWebsite.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public BlogService(IBlogRepository blogRepository, AppDbContext dbContext,IMapper mapper)
        {
            _blogRepository = blogRepository;
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public CustomResponse<BlogDto> Create(BlogCreateDto request)
        {
            var newBlog = _mapper.Map<Blog>(request);
            _blogRepository.Create(newBlog);
            if (newBlog.Poster == "")
            {
                _dbContext.Entry(newBlog).Property(x => x.Poster).IsModified = false;
            }
            _dbContext.SaveChanges();

            var newBlogDto = _mapper.Map<BlogDto>(newBlog);

            return CustomResponse<BlogDto>.Success(newBlogDto, 201);
        }

        

        public CustomResponse<string> Delete(int id)
        {

            //if (!_blogRepository.Any(x => x.Id == id))
            //{
            //    return CustomResponse<string>.Fail($"Id'si {id} olan ürün bulunamamıştır", 404);

            //}

            _blogRepository.Delete(id);
            _dbContext.SaveChanges();

            return CustomResponse<string>.Success(String.Empty, 204);
        }

        public CustomResponse<List<Blog>> GetAll()
        {
            var blogs = _blogRepository.GetAll();

            return CustomResponse<List<Blog>>.Success(blogs, 200);
        }

        public CustomResponse<List<Category>> GetCategories()
        {
            var categories = _blogRepository.GetCategories();

            return CustomResponse<List<Category>>.Success(categories,200);
        }

        public CustomResponse<Blog> GetById(int id)
        {
            var blog= _blogRepository.GetById(id);

            return CustomResponse<Blog>.Success(blog, 200);
        }

        public CustomResponse<BlogUpdateDto> Update(BlogUpdateDto request)
        {
            var newBlog = _mapper.Map<Blog>(request);
            _blogRepository.Update(newBlog);
            if (newBlog.Poster=="")
            {
                _dbContext.Entry(newBlog).Property(x => x.Poster).IsModified = false;
            }
            _dbContext.SaveChanges();

            var newBlogDto = _mapper.Map<BlogUpdateDto>(newBlog);

            return CustomResponse<BlogUpdateDto>.Success(newBlogDto, 201);
        }

    }
}
