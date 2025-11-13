using System.Net;
using System.Text.Json;

namespace Exemplo.Api.Utils
{
    public class ExemploMiddleware
    {
        private readonly RequestDelegate _next;

        public ExemploMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var response = new
            {
                Message = "Ocorreu um erro interno no servidor.",
                Error = exception.Message,
                Details = exception.StackTrace
            };

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

    }
}
