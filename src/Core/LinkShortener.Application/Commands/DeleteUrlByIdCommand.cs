using MediatR;

namespace LinkShortener.Application.Commands;

public record DeleteUrlByIdCommand(Guid Id, bool TrackChanges) : IRequest;