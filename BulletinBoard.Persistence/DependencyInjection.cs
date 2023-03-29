using BulletinBoard.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BulletinBoard.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbContection"];
            services.AddDbContext<BulletinBoardDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<IBulletinBoardDbContext>(provider =>
                provider.GetService<BulletinBoardDbContext>());
            return services;
        }
    }
}
