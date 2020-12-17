using AutoMapper;
using BlogApplication.Contracts;
using BlogApplication.Core.Repository;
using BlogApplication.Data.Repository;
using BlogApplication.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BlogApplication.API
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

            services.AddAutoMapper(typeof(Startup));
            services.AddLogging();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            
            services.AddScoped<IArticleContracts, ArticleRepository>();


            //services.AddScoped<IArticleContracts, ArticleService>();

            //services.AddDbContext<AppDbContext>(options => options.UseSqlServer("SqlConStr=Server=DESKTOP-5LQ1I4G\\SQLEXPRESS;Database=test:DefaultConnection"));

            services.AddDbContext<AppDbContext>(options => {
                options.UseSqlServer(Configuration["ConnectionString:SqlConStr"].ToString(), o => {
                    o.MigrationsAssembly("BlogApplicaton.Entities");
                });
            });

            services.AddSwaggerDocument(config => {
                config.PostProcess = (doc => {
                    doc.Info.Title = "Blog Application Api";
                    doc.Info.Version = "0.0.1";
                    doc.Info.Contact = new NSwag.OpenApiContact() {
                        Name = "Ferdi",
                        Email = "info@ferdikoca.com.tr"
                         
                    };
                });
            });  

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //swagger
            app.UseRouting();
            app.UseOpenApi();
            app.UseSwaggerUi3();
            

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
