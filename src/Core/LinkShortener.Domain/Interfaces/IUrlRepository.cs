using LinkShortener.Domain.Entities;

namespace LinkShortener.Domain.Interfaces;

public interface IUrlRepository : IRepositoryBase<Url>
{
    Task<Url?> GetUrlByShortUrlAsync(string shortUrl, bool trackChanges, CancellationToken cancellationToken = default);
}