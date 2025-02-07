using LinkShortener.Application.Exceptions;
using LinkShortener.Domain.Interfaces;
using MediatR;

namespace LinkShortener.Application.Commands;

public class DeleteUrlByIdCommandHandler : IRequestHandler<DeleteUrlByIdCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    
    public DeleteUrlByIdCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task Handle(DeleteUrlByIdCommand request, CancellationToken cancellationToken)
    {
        var url = await _unitOfWork.Url.FindByIdAsync(request.Id, cancellationToken);

        if (url == null)
        {
            throw new NotFoundException(string.Format(ExceptionMessages.UrlNotFound, request.Id));
        }
        
        _unitOfWork.Url.Delete(url);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}