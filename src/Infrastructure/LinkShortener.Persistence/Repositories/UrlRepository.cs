using LinkShortener.Domain.Entities;
using LinkShortener.Domain.Interfaces;

namespace LinkShortener.Persistence.Repositories;

public class UrlRepository : RepositoryBase<Url>, IUrlRepository
{
    public UrlRepository(RepositoryContext context) : base(context)
    {
    }
}