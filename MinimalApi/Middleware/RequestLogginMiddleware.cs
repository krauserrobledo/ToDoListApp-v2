﻿namespace MinimalApi.Middleware
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
            var startTime = DateTime.UtcNow;

            _logger.LogInformation("Starting request: {Method} {Path}",
                context.Request.Method, context.Request.Path);

            await _next(context);  // ← Pasar al siguiente middleware

            var duration = DateTime.UtcNow - startTime;
            _logger.LogInformation("Completed request: {Method} {Path} - {StatusCode} in {Duration}ms",
                context.Request.Method, context.Request.Path,
                context.Response.StatusCode, duration.TotalMilliseconds);
        }

    }
}
