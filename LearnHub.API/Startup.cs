using LearnHub.Core.Common;
using LearnHub.Core.Data;
using LearnHub.Core.Repository;
using LearnHub.Core.Services;
using LearnHub.Infra.Common;
using LearnHub.Infra.Repository;
using LearnHub.Infra.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnHub.API
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
            services.AddScoped<IDbContext, DbContext>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ICourseStudentRepository, CourseStudentRepository>();
            services.AddScoped<IExerciseRepository, ExerciseRepository>();
            services.AddScoped<ICourseServices, CourseServices>();
            services.AddScoped<IStudentServices, StudentServices>();
            services.AddScoped<ILoginServices, LoginServices>();

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
