using MediatR;

namespace LinkShortener.Application.Commands;

public record DeleteUrlByLongUrlCommand(string LongUrl, bool TrackChanges) : IRequest;