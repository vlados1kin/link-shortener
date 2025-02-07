namespace LinkShortener.Application.DTO;

public record UrlRequestDto
{
    public string LongUrl { get; set; } = null!;
}