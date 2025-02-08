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

        builder.HasData(new Url
        {
            Id = new Guid("08dd4867-6777-4aef-8bb3-1d7219e41d67"),
            LongUrl = "https://vk.com",
            ShortUrl = "1odc1dvGs",
            CreatedAt = new DateTime(new DateOnly(2025, 02, 07), new TimeOnly(17, 38, 30)),
            ClickCount = 0
        }, new Url
        {
            Id = new Guid("08dd4867-6777-4aef-8bb3-1d1423e41d67"),
            LongUrl = "https://www.w3schools.com",
            ShortUrl = "iJyKHaMAR",
            CreatedAt = new DateTime(new DateOnly(2025, 02, 07), new TimeOnly(21, 11, 59)),
            ClickCount = 0
        }, new Url
        {
            Id = new Guid("08dd4867-8342-4d03-8b46-c95f4eebaac3"),
            LongUrl = "http://localhost:8080/swagger/index.html",
            ShortUrl = "LDWQkfKhu",
            CreatedAt = new DateTime(new DateOnly(2025, 02, 08), new TimeOnly(09, 05, 12)),
            ClickCount = 0
        }, new Url
        {
            Id = new Guid("08dd4867-944f-4e16-8631-f7a15d60a0f6"),
            LongUrl = "https://metanit.com",
            ShortUrl = "XeWrGkd0S",
            CreatedAt = new DateTime(new DateOnly(2025, 02, 08), new TimeOnly(11, 12, 42)),
            ClickCount = 0
        });
    }
}