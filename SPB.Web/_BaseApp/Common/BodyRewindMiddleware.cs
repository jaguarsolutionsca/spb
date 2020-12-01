using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace BaseApp.Web
{
    public sealed class BodyRewindMiddleware
    {
        private readonly RequestDelegate next;

        public BodyRewindMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                context.Request.EnableBuffering();
            }
            catch { }

            await next(context);
        }
    }

    public static class BodyRewindExtensions
    {
        public static IApplicationBuilder Use_EnableRequestBodyRewind(this IApplicationBuilder app)
        {
            return app.UseMiddleware<BodyRewindMiddleware>();
        }
    }
}
