using System.Diagnostics;

namespace FitControl.WebAPI.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            var request = context.Request;

            var method = request.Method;
            var path = request.Path;
            var query = request.QueryString;

            await _next(context);

            stopwatch.Stop();

            var statusCode = context.Response.StatusCode;

            _logger.LogInformation(
                "HTTP {Method} {Path}{Query} responded {StatusCode} in {Elapsed} ms | TraceId: {TraceId}",
                method,
                path,
                query,
                statusCode,
                stopwatch.ElapsedMilliseconds,
                context.TraceIdentifier
            );
        }
    }
}
