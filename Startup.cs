using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using api.Models;
using api.Services;
using api.Services.impl;

namespace api
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
            services.AddDbContext<NewsSourceContext>(opt => opt.UseInMemoryDatabase("NewsSource"));
            services.AddDbContext<NewsItemContext>(opt => opt.UseInMemoryDatabase("News"));
            services.AddScoped<INewsSourceService, NewsSourceService>();
            services.AddScoped<INewsService, NewsService>();
            services.AddScoped<INewsProducerFactory, NewsProducerFactory>();
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            InitData(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyOrigin());
            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private void InitData(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                var newsSourcesService = services.GetService<INewsSourceService>();

                newsSourcesService.initNewsSources();

                var newsService = services.GetService<INewsService>();
                newsService.LoadNews();
            }

        }
    }
}
