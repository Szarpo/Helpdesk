using Helpdesk.Application.DTO;
using MediatR;

namespace Helpdesk.Application.Queries.CommentQuery;

public record GetCommentsToTicketQuery(Guid TicketId) : IRequest<IEnumerable<CommentsDto>>;