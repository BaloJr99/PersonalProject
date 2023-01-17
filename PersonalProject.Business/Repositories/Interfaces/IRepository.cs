using System.Linq.Expressions;
using PersonalProject.Data.Models;

namespace PersonalProject.Business.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        
        Task<IEnumerable<TEntity>> GetWhereAsync(
            Expression<Func<TEntity, bool>> expression);

        Task<TEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        void Update(TEntity entity, string excludeProperties = null!);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        IQueryable<TEntity> AsQueryable();
        Task<int> CountWhere(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null!,
                                      Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null!,
                                      params string[] includeProperties);
    }
}