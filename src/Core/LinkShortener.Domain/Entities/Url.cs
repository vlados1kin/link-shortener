namespace LinkShortener.Domain.Entities;

public class Url : BaseEntity
{
    public string LongUrl { get; set; } = null!;
    public string ShortUrl { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int ClickCount { get; set; } = 0;
}