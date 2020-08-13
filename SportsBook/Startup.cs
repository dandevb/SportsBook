using Microsoft.Extensions.DependencyInjection;
using SportsBook.Infrastructure;

namespace SportsBook
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
            => services.AddDbContext<SportsBookDB>();
    }
}
