using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using BlogWebSite.Models;

namespace BlogWebSite.Repositories
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
            _context.SaveChanges();
            return blog;
            
                
        }

        public void Delete(int id)
        {


            var blog = _context.Blogs.Find(id);
            _context.Blogs.Remove(blog);
            _context.SaveChanges();
        }

        public List<Blog> GetAll()
        {
            return _context.Blogs.Include(x => x.Category).ToList();
        }

        public Blog? GetById(int id)
        {
            return _context.Blogs.Find(id);
        }

        public void Update(Blog blog)
        {
            _context.Update(blog);
            _context.SaveChanges();
        }

        public bool Any(Expression<Func<Blog, bool>> predicate)
        {

            return _context.Blogs.Any(predicate);
        }
    }
}
