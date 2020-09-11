using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SportsBook.Domain.SeedWork;
using SportsBook.Infrastructure.Repository;
using SportsBook.Services.Services;

namespace SportsBook.Services.DependencyInjection
{
    /// <summary>
    /// Use this static class to keep track of the settings for services using dependency injection. TODO: include more options for API Server
    /// </summary>
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<DTOAssembler>();
            services.AddScoped<IServices, BaseService>();
            services.AddSingleton<BaseService, SportService>();
            services.AddSingleton<BaseService, EventService>();
            services.AddSingleton<BaseService, MarketService>();
            services.AddSingleton<BaseService, SelectionService>();
            return services;
        }

        public static IServiceCollection AddUnitOfWork<TContext>(this IServiceCollection services)
            where TContext : DbContext
        {
            services.AddScoped<IUnitOfWork, UnitOfWork<TContext>>();
            services.AddScoped<IUnitOfWork<TContext>, UnitOfWork<TContext>>();
            return services;
        }

        public static IServiceCollection AddUnitOfWork<TContext1, TContext2>(this IServiceCollection services)
            where TContext1 : DbContext
            where TContext2 : DbContext
        {
            services.AddScoped<IUnitOfWork<TContext1>, UnitOfWork<TContext1>>();
            services.AddScoped<IUnitOfWork<TContext2>, UnitOfWork<TContext2>>();
            return services;
        }

        public static IServiceCollection AddGenericRepository<TEntity>(this IServiceCollection services)
            where TEntity : class, IEntity
        {
            services.AddScoped(typeof(IGenericRepository<TEntity>), typeof(GenericRepository<TEntity>));
            services.AddScoped(typeof(BaseRepository<TEntity>), typeof(GenericRepository<TEntity>));
            return services;
        }
    }
}
