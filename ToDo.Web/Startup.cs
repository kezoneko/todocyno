using System;
using System.Collections.Generic;
using ToDo.Core;
using ToDo.Core.Entities;
using ToDo.Data;
using ToDo.Infrastructure;
using ToDo.Web.Infrastructure;
using Cynosura.Web;
using Cynosura.Web.Authorization;
using Cynosura.Web.Infrastructure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace ToDo.Web
{
    public class Startup
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public Startup(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;

            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath(_hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{hostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true);
            configurationBuilder.AddEnvironmentVariables();

            Configuration = configurationBuilder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddDefaultIdentity<User>()
                .AddRoles<Role>()
                .AddEntityFrameworkStores<DataContext>();

            services.AddIdentityServer(o =>
                {
                    var authority = Configuration["Authority"];
                    if (!string.IsNullOrEmpty(authority))
                    {
                        o.IssuerUri = authority;
                        o.PublicOrigin = authority;
                    }
                })
                .AddApiAuthorization<User, DataContext>()
                .AddProfileService<MyProfileService>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            services.AddMvc()
                .AddMvcOptions(o =>
                {
                    o.Filters.Add(typeof(ExceptionLoggerFilter), 10);
                    o.ModelBinderProviders.Insert(0, new UserInfoModelBinderProvider());
                })
                .AddJsonOptions(o =>
                {
                    o.JsonSerializerOptions.IgnoreNullValues = true;
                    o.JsonSerializerOptions.Converters.Add(new TimeSpanConverter());
                });

            services.AddAuthorization(options =>
            {
                new PolicyProvider().RegisterPolicies(options);
            });

            services.AddCors();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ToDo API", Version = "v1" });
                c.AddFluentValidationRules();
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri("/connect/authorize", UriKind.Relative),
                            TokenUrl = new Uri("/connect/token", UriKind.Relative),
                            Scopes = new Dictionary<string, string>
                            {
                                { "ToDo.WebAPI", "" },
                                { "openid", "" },
                                { "profile", "" },
                            }
                        }
                    }
                });
                c.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            services.AddGrpc();

            services.AddWeb(Configuration);
            services.AddInfrastructure(Configuration);
            services.AddData();
            services.AddCore(Configuration);
            services.AddCynosuraWeb();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDo API V1");
                c.OAuthClientId("Swagger");
                c.OAuthAppName("ToDo.Web");
                c.OAuthScopeSeparator(" ");
                c.OAuthUsePkce();
                c.ConfigObject.DeepLinking = true;
            });

            app.UseRouting();

            app.UseCors(builder =>
            {
                builder.WithOrigins(Configuration["Cors:Origin"])
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });

            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("default", "{controller=Task}/{action=Api}/{GetTasks}");
                endpoints.MapRazorPages();
                var provider = new ConfigurationProvider<IEndpointRouteBuilder>();
                provider.Configure(endpoints);
            });
        }
    }
}
