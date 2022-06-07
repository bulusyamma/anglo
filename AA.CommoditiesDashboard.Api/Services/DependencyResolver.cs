using Application.Interfaces;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Services
{
    public static class DependencyResolver
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<IMappingProfile, MappingProfile>();
            services.AddTransient<ICommoditiesService, CommoditiesService>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            services.AddSingleton(mappingConfig.CreateMapper());
        }
    }
}
