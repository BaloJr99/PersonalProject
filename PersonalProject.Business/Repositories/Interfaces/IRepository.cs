using System.Linq.Expressions;
using PersonalProject.Data.Models;

namespace PersonalProject.Business.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        
        // IEnumerable<TEntity> Get(
        // Expression<Func<Task, bool>> filter = null,
        // Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        // string includeProperties = "");

        // Task<IEnumerable<TEntity>> GetAsync(
        //     Expression<Func<Task, bool>> filter = null,
        //     Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        //     string includeProperties = "");
        // Task<List<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetWhereAsync(
            Expression<Func<TEntity, bool>> expression);
        // Task<List<TEntity>> GetAll();

        Task<TEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
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