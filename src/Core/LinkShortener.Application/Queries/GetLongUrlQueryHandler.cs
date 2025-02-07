using AutoMapper;
using LinkShortener.Application.Exceptions;
using LinkShortener.Domain.Interfaces;
using MediatR;

namespace LinkShortener.Application.Queries;

public class GetLongUrlQueryHandler : IRequestHandler<GetLongUrlQuery, string>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public GetLongUrlQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<string> Handle(GetLongUrlQuery request, CancellationToken cancellationToken)
    {
        var url = await _unitOfWork.Url.GetUrlByShortUrlAsync(request.ShortUrl, request.TrackChanges, cancellationToken);

        if (url == null)
        {
            throw new NotFoundException(string.Format(ExceptionMessages.UrlNotFound, request.ShortUrl));
        }

        url.ClickCount++;

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return url.LongUrl;
    }
}