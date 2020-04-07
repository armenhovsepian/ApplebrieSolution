using Applebrie.Infrastructure;
using Applebrie.WebApi.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Applebrie.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplebrieDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //services.AddAutoMapper(typeof(Startup));

            services.AddMvc(options =>
                {
                    options.Filters.Add(typeof(JsonExceptionFilter));
                    options.Filters.Add(typeof(RequireHttpsAttribute));
                })               
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddRouting(options => options.LowercaseUrls = true);

            //services.AddApiVersioning(options =>
            //{
            //    options.ApiVersionReader = new MediaTypeApiVersionReader();
            //    options.AssumeDefaultVersionWhenUnspecified = true;
            //    options.ReportApiVersions = true;
            //    options.DefaultApiVersion = new ApiVersion(1, 0);
            //    options.ApiVersionSelector = new CurrentImplementationApiVersionSelector(options);
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //var builder = new ConfigurationBuilder()
            //    .SetBasePath(env.ContentRootPath)
            //    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            //    .AddEnvironmentVariables();
            //Configuration = builder.Build();

            //if (env.IsDevelopment())
            //{
            //    var launchJsonConfig = new ConfigurationBuilder()
            //        .SetBasePath(env.ContentRootPath)
            //        .AddJsonFile("Properties\\launchSettings.json")
            //        .Build();

            //    var _httpsport = launchJsonConfig.GetValue<int>("iisSettings:iisExpress:sslPort");
            //}


            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
