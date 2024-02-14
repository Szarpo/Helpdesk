using MediatR;

namespace Helpdesk.Application.Commands.CommentCommand;

public sealed record CreateCommentCommand(Guid TicketId, string Content) : IRequest;