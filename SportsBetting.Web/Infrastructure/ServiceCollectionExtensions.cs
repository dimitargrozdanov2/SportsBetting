using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SportsBetting.Data.Repositories;
using SportsBetting.Data.Repositories.Contracts;
using SportsBetting.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsBetting.Web.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAutomapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DtoMapperProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }

        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddControllersWithViews();

            //add scoped services
            services.AddTransient(typeof(IRepository<>), typeof(DbRepository<>));
        }
    }
}
