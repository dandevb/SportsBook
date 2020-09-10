using SportsBook.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SportsBook.Infrastructure.Repository
{
    public interface IGenericRepository<TEntity> : IDisposable where TEntity : class, IEntity
    {
        #region Get methods
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        TEntity GetByID(object id);
        TEntity Search(params object[] keyValues);
        #endregion

        #region Add methods
        void Add(TEntity entity);
        void Add(params TEntity[] entities);
        void Add(IEnumerable<TEntity> entities);
        #endregion

        #region Delete Methods
        void Delete(TEntity entity);
        void Delete(params TEntity[] entities);
        void Delete(IEnumerable<TEntity> entities);
        #endregion

        #region Update methods
        void Update(TEntity entity);
        void Update(params TEntity[] entities);
        void Update(IEnumerable<TEntity> entities);
        #endregion
    }
}
