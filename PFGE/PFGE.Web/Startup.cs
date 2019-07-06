using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Mvc.Razor;
using PFGE.Core;
using PFGE.Infrastructure;
using PFGE.Service;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;


namespace PFGE.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();
            services.AddMvc();
            services.AddCors();
            services.AddMemoryCache();
            services.AddDistributedMemoryCache();

            var sqlConnectionString = Configuration.GetConnectionString("DefaultConnection");

            //my sql db context registration using pomelo provider
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(sqlConnectionString));
            //services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(sqlConnectionString, sqlServerOptions => sqlServerOptions.CommandTimeout(120)));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IHttpConnectionFeature, HttpConnectionFeature>();
            services.AddTransient<IPlaceService, PlaceService>();

            var appSettings = Configuration.GetSection("AppSettings");
            services.Configure<PFGE.Core.Common.Settings.AppSettings>(appSettings);
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>(); // paging

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
