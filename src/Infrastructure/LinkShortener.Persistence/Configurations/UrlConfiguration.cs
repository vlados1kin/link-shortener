using LinkShortener.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkShortener.Persistence.Configurations;

public class UrlConfiguration : IEntityTypeConfiguration<Url>
{
    public void Configure(EntityTypeBuilder<Url> builder)
    {
        builder.HasKey(url => url.Id);

        builder.Property(url => url.LongUrl).HasMaxLength(256).IsRequired();

        builder.Property(url => url.ShortUrl).HasMaxLength(256).IsRequired();

        builder.Property(url => url.CreatedAt).IsRequired();

        builder.Property(url => url.ClickCount).HasDefaultValue(0).IsRequired();
    }
}