using LinkShortener.Application.DTO;
using MediatR;

namespace LinkShortener.Application.Commands;

public record CreateUrlCommand(string LongUrl) : IRequest<UrlResponseDto>;