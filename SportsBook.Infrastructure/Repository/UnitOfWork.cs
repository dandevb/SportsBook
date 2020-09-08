using Microsoft.EntityFrameworkCore;
using SportsBook.Domain.Model;
using System;

namespace SportsBook.Infrastructure.Repository
{
    public class UnitOfWork : IDisposable
    {
        public DbContext Context { get; }
        private bool disposed = false;

        public UnitOfWork(DbContext context)
        {
            Context = context;
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}