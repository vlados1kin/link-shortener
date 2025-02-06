using LinkShortener.Domain.Interfaces;

namespace LinkShortener.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IUrlRepository> _urlRepository;

    public UnitOfWork(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _urlRepository = new Lazy<IUrlRepository>(() => new UrlRepository(repositoryContext));
    }

    public IUrlRepository Url => _urlRepository.Value;
    
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _repositoryContext.SaveChangesAsync(cancellationToken);
    }
}