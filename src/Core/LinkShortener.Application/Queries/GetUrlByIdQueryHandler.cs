using AutoMapper;
using LinkShortener.Application.DTO;
using LinkShortener.Application.Exceptions;
using LinkShortener.Domain.Interfaces;
using MediatR;

namespace LinkShortener.Application.Queries;

public class GetUrlByIdQueryHandler : IRequestHandler<GetUrlByIdQuery, UrlResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public GetUrlByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<UrlResponseDto> Handle(GetUrlByIdQuery request, CancellationToken cancellationToken)
    {
        var url = await _unitOfWork.Url.FindByIdAsync(request.Id, cancellationToken);

        if (url == null)
        {
            throw new NotFoundException(string.Format(ExceptionMessages.UrlNotFound, request.Id));
        }

        var urlResponseDto = _mapper.Map<UrlResponseDto>(url);

        return urlResponseDto;
    }
}