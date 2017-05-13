using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using TheBook.models;
using TheBook.Repository;
using AutoMapper;
using Newtonsoft.Json.Serialization;
using TheBook.Service;

namespace TheBook
{
    public class Startup
    {
        private IConfigurationRoot _Configuration;
        private IHostingEnvironment _env;

        public Startup(IHostingEnvironment env)
        {
            _env = env;

            var MyConfigurationBuilder = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();

            _Configuration = MyConfigurationBuilder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(_Configuration);
            services.AddDbContext<BookContext>();
            services.AddScoped<ITheBookRepository, TheBookRepository>();
            services.AddTransient<GeoCoordsService>();
            services.AddLogging();
            services.AddMvc().AddJsonOptions(config=>
            config.SerializerSettings.ContractResolver=new CamelCasePropertyNamesContractResolver());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app
            , IHostingEnvironment env
            , ILoggerFactory loggerFactory)
        {
            Mapper.Initialize(config=> {
                config.CreateMap<ViewModels.RoleMember, models.RoleMember>().ReverseMap();
                config.CreateMap<ViewModels.TeamMember, models.TeamMember>().ReverseMap();
                config.CreateMap<ViewModels.Car, models.Car>().ReverseMap();
                config.CreateMap<ViewModels.Stop, models.Stop>().ReverseMap();
                config.CreateMap<ViewModels.Trip, models.Trip>().ReverseMap();
            });
            //app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc(config=> {
                config.MapRoute(
                    name:"Default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "App", action = "Login" }
                    );
            });
            

            if (env.IsEnvironment("Development"))
            {
                app.UseDeveloperExceptionPage();
                loggerFactory.AddDebug(LogLevel.Information);
            }
            else
            {
                loggerFactory.AddDebug(LogLevel.Error);
            }

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
