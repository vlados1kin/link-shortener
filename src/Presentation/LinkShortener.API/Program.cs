using LinkShortener.API.Extensions;
using LinkShortener.Persistence;
using LinkShortener.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureRepositoryContext(builder.Configuration);
builder.Services.ConfigureRepositories();
builder.Services.ConfigureCors();

var app = builder.Build();

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

app.UseHttpsRedirection();

app.Run();
