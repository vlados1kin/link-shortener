using LinkShortener.Domain.Entities;
using LinkShortener.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LinkShortener.Persistence.Repositories;

public class UrlRepository : RepositoryBase<Url>, IUrlRepository
{
    private readonly RepositoryContext _context;
    
    public UrlRepository(RepositoryContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Url?> GetUrlByShortUrlAsync(string shortUrl, bool trackChanges, CancellationToken cancellationToken = default)
    {
        return await FindByCondition(url => url.ShortUrl == shortUrl, trackChanges).SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<Url?> GetUrlByLongUrlAsync(string longUrl, bool trackChanges, CancellationToken cancellationToken = default)
    {
        return await FindByCondition(url => url.LongUrl == longUrl, trackChanges).SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<IEnumerable<Url>> GetAllUrlsAsync(bool trackChanges, CancellationToken cancellationToken = default)
    {
        var urls = await FindAll(trackChanges).ToListAsync(cancellationToken);
        return urls;
    }
}