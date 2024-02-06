using Helpdesk.Application.DTO;
using Helpdesk.Core.Models;
using MediatR;

namespace Helpdesk.Application.Queries.TicketQuery;

public sealed record GetTicketsByUserQuery(Guid UserId, int PageSize, int PageNumber) : IRequest<PagedResult<TicketsDto>>;