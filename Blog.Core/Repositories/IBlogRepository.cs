using BlogWebSite.Core.DTOs;
using BlogWebSite.Core.Models;
using System.Linq.Expressions;

namespace BlogWebSite.Repositories
{
    public interface IBlogRepository
    {
        List<Blog> GetAll();
        Blog Create(Blog blog);
        void Update(Blog blog);
        Blog GetById(int id);
        void Delete(int id);
        bool Any(Expression<Func<Blog, bool>> predicate);
        List<Category> GetCategories();
    }
}
