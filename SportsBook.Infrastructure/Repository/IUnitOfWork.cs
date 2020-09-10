using Microsoft.EntityFrameworkCore;
using SportsBook.Domain.SeedWork;
using System;
using System.Threading.Tasks;

namespace SportsBook.Infrastructure.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
        Task<int> CommitAsync();
        void Rollback();

        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity;
        IGenericRepositoryAsync<TEntity> GetRepositoryAsync<TEntity>() where TEntity : class, IEntity;
    }

    public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        TContext Context { get; }
    }
}