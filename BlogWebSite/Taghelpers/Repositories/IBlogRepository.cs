using System.Linq.Expressions;
using BlogWebSite.Models;

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
