namespace LinkShortener.Application.DTO;

public record UrlResponseDto
{
    public Guid Id { get; set; }
    public string LongUrl { get; set; } = null!;
    public string ShortUrl { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public int ClickCount { get; set; }
}