using LinkShortener.Application.DTO;
using MediatR;

namespace LinkShortener.Application.Commands;

public record UpdateUrlCommand(Guid Id, string LongUrl) : IRequest<UrlResponseDto>;