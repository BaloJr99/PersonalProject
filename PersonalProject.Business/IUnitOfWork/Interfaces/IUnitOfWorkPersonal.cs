using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalProject.Business.Repositories.Interfaces;

namespace PersonalProject.Business.IUnitOfWork.Interfaces
{
    public interface IUnitOfWorkPersonal
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        void CreateTransaction();
        Task CreateTransactionAsync();
        void Commit();
        Task CommitAsync();
        void Dispose();
        void Rollback();
        Task RollbackAsync();
        Task SaveChangesAsync();
    }
}