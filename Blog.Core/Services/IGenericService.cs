using System.Linq.Expressions;

namespace MyApp.Core.Services
{
    public interface IGenericService<TEntity, TDto>
    {

        List<TDto> GetList();

        TDto GetById(int id);

        TDto Create(TDto entity);

        void Update(TEntity entity);

        void Delete(int id);
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TDto> Where2(Expression<Func<TEntity, bool>> predicate);
    }
}
