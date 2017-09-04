using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Asp.NETCore
{
    public class MyMiddleware
    {
        private RequestDelegate _next;
        public MyMiddleware( RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            //Request
            var start = DateTime.Now;
            await _next(context);

            //Response
            var finish = DateTime.Now;
            var diff = finish.Subtract(start);
            await context.Response.WriteAsync($"The Time was {diff.Milliseconds}");
        }
    }
}
