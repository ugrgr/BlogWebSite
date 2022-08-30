using System.Linq.Expressions;

namespace BlogWebSite.Core.Repositories
{
    public interface IGenericRepository<T>
    {

        List<T> GetList();

        T GetById(int id);

        T Create(T entity);

        void Update(T entity);

        void Delete(int id);
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);

    }
}
