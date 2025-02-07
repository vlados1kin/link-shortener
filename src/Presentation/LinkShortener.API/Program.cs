using LinkShortener.API.Extensions;
using LinkShortener.API.Middlewares;
using LinkShortener.Application.Extensions;
using LinkShortener.Persistence;
using LinkShortener.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddTransient<ExceptionHandlingMiddleware>();

builder.Services.ConfigureRepositoryContext(builder.Configuration);
builder.Services.ConfigureRepositories();
builder.Services.ConfigureAutoMapper();
builder.Services.ConfigureMediatr();
builder.Services.ConfigureShortUrlGenerator();
builder.Services.ConfigureCors();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

using (var scope = app.Services.CreateScope())
{
    var repositoryContext = scope.ServiceProvider.GetRequiredService<RepositoryContext>();
    await repositoryContext.Database.MigrateAsync();
}

app.UseCors("LinkShortenerPolicy");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
