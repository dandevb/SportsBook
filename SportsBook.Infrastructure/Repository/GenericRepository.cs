using Microsoft.EntityFrameworkCore;
using SportsBook.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SportsBook.Infrastructure.Repository
{
    public class GenericRepository<TEntity> : BaseRepository<TEntity>, IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        public GenericRepository(DbContext context) : base(context)
        {

        }

        #region Get methods
        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetByID(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual TEntity Search(params object[] keyValues)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Add methods
        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Add(params TEntity[] entities)
        {
            _dbSet.AddRange(entities);
        }

        public virtual void Add(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }
        #endregion

        #region Delete methods
        public virtual void Delete(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public virtual void Delete(params TEntity[] entities)
        {
            foreach (TEntity ent in entities)
            {
                if (_context.Entry(ent).State == EntityState.Detached)
                {
                    _dbSet.Attach(ent);
                }
            }
            _dbSet.RemoveRange(entities);
        }

        public virtual void Delete(IEnumerable<TEntity> entities)
        {
            foreach (TEntity ent in entities)
            {
                if (_context.Entry(ent).State == EntityState.Detached)
                {
                    _dbSet.Attach(ent);
                }
            }
            _dbSet.RemoveRange(entities);
        }
        #endregion

        #region Update methods
        public virtual void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _dbSet.Update(entity);
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            foreach (TEntity ent in entities)
            {
                _dbSet.Attach(ent);
                _context.Entry(ent).State = EntityState.Modified;
            }
            _dbSet.UpdateRange(entities);
        }

        public void Update(params TEntity[] entities)
        {
            foreach (TEntity ent in entities)
            {
                _dbSet.Attach(ent);
                _context.Entry(ent).State = EntityState.Modified;
            }
            _dbSet.UpdateRange(entities);
        }
        #endregion


        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
