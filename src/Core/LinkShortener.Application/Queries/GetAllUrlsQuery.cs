using LinkShortener.Application.DTO;
using MediatR;

namespace LinkShortener.Application.Queries;

public record GetAllUrlsQuery(bool TrackChanges) : IRequest<IEnumerable<UrlResponseDto>>;