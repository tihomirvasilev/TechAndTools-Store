using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using TechAndTools.Data;
using TechAndTools.Data.Models;
using TechAndTools.Services;
using TechAndTools.Services.EmailSender;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models.Brands;
using TechAndTools.Web.InputModels.Administration.Brands;
using TechAndTools.Web.ViewModels;
using TechAndTools.Web.ViewModels.Administration.Brands;

namespace TechAndTools.Web
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TechAndToolsDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")).UseLazyLoadingProxies());

            services
                .AddIdentity<TechAndToolsUser, TechAndToolsRole>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequiredLength = 6;
                })
                .AddEntityFrameworkStores<TechAndToolsDbContext>()
                //.AddUserStore<ApplicationUserStore>()
                //.AddRoleStore<ApplicationRoleStore>()
                .AddDefaultTokenProviders()
                .AddDefaultUI(UIFramework.Bootstrap4);


            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddRazorPagesOptions(options =>
                {
                    options.AllowAreas = true;
                    options.Conventions.AuthorizeAreaFolder("Identity", "/Account/Manage");
                    options.Conventions.AuthorizeAreaPage("Identity", "/Account/Logout");
                });

            services
                .ConfigureApplicationCookie(options =>
                {
                    options.LoginPath = "/Identity/Account/Login";
                    options.LogoutPath = "/Identity/Account/Logout";
                    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                });

            services
                .Configure<CookiePolicyOptions>(options =>
                {
                    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                    options.CheckConsentNeeded = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.Lax;
                    options.ConsentCookie.Name = ".AspNetCore.ConsentCookie";
                });

            services.AddSingleton(this.configuration);

            //// Identity stores
            //services.AddTransient<IUserStore<ApplicationUser>, ApplicationUserStore>();
            //services.AddTransient<IRoleStore<ApplicationRole>, ApplicationRoleStore>();
            
            // Data repositories
            //services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            //services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            //services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            services.AddSingleton<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(options => options.SendGridKey = configuration["DataGrid:ApiKey"]);

            services.AddTransient<IBrandService, BrandService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly,
                typeof(BrandServiceModel).GetTypeInfo().Assembly,
                typeof(IndexBrandViewModel).GetTypeInfo().Assembly,
                typeof(Brand).GetTypeInfo().Assembly,
                typeof(BrandInputModel).GetTypeInfo().Assembly,
                typeof(DetailsBrandViewModel).GetTypeInfo().Assembly);

            // Seed data on application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<TechAndToolsDbContext>();

                if (env.IsDevelopment())
                {
                    dbContext.Database.Migrate();
                }

                // new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
