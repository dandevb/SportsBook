using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportsBook.Domain.SeedWork;

namespace SportsBook.Infrastructure.Repository
{
    public class GenericRepositoryAsync<TEntity> : BaseRepository<TEntity>, IGenericRepositoryAsync<TEntity> where TEntity : class, IEntity
    {
        public GenericRepositoryAsync(DbContext context) : base(context)
        {
        }

        public Task AddAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(params TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public TEntity GetListAsync(object id)
        {
            throw new NotImplementedException();
        }
    }
}