namespace Exemplo.Api.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class DefaultMiddleware
    {
        private readonly RequestDelegate _next;

        public DefaultMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            return _next(httpContext);
        }
    }

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder MiddlewareConfig(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<DefaultMiddleware>();
            builder.UseMiddleware<ExceptionMiddleware>();
            builder.UseMiddleware<CorrelationIdMiddleware>();
            builder.UseMiddleware<RequestLoggingMiddleware>();
            builder.UseMiddleware<JwtMiddleware>();

            return builder;
        }
    }
}
