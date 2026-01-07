using Exemplo.Api.Extensions;
using Exemplo.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services
    .AddDatabase(builder.Configuration)
    .AddJWTConfig(builder.Configuration)
    .AddApplicationServices()
    .AddApiDocumentation()
    .AddAuthorization()
    .AddApiCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<CorrelationIdMiddleware>()
    .UseMiddleware<ExceptionMiddleware>()
    .UseMiddleware<RequestLoggingMiddleware>()
    .UseCors("DefaultCors")
    .UseHttpsRedirection()
    .UseAuthentication()
    .UseAuthorization();

app.MapControllers();

app.Run();
