using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketSquare.API.Data;
using MarketSquare.API.Data.Repositories;
using MarketSquare.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using AutoMapper;

namespace MarketSquare.API
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
            services.AddControllers();

            services.AddDbContext<DataContext>(x => x.UseSqlite(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(Startup).Namespace)));
            services.AddScoped<DbContext>(sp => sp.GetRequiredService<DataContext>());
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IRepositoryFactory, RepositoryFactory>();
            services.AddScoped<INoticesRepository, NoticesRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<ISettingsService, SettingsService>();
            services.AddScoped<INoticeService, NoticeService>();
            services.AddScoped<ISeedService, SeedService>();
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            //app.UseMvc();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
