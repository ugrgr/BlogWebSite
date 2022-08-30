using AutoMapper;
using BlogWebSite.Core.Repositories;
using MyApp.Core.Services;
using System.Linq.Expressions;

namespace BlogWebsite.Services
{
    public class GenericService<TEntity, TDto> : IGenericService<TEntity, TDto> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public GenericService(IGenericRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public TDto Create(TDto entity)
        {
            TEntity t = _mapper.Map<TEntity>(entity);

            _repository.Create(t);
            return _mapper.Map<TDto>(t);

        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TDto GetById(int id)
        {
            var entity = _repository.GetById(id);

            return _mapper.Map<TDto>(entity);

        }

        public List<TDto> GetList()
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            // where.take(1).skip(2).orderby().tolist(),

            return _repository.Where(predicate);
        }

        public IEnumerable<TDto> Where2(Expression<Func<TEntity, bool>> predicate)
        {
            // where..skip(2).take(1).orderby().tolist(),
            var list = _repository.Where(predicate).ToList();


            return _mapper.Map<IEnumerable<TDto>>(list);
        }
    }
}
