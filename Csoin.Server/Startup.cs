using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Csoin.Server.Interfaces;
using Csoin.Server.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Csoin.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IUserGroupService, UserGroupService>();
            services.AddSingleton<IEventTypeService, EventTypeService>();
            services.AddSingleton<IEventService, EventService>();

            services.AddSwaggerDocument();

        }

    


    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            app.UseStaticFiles();

            app.UseOpenApi();
            app.UseSwaggerUi3();
        }
    }
}
