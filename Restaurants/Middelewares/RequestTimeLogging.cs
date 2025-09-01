
using System.Diagnostics;

namespace Restaurants.Api.Middelewares
{
    public class RequestTimeLogging(ILogger<RequestTimeLogging> logger) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var stopwatch = Stopwatch.StartNew();
            await next.Invoke(context);
            stopwatch.Stop();

            if (stopwatch.ElapsedMilliseconds / 1000 > 1)
            {
                logger.LogInformation("Request [{verp}] at {path} tool {time} ms",
                    context.Request.Method,
                    context.Request.Path,
                    stopwatch.ElapsedMilliseconds);
            }
        }
    }
}
