namespace Exemplo.Api.Middlewares
{
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
}
