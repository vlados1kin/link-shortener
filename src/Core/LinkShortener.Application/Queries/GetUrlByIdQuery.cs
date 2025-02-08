using LinkShortener.Application.DTO;
using MediatR;

namespace LinkShortener.Application.Queries;

public record GetUrlByIdQuery(Guid Id) : IRequest<UrlResponseDto>;