using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using repositoryPattern.Models;
using repositoryPattern.Repositories;
using repositoryPattern.Repositories.SchoolRepository;
using repositoryPattern.Repositories.StudentRepository;
using repositoryPattern.Repositories.WrapperRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repositoryPattern
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
            //Entity FrameWork
            services.AddDbContext<repositoryContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //repositoy pattern
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ISchoolRepository, SchoolRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IWrapperRepository, WrapperRepository>();
            //swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "test repository pattern", Version = "v1" });
            });
            //controller
            services.AddControllers();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "test repository pattern"));
            }
            app.UseStaticFiles();
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
