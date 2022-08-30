using BlogWebSite.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlogWebSite.Repository
{

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly DbSet<T> _dbSet;
        public GenericRepository(AppDbContext context)
        {

            _dbSet = context.Set<T>();
        }

        public T Create(T entity)
        {
            _dbSet.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            _dbSet.Remove(entity);
        }


        public T GetById(int id)
        {

            return _dbSet.Find(id);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {

            return _dbSet.Where(predicate);
        }

        public List<T> GetList()
        {
            return _dbSet.ToList();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
