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

app.UseCors("DefaultCors")
    .UseHttpsRedirection()
    .UseAuthentication()
    .UseAuthorization()
    .MiddlewareConfig();

app.MapControllers();

app.Run();
