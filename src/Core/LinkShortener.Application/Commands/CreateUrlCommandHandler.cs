using AutoMapper;
using LinkShortener.Application.DTO;
using LinkShortener.Domain.Entities;
using LinkShortener.Domain.Interfaces;
using MediatR;

namespace LinkShortener.Application.Commands;

public class CreateUrlCommandHandler : IRequestHandler<CreateUrlCommand, UrlResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IShortUrlGenerator _shortUrlGenerator;
    
    public CreateUrlCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IShortUrlGenerator shortUrlGenerator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _shortUrlGenerator = shortUrlGenerator;
    }
    
    public async Task<UrlResponseDto> Handle(CreateUrlCommand request, CancellationToken cancellationToken)
    {
        var url = await _unitOfWork.Url.GetUrlByLongUrlAsync(request.LongUrl, false, cancellationToken);

        if (url != null)
        {
            return _mapper.Map<UrlResponseDto>(url);
        }
        
        var shortUrl = _shortUrlGenerator.Generate();
        
        url = new Url
        {
            LongUrl = request.LongUrl,
            ShortUrl = shortUrl
        };
        
        await _unitOfWork.Url.CreateAsync(url, cancellationToken);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<UrlResponseDto>(url);
    }
}