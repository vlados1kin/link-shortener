using AutoMapper;
using LinkShortener.Application.DTO;
using LinkShortener.Domain.Interfaces;
using MediatR;

namespace LinkShortener.Application.Queries;

public class GetAllUrlsQueryHandler : IRequestHandler<GetAllUrlsQuery, IEnumerable<UrlResponseDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public GetAllUrlsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<UrlResponseDto>> Handle(GetAllUrlsQuery request, CancellationToken cancellationToken)
    {
        var urls = await _unitOfWork.Url.GetAllUrlsAsync(request.TrackChanges, cancellationToken);

        var urlsResponseDto = _mapper.Map<IEnumerable<UrlResponseDto>>(urls);

        return urlsResponseDto;
    }
}