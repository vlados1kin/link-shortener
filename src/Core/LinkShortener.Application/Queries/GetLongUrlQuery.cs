using MediatR;

namespace LinkShortener.Application.Queries;

public record GetLongUrlQuery(string ShortUrl, bool TrackChanges) : IRequest<string>;