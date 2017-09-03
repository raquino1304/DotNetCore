using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Asp.NETCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .Configure(app => {
                        app.Run(context => context.Response.WriteAsync("Olá Mundo"));
                    }
                )
                .Build();
                host.Run();

            
        }
    }
}
