using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ToDo.Core.Infrastructure;
using ToDo.Core.Security;
using ToDo.Worker.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ToDo.Worker
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWorker(this IServiceCollection services)
        {
            services.AddScoped<IUserInfoProvider, UserInfoProvider>();
            services.AddSingleton<IHostedService, MainWorker>();
            services.AddTransient<CoreLogProvider>();
            var assemblies = CoreHelper.GetPlatformAndAppAssemblies();
            services.AddSingleton<IMapper>(sp => new MapperConfiguration(cfg => { cfg.AddMaps(assemblies); }).CreateMapper());
            return services;
        }
    }
}
