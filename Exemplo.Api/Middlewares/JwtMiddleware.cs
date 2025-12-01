using Exemplo.Domain.Extensions;

namespace Exemplo.Api.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<JwtMiddleware> _logger;

        public JwtMiddleware(RequestDelegate next, ILogger<JwtMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            // tenta pegar o header Authorization
            var header = context.Request.Headers["Authorization"].FirstOrDefault();

            // só verifica estrutura "Bearer algo"
            if (!header.IsNullOrEmpty() && header.StartsWith("Bearer "))
            {
                var token = header.Replace("Bearer ", "");

                // apenas loga, NÃO valida ainda
                _logger.LogInformation("JWT capturado (placeholder), token recebido: {Token}", token);

                // no futuro:
                // - validar assinatura
                // - extrair claims
                // - popular CurrentUser
                // - rejeitar se inválido
            }
            else
            {
                // nenhum token enviado
                // mas ainda assim segue normal (por enquanto)
                _logger.LogInformation("Nenhum JWT encontrado.");
            }

            await _next(context);
        }
    }
}
