using Microsoft.Extensions.DependencyInjection;
using SportsBook.Domain.Model;
using SportsBook.Infrastructure.Repository;
using SportsBook.Services.Services;
using System;

namespace SportsBook
{
    class Program
    {
        static void Main(string[] args)
        {

            IServiceCollection services = new ServiceCollection();
            // Startup.cs finally :)
            Startup startup = new Startup();
            startup.ConfigureServices(services);
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            //configure console logging
            //serviceProvider
            //    .GetService<ILoggerFactory>()
            //    .AddConsole(LogLevel.Debug);

            //var logger = serviceProvider.GetService<ILoggerFactory>()
            //    .CreateLogger<Program>();

            //logger.LogDebug("Logger is working!");

            // Get Service and call method
            var allservices = serviceProvider.GetServices<IServices>();

           // var service = serviceProvider.GetService(SportService);

            var service = serviceProvider.GetService<SportService>();

            service.Create(new Services.DTO.SportDTO()
            {
                Name = "Baseball",
                Slug = "baseball"
            });
        }

        
    }
}
