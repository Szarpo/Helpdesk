using Helpdesk.Application.DTO;
using MediatR;

namespace Helpdesk.Application.Queries.TicketQuery;

public sealed record GetTicketsByUserQuery(Guid UserId) : IRequest<IEnumerable<TicketsDto>>;