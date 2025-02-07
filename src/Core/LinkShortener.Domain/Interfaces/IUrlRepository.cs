using LinkShortener.Domain.Entities;

namespace LinkShortener.Domain.Interfaces;

public interface IUrlRepository : IRepositoryBase<Url>
{
    Task<Url?> GetUrlByShortUrlAsync(string shortUrl, bool trackChanges, CancellationToken cancellationToken = default);
    Task<Url?> GetUrlByLongUrlAsync(string longUrl, bool trackChanges, CancellationToken cancellationToken = default);
    Task<IEnumerable<Url>> GetAllUrlsAsync(bool trackChanges, CancellationToken cancellationToken = default);
}