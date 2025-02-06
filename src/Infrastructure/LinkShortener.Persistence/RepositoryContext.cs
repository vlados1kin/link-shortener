using LinkShortener.Domain.Entities;
using LinkShortener.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LinkShortener.Persistence;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
    {
    }
    
    public DbSet<Url> Urls { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UrlConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}