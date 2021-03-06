using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ToDo.Core.Infrastructure;
using ToDo.Core.Security;
using ToDo.Web.Infrastructure;
using Cynosura.Web.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ToDo.Web
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWeb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IExceptionHandler, ValidationExceptionHandler>();
            services.AddScoped<IUserInfoProvider, UserInfoProvider>();
            var assemblies = CoreHelper.GetPlatformAndAppAssemblies();
            services.AddSingleton<IMapper>(sp => new MapperConfiguration(cfg => { cfg.AddMaps(assemblies); }).CreateMapper());
            return services;
        }
    }
}
