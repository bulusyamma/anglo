using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;

namespace Persistence
{
    public static class DependencyResolver
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CommoditiesDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(CommoditiesDbContext).Assembly.FullName)
                          .EnableRetryOnFailure()));

            services.AddScoped<ICommoditiesDbContext>(provider => provider.GetService<CommoditiesDbContext>());
        }
    }
}
