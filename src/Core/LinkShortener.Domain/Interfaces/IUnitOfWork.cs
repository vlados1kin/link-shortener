namespace LinkShortener.Domain.Interfaces;

public interface IUnitOfWork
{
    IUrlRepository Url { get; }
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}