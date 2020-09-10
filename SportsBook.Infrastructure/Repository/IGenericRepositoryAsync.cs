using SportsBook.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SportsBook.Infrastructure.Repository
{
    public interface IGenericRepositoryAsync<TEntity> : IDisposable where TEntity : class, IEntity
    {
        #region Get methods
        IEnumerable<TEntity> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        TEntity GetListAsync(object id);
        #endregion

        #region Add methods
        Task AddAsync(TEntity entity);
        Task AddAsync(params TEntity[] entities);
        Task AddAsync(IEnumerable<TEntity> entities);
        #endregion
    }
}
