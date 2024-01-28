using MediatR;

namespace Helpdesk.Application.Commands.CommentCommand;

public sealed record CreateCommentCommand(Guid TicketId, Guid UserId, string Content) : IRequest;