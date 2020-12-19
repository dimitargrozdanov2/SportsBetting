using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SportsBetting.Data.Repositories;
using SportsBetting.Data.Repositories.Contracts;
using SportsBetting.Services;
using SportsBetting.Services.Contracts;
using SportsBetting.Services.Infrastructure;

namespace SportsBetting.Web.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAutomapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DtoMapperProfile());
                mc.AddProfile(new ControllerMappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }

        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IEventRepository, EventRepository>();

            services.AddTransient(typeof(IRepository<>), typeof(DbRepository<>));
        }
    }
}
