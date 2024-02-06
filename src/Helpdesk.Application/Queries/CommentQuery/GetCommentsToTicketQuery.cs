using Helpdesk.Application.DTO;
using Helpdesk.Core.Models;
using MediatR;

namespace Helpdesk.Application.Queries.CommentQuery;

public record GetCommentsToTicketQuery(Guid TicketId, int PageSize, int PageNumber) : IRequest<PagedResult<CommentsDto>>;