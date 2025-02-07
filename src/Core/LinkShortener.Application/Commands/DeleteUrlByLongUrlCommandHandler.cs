using LinkShortener.Application.Exceptions;
using LinkShortener.Domain.Interfaces;
using MediatR;

namespace LinkShortener.Application.Commands;

public class DeleteUrlByLongUrlCommandHandler : IRequestHandler<DeleteUrlByLongUrlCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    
    public DeleteUrlByLongUrlCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task Handle(DeleteUrlByLongUrlCommand request, CancellationToken cancellationToken)
    {
        var url = await _unitOfWork.Url.GetUrlByLongUrlAsync(request.LongUrl, request.TrackChanges, cancellationToken);

        if (url == null)
        {
            throw new NotFoundException(string.Format(ExceptionMessages.UrlNotFound, request.LongUrl));
        }
        
        _unitOfWork.Url.Delete(url);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}