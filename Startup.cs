using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;

namespace Asp.NETCore
{
    public class Startup
    {
        private IConfigurationRoot _configuration;
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json");
            builder.AddEnvironmentVariables();
            _configuration = builder.Build();
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<MyMiddleware>();
            app.UseStaticFiles();
            var applicationName = _configuration.GetValue<string>("ApplicationName");
            app.Run(context => context.Response.WriteAsync($"Ola Mundo 2 | {applicationName} "));
        }

    }
}