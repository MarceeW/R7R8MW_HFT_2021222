using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using R7R8MW_HFT_2021222.Logic;
using R7R8MW_HFT_2021222.Models;
using R7R8MW_HFT_2021222.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace R7R8MW_HFT_20212222.Endpoint
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
            services.AddSingleton<MovieDbContext>();

            services.AddTransient<IRepository<Movie>, MovieRepository>();
            services.AddTransient<IRepository<Role>, RoleRepository>();
            services.AddTransient<IRepository<Actor>, ActorRepository>();
            services.AddTransient<IRepository<Director>, DirectorRepository>();

            services.AddTransient<IMovieLogic, MovieLogic>();
            services.AddTransient<IRoleLogic, RoleLogic>();
            services.AddTransient<IPersonLogic, PersonLogic>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "R7R8MW_HFT_20212222.Endpoint", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "R7R8MW_HFT_20212222.Endpoint v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
