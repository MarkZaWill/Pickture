using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Pickture.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Pickture
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = @"Server=(localdb)\mssqllocaldb;Database=PicktureData;Trusted_Connection=True;";
            services.AddDbContext<PictureDbContext>(options => options.UseSqlServer(connection));

            // Add framework services.
            services.AddMvc();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowNewDevelopmentEnvironment",
                     //builder => builder.WithOrigins("http://localhost:8080")
                     builder => builder
                        .AllowAnyOrigin() //allows from anything(including virtual box)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        /*.WithMethods("DELETE, PUT, POST, GET, OPTIONS")*/);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            app.UseCors(builder =>
                        builder
                       .AllowAnyOrigin() //allows from anything(including virtual box)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                       /* .WithMethods("DELETE, PUT, POST, GET, OPTIONS")*/);

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();

        }
    }
}
