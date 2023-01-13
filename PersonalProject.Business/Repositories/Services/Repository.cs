using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalProject.Business.Repositories.Interfaces;

namespace PersonalProject.Business.Repositories.Services
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class 
    {

        protected readonly DbContext _Context;      

        public Repository(DbContext Context)
        {
            _Context = Context;
        }  


        public async Task<IEnumerable<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> expression){
            return await _Context.Set<TEntity>().Where(expression).ToListAsync();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _Context.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _Context.Set<TEntity>().AddRangeAsync(entities);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _Context.Set<TEntity>().Where(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return  await _Context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _Context.Set<TEntity>().FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            _Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _Context.Set<TEntity>().RemoveRange(entities);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _Context.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }
    }
}