namespace Exemplo.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro não tratado capturado pelo ExceptionMiddleware.");

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                var resposta = new
                {
                    message = "Ocorreu um erro inesperado.",
                    error = ex.Message // opcional; remova em produção se quiser
                };

                await context.Response.WriteAsJsonAsync(resposta);
            }
        }
    }
}
