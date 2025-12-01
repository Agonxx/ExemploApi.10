using Exemplo.Api.Extensions;
using Exemplo.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services
    .AddDatabase(builder.Configuration)
    .AddApplicationServices()
    .AddApiDocumentation()
    .AddApiCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("DefaultCors");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MiddlewareConfig();

app.MapControllers();

app.Run();
