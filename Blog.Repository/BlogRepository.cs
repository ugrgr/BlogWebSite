using BlogWebSite.Core.DTOs;
using BlogWebSite.Core.Models;
using BlogWebSite.Repositories;
using System.Linq.Expressions;

namespace BlogWebSite.Repository
{

    public class BlogRepository : IBlogRepository
    {
        private readonly AppDbContext _context;

        public BlogRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }
        
        public Blog Create(Blog blog)
        {
            _context.Blogs.Add(blog);
            return blog;
        }

        public void Delete(int id)
        {
            var blog = _context.Blogs.Find(id);
            _context.Blogs.Remove(blog);
        }

        public List<Blog> GetAll()
        {
            return _context.Blogs.ToList();
        }

        public Blog? GetById(int id)
        {
            var blog = _context.Blogs.Find(id);
            return blog;
        }

        public void Update(Blog blog)
        {
            _context.Update(blog);
        }

        public bool Any(Expression<Func<Blog, bool>> predicate)
        {

            return _context.Blogs.Any(predicate);
        }

    }
}
