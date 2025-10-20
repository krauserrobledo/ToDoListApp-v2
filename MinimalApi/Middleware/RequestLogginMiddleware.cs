namespace MinimalApi.Middleware
{
    public class RequestLogginMiddleware : IMiddleware 
    {
        private readonly RequestDelegate _next;
        public RequestLogginMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate requestDelegate)
        {
            if (!context.User.Identity?.IsAuthenticated ?? true)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Unauthorized: Please log in to access this resource.");
                return;
            }
            await _next(context);
        }

    }
}
