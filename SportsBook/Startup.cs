using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SportsBook.Infrastructure;
using SportsBook.Infrastructure.Repository;
using SportsBook.Services;
using SportsBook.Services.Services;

namespace SportsBook
{
    public class Startup
    {
        IConfigurationRoot Configuration { get; }

        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConfigurationRoot>(Configuration);
            services.AddScoped<UnitOfWork>();
            services.AddScoped<DbContext, SportsBookDB>();
            services.AddDbContext<SportsBookDB>(options => options.UseSqlServer(Configuration.GetConnectionString("SportsBookDB")));
            
            //services.AddLogging();
            
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<DTOAssembler>();
            
            services.AddSingleton<SportService>();
            services.AddSingleton<EventService>();
            services.AddSingleton<MarketService>();
            services.AddSingleton<SelectionService>();
        }
    }
}
