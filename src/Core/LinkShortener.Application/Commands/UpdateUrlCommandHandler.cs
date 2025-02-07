using AutoMapper;
using LinkShortener.Application.DTO;
using LinkShortener.Application.Exceptions;
using LinkShortener.Domain.Interfaces;
using MediatR;

namespace LinkShortener.Application.Commands;

public class UpdateUrlCommandHandler : IRequestHandler<UpdateUrlCommand, UrlResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IShortUrlGenerator _shortUrlGenerator;
    
    public UpdateUrlCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IShortUrlGenerator shortUrlGenerator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _shortUrlGenerator = shortUrlGenerator;
    }
    
    public async Task<UrlResponseDto> Handle(UpdateUrlCommand request, CancellationToken cancellationToken)
    {
        var url = await _unitOfWork.Url.FindByIdAsync(request.Id, cancellationToken);

        if (url == null)
        {
            throw new NotFoundException(string.Format(ExceptionMessages.UrlNotFound, request.Id));
        }
        
        url.LongUrl = request.LongUrl;
        url.ShortUrl = _shortUrlGenerator.Generate();
        url.ClickCount = 0;

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var urlResponseDto = _mapper.Map<UrlResponseDto>(url);

        return urlResponseDto;
    }
}